using System.Linq;
using System.Reflection.Emit;

namespace WaifuShork.Common.Text;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

public partial struct ValueString
{
    private sealed class Parser
    {
        private static readonly Parser common = new();
        private readonly Type objectType;

        private readonly Type stringType;

        private readonly Type providerType;

        private readonly Type booleanType;

        private readonly Type nullableValueType;

        private readonly Type nullableParserType;

       
        private readonly Type[] formattableParserSig;

        private readonly Type[] parserSig;

        private readonly Type[] numericParserSig;

        private readonly Type[] dateParserSig;
        
        private readonly ParameterExpression[] formattableParserParams;

        private readonly ParameterExpression[] parserParams;

        private readonly ParameterExpression[] numericParserParams;

        private readonly ParameterExpression[] dateParserParams;

        private readonly Type formattableType;


        private Parser()
        {
            this.objectType = typeof(object);

            this.stringType = typeof(string);
            this.providerType = typeof(IFormatProvider);
            this.booleanType = typeof(bool);

            this.nullableValueType = typeof(Nullable<>);
            this.nullableParserType = typeof(NullableParser<>);

            this.formattableParserSig = new[] { this.stringType, this.providerType };
            this.parserSig = new[] { this.stringType };

            var nStylesType = typeof(NumberStyles);
            var dStylesType = typeof(DateTimeStyles);
            this.numericParserSig = new[] { this.stringType, nStylesType, this.providerType };
            this.dateParserSig = new[] { this.stringType, this.providerType, dStylesType };

            var stringParam = Expression.Parameter(this.stringType, "s");
            var providerParam = Expression.Parameter(this.providerType, "provider");
            this.formattableParserParams = new[] { stringParam, providerParam };
            this.parserParams = new[] { stringParam };

            var nStylesParam = Expression.Parameter(nStylesType, "styles");
            var dStylesParam = Expression.Parameter(dStylesType, "styles");
            this.numericParserParams = new[] { stringParam, nStylesParam, providerParam };
            this.dateParserParams = new[] { stringParam, providerParam, dStylesParam };

            this.formattableType = typeof(IFormattable);
        }
        
        public delegate T ParseWithProviderFunc<out T>(string s, IFormatProvider provider);
        public delegate bool TryParseWithProviderFunc<T>(string s, IFormatProvider provider, out T result);
        private delegate T ParseFunc<out T>(string s);
        private delegate bool TryParseFunc<T>(string s, out T result);
        private delegate bool NumericTypeParseFunc<T>(string s, NumberStyles styles, IFormatProvider provider, out T result);
        private delegate bool DateTimeParseFunc<T>(string s, IFormatProvider provider, DateTimeStyles styles, out T result);

        private ParseWithProviderFunc<T> CompileFormattableParser<T>(MethodInfo method)
        {
            var call = Expression.Call(method, this.formattableParserParams.Cast<Expression>());
            var lambda = Expression.Lambda<ParseWithProviderFunc<T>>(call, this.formattableParserParams);
            return lambda.Compile();
        }

        private ParseFunc<T> CompileParser<T>(MethodInfo method)
        {
            var c = Expression.Call(method, this.parserParams.Cast<Expression>());
            var l = Expression.Lambda<ParseFunc<T>>(c, this.parserParams);
            return l.Compile();
        }
        
        private ParseFunc<T> CompileCtor<T>(ConstructorInfo constructor)
        {
            var c = Expression.New(constructor, this.parserParams.Cast<Expression>());
            var l = Expression.Lambda<ParseFunc<T>>(c, this.parserParams);
            return l.Compile();
        }
        
        private TryParseWithProviderFunc<T> CompileSafeFormattableParser<T>(MethodInfo method, Type outTargetType)
        {
            var parameterExpression = Expression.Parameter(outTargetType, "result");
            var parameters = this.GetAdded(this.formattableParserParams, parameterExpression);
            var c = Expression.Call(method, parameters.Cast<Expression>());
            var l = Expression.Lambda<TryParseWithProviderFunc<T>>(c, parameters);
            return l.Compile();
        }

