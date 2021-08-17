namespace WaifuShork.Common.Extensions
{
	using System;
	using System.Reflection;
	using System.Collections.Generic;
	using Microsoft.Toolkit.Diagnostics;

	public static class CloneExtensions
	{
		private static readonly MethodInfo _cloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

		private static bool IsPrimitive(this Type type)
		{
			if (type == typeof(string))
			{
				return true;
			}

			return type.IsValueType & type.IsPrimitive;
		}
		
		/// <summary>
		/// This will deeply clone any reference type into a brand new object, snipping all references to allow the object to be
		/// unique and without side effects from the original cloned object. This method uses Recursive Memberwise to ensure a deep copy.
		/// </summary>
		/// <remarks>
		///	If you'd like to learn more about Deep and Shallow clones/copies, checkout this link: https://www.geeksforgeeks.org/shallow-copy-and-deep-copy-in-c-sharp/
		/// </remarks>
		/// <param name="obj">The object to deeply clone</param>
		/// <returns>A deeply cloned object</returns>
		public static object DeepClone(this object obj)
		{
			return DeepCloneInternal(obj, new Dictionary<object, object>(new Utilities.ReferenceEqualityComparer()));
		}
		
		/// <summary>
		/// This will deeply clone any reference type into a brand new object, snipping all references to allow the object to be
		/// unique and without side effects from the original cloned object. This method uses Recursive Memberwise to ensure a deep copy.
		/// </summary>
		/// <remarks>
		///	If you'd like to learn more about Deep and Shallow clones/copies, checkout this link: https://www.geeksforgeeks.org/shallow-copy-and-deep-copy-in-c-sharp/
		/// </remarks>
		/// <param name="obj">The object to deeply clone</param>
		/// <returns>A deeply cloned object</returns>
		public static T DeepClone<T>(this T obj)
		{
			return (T)DeepClone((object) obj);
		}
		
		private static object DeepCloneInternal(object obj, IDictionary<object, object> visited)
		{
			if (obj == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(obj), "Cannot deeply clone a null pointer");
			}

			var typeToReflect = obj.GetType();
			if (typeToReflect.IsPrimitive())
			{
				return obj;
			}

			if (visited.ContainsKey(obj))
			{
				return visited[obj];
			}

			if (typeof(Delegate).IsAssignableFrom(typeToReflect))
			{
				return null;
			}

			var cloneObject = _cloneMethod.Invoke(obj, null);
			if (typeToReflect.IsArray)
			{
				var arrayType = typeToReflect.GetElementType();
				if (arrayType.IsPrimitive() == false)
				{
					var clonedArray = (Array)cloneObject;
					clonedArray.ForEach((array, indices) =>
					{
						array.SetValue(DeepCloneInternal(clonedArray?.GetValue(indices), visited), indices);
					});
				}
			}
			
			visited.Add(obj, cloneObject);
			CopyFields(obj, visited, cloneObject, typeToReflect);
			RecursiveCopyBaseTypePrivateFields(obj, visited, cloneObject, typeToReflect);
			return cloneObject;
		}
		
		private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
		{
			if (typeToReflect.BaseType != null)
			{
				RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
				CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
			}
		}
 
		private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
		{
			for (var i = 0; i < typeToReflect.GetFields(bindingFlags).Length; i++)
			{
				var fieldInfo = typeToReflect.GetFields(bindingFlags)[i];
				if (filter != null && filter(fieldInfo) == false)
				{
					continue;
				}

				if (IsPrimitive(fieldInfo.FieldType))
				{
					continue;
				}
				
				var originalFieldValue = fieldInfo.GetValue(originalObject);
				var clonedFieldValue = DeepCloneInternal(originalFieldValue, visited);
				fieldInfo.SetValue(cloneObject, clonedFieldValue);
			}
		}

		private static void ForEach(this Array array, Action<Array, int[]> action)
		{
			if (array.LongLength == 0)
			{
				return;
			}

			var walker = new ArrayTraverse(array);
			do
			{
				action(array, walker.Position);
			} while (walker.Step());
		}
	}
	
	internal class ArrayTraverse
	{
		public readonly int[] Position;
		private readonly int[] maxLengths;
 
		public ArrayTraverse(Array array)
		{
			maxLengths = new int[array.Rank];
			for (var i = 0; i < array.Rank; ++i)
			{
				maxLengths[i] = array.GetLength(i) - 1;
			}
			Position = new int[array.Rank];
		}
 
		public bool Step()
		{
			for (var i = 0; i < Position.Length; ++i)
			{
				if (Position[i] < maxLengths[i])
				{
					Position[i]++;
					for (var j = 0; j < i; j++)
					{
						Position[j] = 0;
					}
					return true;
				}
			}
			return false;
		}
	}
}