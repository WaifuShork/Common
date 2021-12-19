using System.IO;
using System.Runtime.InteropServices;

namespace WaifuShork.Common.NativeLoader
{
	using System;

	public class NativeLibrary : IDisposable
	{
		private static readonly LibraryLoader _platformDefaultLoader = LibraryLoader.GetPlatformDefaultLoader();
		private readonly LibraryLoader _loader;	
		
		public NativeLibrary(string name) : this(name, _platformDefaultLoader, PathResolver.Default) {}
		public NativeLibrary(string[] names) : this(names, _platformDefaultLoader, PathResolver.Default) {}
		
		public NativeLibrary(string name, LibraryLoader loader) : this(name, loader, PathResolver.Default) {}
		public NativeLibrary(string[] names, LibraryLoader loader) : this(names, loader, PathResolver.Default) {}

		public NativeLibrary(string name, LibraryLoader loader, PathResolver resolver)
		{
			_loader = loader;
			Handle = _loader.LoadNativeLibrary(name, resolver);
		}

		public NativeLibrary(string[] names, LibraryLoader loader, PathResolver resolver)
		{
			_loader = loader;
			Handle = _loader.LoadNativeLibrary(names, resolver);
		}
		
		public IntPtr Handle { get; }

		public T LoadFunction<T>(string name)
		{
			var functionPtr = _loader.LoadFunctionPointer(Handle, name);
			if (functionPtr == IntPtr.Zero)
			{
				throw new InvalidOperationException($"No function was found with the name {name}");
			}

			return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
		}

		public IntPtr LoadFunction(string name)
		{
			return _loader.LoadFunctionPointer(Handle, name);
		}
		
		public void Dispose()
		{
			_loader.FreeNativeLibrary(Handle);
			GC.SuppressFinalize(this);
		}
	}
}