        /// <summary>
        ///     Compiles the specified method as a safe, strongly-typed
        ///     numeric parser that accepts a format provider and returns
        ///     a value indicating whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The target type of the parser.</typeparam>
        /// <param name="method">The method to compile.</param>
        /// <param name="targetType">T
        ///     The runtime instance of the parser's target type.
        /// </param>
        /// <param name="outTargetType">
        ///     The target type as a reference parameter.
        /// </param>
        /// <returns>
        ///     A delegate that parses a string to an
        ///     instance of <typeparamref name="T" />.
        /// </returns>
        private TryParseWithProviderFunc<T> CompileSafeNumericParser<T>(
            MethodInfo method, Type targetType, Type outTargetType)
        {
            var parameterExpression = Expression.Parameter(outTargetType, "result");
            var parameters = this.GetAdded(this.numericParserParams, parameterExpression);
            var c = Expression.Call(method, parameters.Cast<Expression>());
            var l = Expression.Lambda<NumericTypeParseFunc<T>>(c, parameters);
            var d = l.Compile();
            
            return (string s, IFormatProvider provider, out T result) => d(s, NumberStyles.Number, provider, out result);
        }

        /// <summary>
        ///     Compiles the specified method as a safe, strongly-typed
        ///     date parser that accepts a format provider and returns
        ///     a value indicating whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The target type of the parser.</typeparam>
        /// <param name="method">The method to compile.</param>
        /// <param name="outTargetType">
        ///     The target type as a reference parameter.
        /// </param>
        /// <returns>
        ///     A delegate that parses a string to an
        ///     instance of <typeparamref name="T" />.
        /// </returns>
        private TryParseWithProviderFunc<T> CompileSafeDateParser<T>(MethodInfo method, Type outTargetType)
        {
            var o = Expression.Parameter(outTargetType, "result");
            var p = this.GetAdded(this.dateParserParams, o);
            var c = Expression.Call(method, p.Cast<Expression>());
            var l = Expression.Lambda<DateTimeParseFunc<T>>(c, p);
            var d = l.Compile();
            return (string s, IFormatProvider provider, out T result) => d(s, provider, DateTimeStyles.None, out result);
        }

        /// <summary>
        ///     Compiles the specified method as a safe, strongly-typed
        ///     parser that does not accept a format provider and returns
        ///     a value indicating whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The target type of the parser.</typeparam>
        /// <param name="method">The method to compile.</param>
        /// <param name="outTargetType">
        ///     The target type as a reference parameter.
        /// </param>
        /// <returns>
        ///     A delegate that parses a string to an
        ///     instance of <typeparamref name="T" />.
        /// </returns>
        private TryParseFunc<T> CompileSafeParser<T>(MethodInfo method, Type outTargetType)
        {
            var o = Expression.Parameter(outTargetType, "result");
            var p = this.GetAdded(this.parserParams, o);
            var c = Expression.Call(method, p.Cast<Expression>());
            var lambda = Expression.Lambda<TryParseFunc<T>>(c, p);
            return lambda.Compile();
        }

        /// <summary>
        ///     Returns a value indicating whether the
        ///     specified type is a nullable struct.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <param name="underlyingType">
        ///     When this method returns, contains the first generic
        ///     argument of <paramref name="type" /> if it is a nullable
        ///     struct; otherwise, the <paramref name="type" /> itself.
        /// </param>
        /// <returns>
        ///     <c>true</c>, if <paramref name="type" /> is
        ///     a nullable struct; otherwise, <c>false</c>.
        /// </returns>
        private bool IsNullable(Type type, out Type underlyingType)
        {
#if ALT_REFLECTION
            var i = type.GetTypeInfo();
            var n = !i.IsClass
                && i.IsGenericType
                && i.GetGenericTypeDefinition() == this.nullableValueType;

            underlyingType = n ? type.GenericTypeArguments[0] : type;
#else
            var n = !type.IsClass
                && type.IsGenericType
                && type.GetGenericTypeDefinition() == this.nullableValueType;

            underlyingType = n ? type.GetGenericArguments()[0] : type;
#endif

            return n;
        }

        /// <summary>Gets the parser for the specified nullable type.</summary>
        /// <typeparam name="T">The type of the parser.</typeparam>
        /// <param name="targetType">The target type of the parser.</param>
        /// <param name="fieldName">
        ///     The name of the parser delegate in <see cref="Nullable{T}" />
        ///     class to call as underlying parser.
        /// </param>
        /// <returns>
        ///     A strongly-typed parser for the specified target type.
        /// </returns>
        private T CompileNullableParser<T>(Type targetType, string fieldName)
        {
            var parserType = this.nullableParserType.MakeGenericType(targetType);
            var field = GetField(parserType, fieldName);
            if (field is null)
            {
                throw new NullReferenceException("the field was empty, probably an internal error");
            }
            
            var f = Expression.Field(null, field);
            var l = Expression.Lambda<Func<T>>(f, null);
            return l.Compile()();
        }

        /// <summary>
        ///     Returns a new array that contains the
        ///     items of the specified array with the
        ///     specified item added to the end.
        /// </summary>
        /// <typeparam name="T">The type of the array items.</typeparam>
        /// <param name="src">The source array.</param>
        /// <param name="item">The item to add.</param>
        /// <returns>
        ///     A new array containing <paramref name="src" />'s original
        ///     items with <paramref name="item" /> added to the end.
        /// </returns>
        private T[] GetAdded<T>(T[] src, T item)
        {
            var result = new T[src.Length + 1];
            src.CopyTo(result, 0);
            result[src.Length] = item;

            return result;
        }
        
        #region Classes

        /// <summary>Converts objects to culture-invariant strings.</summary>
        /// <typeparam name="T">The type to convert to string.</typeparam>
        public static class Formatter<T>
        {
            /// <summary>The cached formatter.</summary>
            public static readonly Func<T, IFormatProvider, string> Format = InitFormat();

            /// <summary>
            ///     Initializes a formatter for type <typeparamref name="T" />.
            /// </summary>
            /// <returns>
            ///     A delegate that converts the specified object to string
            ///     using the specified format provider where possible.
            /// </returns>
            private static Func<T, IFormatProvider, string?> InitFormat()
            {
                var sourceType = typeof(T);

                var isFormattable = common.formattableType.IsAssignableFrom(sourceType);
                var isValueType = sourceType.IsValueType;
                if (isFormattable)
                {
                    var instance = Expression.Parameter(sourceType, "this");
                    var method = GetMethod(sourceType, "ToString", common.formattableParserSig);
                    if (method is null)
                    {
                        throw new NullReferenceException("method was null, probably an internal error");
                    }
                    
                    var call = Expression.Call(instance, method, common.formattableParserParams.Cast<Expression>());
                    var lambda = Expression.Lambda<Func<T, string, IFormatProvider, string>>(call, instance, common.formattableParserParams[0], common.formattableParserParams[1]);

                    var compiled = lambda.Compile();
                    if (isValueType)
                    {
                        return (f, provider) => compiled(f, "", provider);
                    }
                    
                    return (f, provider) => f is not null ? compiled(f, "", provider) : null;
                }

                if (isValueType)
                {
                    return (o, _) => o?.ToString() ?? string.Empty;
                }
                
                return (o, _) => o?.ToString() ?? string.Empty;
            }
        }

        public static class DefaultParser<T>
        {
            #region Fields

            /// <summary>The cached parser.</summary>
            /// <remarks>
            ///     This field can be <c>null</c>.
            ///     This indicates no delegate could be initialized that
            ///     parses a string to the type <typeparamref name="T" />.
            /// </remarks>
            public static readonly ParseWithProviderFunc<T> Parse = InitParse(true);

            /// <summary>The cached safe parser.</summary>
            /// <remarks>This field cannot be <c>null</c>.</remarks>
            public static readonly TryParseWithProviderFunc<T> TryParse = InitTryParse(true);

            #endregion Fields

            #region Methods

            /// <summary>
            ///     Initializes a parser of type <typeparamref name="T" />.
            /// </summary>
            /// <param name="fallbackToTryParse">
            ///     Whether to fall back to <see cref="InitTryParse(bool)" />
            ///     if no suitable parser method is found.
            /// </param>
            /// <returns>
            ///     A delegate that parses the specified string using the
            ///     specified format provider to type <typeparamref name="T" />,
            ///     if one could be initialized; otherwise, <c>null</c>.
            /// </returns>
            private static ParseWithProviderFunc<T>? InitParse(bool fallbackToTryParse)
            {
                var targetType = typeof(T);

                // Return if the target type is directly assignable from string.
                if (targetType == common.objectType ||
                    targetType == common.stringType)
                {
                    return (s, _) => (T)(object)s;
                }

                // Initialize a nullable value parser if the target type is nullable.
                if (common.IsNullable(targetType, out targetType))
                {
                    return common.CompileNullableParser<ParseWithProviderFunc<T>>(targetType, nameof(Parse));
                }

                // Search for the parsing method.
                const string name = "Parse";
                var method = GetMethod(targetType, name, common.formattableParserSig);
                if (method?.ReturnType == targetType && method.IsStatic)
                {
                    return InitParse(targetType, common.CompileFormattableParser<T>(method));
                }

                method = GetMethod(targetType, name, common.parserSig);
                if (method?.ReturnType == targetType && method.IsStatic)
                {
                    var f = common.CompileParser<T>(method);
                    return InitParse(targetType, (s, _) => f(s));
                }

                // Wrap the safe parser.
                if (fallbackToTryParse)
                {
                    var parser = InitTryParse(false);
                    if (parser != null)
                    {
                        return InitParse(targetType, (s, provider) => parser(s, provider, out var result)
                            ? result
                            : throw new FormatException());
                    }
                }

                // Check for the TypeConverterAttribute.
#if TYPE_DESCRIPTOR
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(targetType);
                if (converter.CanConvertFrom(common.stringType))
                    return (s, provider) => (T)converter.ConvertFromString(null, provider as CultureInfo, s);
#endif

                // Search for a suitable constructor.
                if (TryGetConstructor(targetType, common.parserSig, out var constructor))
                {
                    var f = common.CompileCtor<T>(constructor);
                    return InitParse(targetType, (s, provider) => f(s));
                }

                // Check for a custom parser.
                if (CustomParser.TryGetParser(targetType, out TryParseWithProviderFunc<T> custom))
                {
                    return (s, provider) => custom(s, provider, out var result)
                        ? result
                        : throw new FormatException();
                    
                }

                return null;
            }

            /// <summary>
            ///     Returns a delegate that wraps the specified parser
            ///     in order to support custom defined parsers.
            /// </summary>
            /// <param name="targetType">The target type of the parser.</param>
            /// <param name="parser">The original parser to wrap.</param>
            /// <returns>
            ///     A parser delegate that supports custom parsers and falls
            ///     back to calling the specified <paramref name="parser" />.
            /// </returns>
            private static ParseWithProviderFunc<T> InitParse(Type targetType, ParseWithProviderFunc<T> parser)
            {
                return !CustomParser.TryGetParser(targetType, out TryParseWithProviderFunc<T> custom)
                    ? parser
                    : (s, provider) => custom(s, provider, out var result)
                        ? result
                        : parser(s, provider);
            }

            /// <summary>
            ///     Initializes a safe parser of type <typeparamref name="T" />.
            /// </summary>
            /// <param name="fallbackToParse">
            ///     Whether to fall back to <see cref="InitParse(bool)" />
            ///     if no suitable, safe parser method is found.
            /// </param>
            /// <returns>
            ///     A safe delegate that parses the specified string using the
            ///     specified format provider to type <typeparamref name="T" />.
            /// </returns>
            private static TryParseWithProviderFunc<T>? InitTryParse(bool fallbackToParse)
            {
                // Return if the target type is directly assignable from string.
                var targetType = typeof(T);
                if (targetType == common.objectType ||
                    targetType == common.stringType)
                {
                    return (string s, IFormatProvider _, out T result) =>
                    {
                        result = (T)(object)s;
                        return true;
                    };
                }

                // Initialize a nullable value parser if the target type is nullable.
                if (common.IsNullable(targetType, out targetType))
                {
                    return common.CompileNullableParser<TryParseWithProviderFunc<T>>(targetType, nameof(TryParse));
                }

                // Search for a parsing method.
                const string name = "TryParse";
                var outTargetType = targetType.MakeByRefType();

                var sig = common.GetAdded(common.formattableParserSig, outTargetType);
                var method = GetMethod(targetType, name, sig);
                if (method?.ReturnType == common.booleanType && method.IsStatic)
                {
                    var func = common.CompileSafeFormattableParser<T>(method, outTargetType);
                    return InitTryParse(targetType, func);
                }

                sig = common.GetAdded(common.numericParserSig, outTargetType);
                method = GetMethod(targetType, name, sig);
                if (method?.ReturnType == common.booleanType && method.IsStatic)
                {
                    var func = common.CompileSafeNumericParser<T>(method, targetType, outTargetType);
                    return InitTryParse(targetType, func);
                }

                sig = common.GetAdded(common.dateParserSig, outTargetType);
                method = GetMethod(targetType, name, sig);
                if (method?.ReturnType == common.booleanType && method.IsStatic)
                {
                    var func = common.CompileSafeDateParser<T>(method, outTargetType);
                    return InitTryParse(targetType, func);
                }

                sig = common.GetAdded(common.parserSig, outTargetType);
                method = GetMethod(targetType, name, sig);
                if (method?.ReturnType == common.booleanType && method.IsStatic)
                {
                    var func = common.CompileSafeParser<T>(method, outTargetType);
                    return InitTryParse(targetType, (string s, IFormatProvider _, out T result) => func(s, out result));
                }

                // Wrap the regular parser.
                if (!fallbackToParse)
                {
                    return null;
                }

                var parser = InitParse(false);
                if (parser != null)
                    return InitTryParse(targetType, (string s, IFormatProvider provider, out T result) =>
                    {
                        try
                        {
                            result = parser(s, provider);
                            return true;
                        }
                        catch (Exception)
                        {
                            result = (T) new object();
                            return false;
                        }
                    });

                // Return a failure parser.
                return InitTryParse(targetType, (string s, IFormatProvider _, out T result) =>
                {
                    result = (T) new object();
                    return false;
                });
            }

            /// <summary>
            ///     Returns a delegate that wraps the specified, safe
            ///     parser in order to support custom defined parsers.
            /// </summary>
            /// <param name="targetType">The target type of the parser.</param>
            /// <param name="parser">The original parser to wrap.</param>
            /// <returns>
            ///     A safe parser delegate that supports custom parsers and falls
            ///     back to calling the specified <paramref name="parser" />.
            /// </returns>
            private static TryParseWithProviderFunc<T> InitTryParse(Type targetType, TryParseWithProviderFunc<T> parser)
            {
                return !CustomParser.TryGetParser(targetType, out TryParseWithProviderFunc<T> custom)
                    ? parser
                    : (string s, IFormatProvider provider, out T result) => custom(s, provider, out result)
                                                                            || parser(s, provider, out result);
            }

            /// <summary>
            ///     Searches for a constructor with the specified
            ///     signature declared by the specified type.
            /// </summary>
            /// <param name="type">The type that declared the constructor.</param>
            /// <param name="sig">The constructor signature.</param>
            /// <param name="constructor">
            ///     When this method returns, contains the constructor
            ///     that is found, if a constructor with the specified
            ///     signature is found; otherwise, <c>null</c>.
            /// </param>
            /// <returns>
            ///     <c>true</c>, if a constructor with the specified
            ///     signature is found; otherwise, <c>false</c>.
            /// </returns>
            private static bool TryGetConstructor(Type type, Type[] sig, out ConstructorInfo? constructor)
            {
#if ALT_REFLECTION
                var constructors = type.GetTypeInfo().DeclaredConstructors;
#else
                var constructors = type.GetConstructors();
#endif
                foreach (var c in constructors)
                {
                    var parameters = c.GetParameters();
                    if (parameters.Length != common.parserSig.Length)
                    {
                        continue;
                    }

                    var mismatch = parameters.Where((t, i) => t.ParameterType != common.parserSig[i]).Any();

                    if (!mismatch)
                    {
                        constructor = c;
                        return true;
                    }
                }

                constructor = default;
                return false;
            }

            #endregion Methods
        }

        /// <summary>
        ///     Provides a cached parser for parsing strings to
        ///     nullable instances of <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type to convert from string.</typeparam>
        private static class NullableParser<T>
            where T : struct
        {
            #region Fields

            /// <summary>The cached parser.</summary>
            /// <remarks>
            ///     This field can be <c>null</c>.
            ///     This indicates no delegate could be initialized that
            ///     parses a string to the type <typeparamref name="T" />.
            /// </remarks>
            public static readonly ParseWithProviderFunc<T?> Parse = InitParse();

            /// <summary>The cached safe parser.</summary>
            /// <remarks>This field cannot be <c>null</c>.</remarks>
            public static readonly TryParseWithProviderFunc<T?> TryParse = InitTryParse();

            #endregion Fields

            #region Methods

            /// <summary>
            ///     Initializes a parser of type <typeparamref name="T" />.
            /// </summary>
            /// <returns>
            ///     A delegate that parses the specified string using the
            ///     specified format provider to type <typeparamref name="T" />,
            ///     if one could be initialized; otherwise, <c>null</c>.
            /// </returns>
            /// <remarks>
            ///     The underlying parser uses the <see cref="DefaultParser{T}.Parse" />
            ///     when the specified string is not null.
            /// </remarks>
            private static ParseWithProviderFunc<T?>? InitParse()
            {
                var f = DefaultParser<T>.Parse;
                if (f != null)
                {
                    return (s, provider) => s != null ? f(s, provider) : default(T?);
                }

                return null;
            }

            /// <summary>
            ///     Initializes a safe parser of type <typeparamref name="T" />.
            /// </summary>
            /// <returns>
            ///     A delegate that parses the specified string using the
            ///     specified format provider to type <typeparamref name="T" />.
            /// </returns>
            /// <remarks>
            ///     The underlying parser uses the <see cref="DefaultParser{T}.TryParse" />
            ///     when the specified string is not null.
            /// </remarks>
            private static TryParseWithProviderFunc<T?> InitTryParse()
            {
                return (string s, IFormatProvider provider, out T? result) =>
                {
                    if (s == null)
                    {
                        result = default;
                        return true;
                    }

                    if (DefaultParser<T>.TryParse(s, provider, out var r))
                    {
                        result = r;
                        return true;
                    }

                    result = default;
                    return false;
                };
            }

            #endregion Methods
        }

        /// <summary>Provides custom parsers for common types.</summary>
        private static class CustomParser
        {
            #region Fields

            /// <summary>The custom parsers.</summary>
            private static readonly Dictionary<Type, object> parsers = InitParsers();

            #endregion Fields

            #region Methods

            /// <summary>
            ///     Gets the parser that targets the specified type.
            /// </summary>
            /// <typeparam name="T">The target type of the parser.</typeparam>
            /// <param name="type">
            ///     The runtime instance of the parser's target type.
            /// </param>
            /// <param name="parser">
            ///     When this method returns, contains the parser
            ///     for the type <typeparamref name="T" />, if a
            ///     parser is found; otherwise, <c>null</c>.
            /// </param>
            /// <returns>
            ///     <c>true</c>, if a parser for type <typeparamref name="T" />
            ///     is found; otherwise, <c>false</c>.
            /// </returns>
            public static bool TryGetParser<T>(Type type, out TryParseWithProviderFunc<T>? parser)
            {
                if (parsers.TryGetValue(type, out var p))
                {
                    parser = p as TryParseWithProviderFunc<T>;
                    return true;
                }

                parser = null;
                return false;
            }

            /// <summary>Initializes the custom parsers.</summary>
            /// <returns>A collection of custom parsers.</returns>
            private static Dictionary<Type, object> InitParsers()
            {
                return new Dictionary<Type, object>
                {
                    [typeof(bool)] = new TryParseWithProviderFunc<bool>(
                        (string s, IFormatProvider _, out bool result) =>
                        {
                            if (s != null)
                            {
                                const StringComparison comparison = StringComparison.OrdinalIgnoreCase;
                                
                                if (s.ToLowerInvariant().Equals("true", comparison) 
                                    || s.ToLowerInvariant().Equals("yes", comparison) 
                                    || s.Equals("1", comparison))
                                {
                                    result = true;
                                    return true;
                                }

                                if (s.ToLowerInvariant().Equals("false", comparison) 
                                    || s.ToLowerInvariant().Equals("no", comparison) 
                                    || s.Equals("0", comparison))
                                {
                                    result = false;
                                    return true;
                                }
                            }

                            result = default;
                            return false;
                        }),
                    [typeof(Uri)] = new TryParseWithProviderFunc<Uri>((string s, IFormatProvider _, out Uri result) 
                        => Uri.TryCreate(s, UriKind.Absolute, out result!))
                };
            }

            #endregion Methods
        }

        #endregion Classes
    }
}
