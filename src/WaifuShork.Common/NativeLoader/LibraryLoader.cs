using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace WaifuShork.Common.NativeLoader
{
	public abstract class LibraryLoader
	{
		public IntPtr LoadNativeLibrary(string name)
		{
			return LoadNativeLibrary(name, PathResolver.Default);
		}

		public IntPtr LoadNativeLibrary(string[] names)
		{
			return LoadNativeLibrary(names, PathResolver.Default);
		}

		public IntPtr LoadNativeLibrary(string name, PathResolver resolver)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException(nameof(name), "Name cannot be null, whitespace or empty");
			}

			var ret = LoadWithResolver(name, resolver);
			if (ret == IntPtr.Zero)
			{
				throw new FileNotFoundException($"Could not find or load the native library: {name}");
			}

			return ret;
		}

		public IntPtr LoadNativeLibrary(string[] names, PathResolver resolver)
		{
			if (names == null || names.Length == 0)
			{
				throw new ArgumentNullException(nameof(names), "Parameters cannot be null or empty");
			}

			var ret = IntPtr.Zero;

			foreach (var name in names)
			{
				ret = LoadWithResolver(name, resolver);
				if (ret != IntPtr.Zero)
				{
					break;
				}
			}

			if (ret == IntPtr.Zero)
			{
				throw new FileNotFoundException($"Count not find or load the native library from any name: [ {string.Join(", ", names)} ]");
			}

			return ret;
		}

		private IntPtr LoadWithResolver(string name, PathResolver resolver)
		{
			if (Path.IsPathRooted(name))
			{
				return CoreLoadNativeLibrary(name);
			}
			
			foreach (var loadTarget in resolver.EnumeratePossibleLibraryLoadTargets(name))
			{
				if (!Path.IsPathRooted(loadTarget) || File.Exists(loadTarget))
				{
					var ret = CoreLoadNativeLibrary(loadTarget);
					if (ret != IntPtr.Zero)
					{
						return ret;
					}
				}
			}

			return IntPtr.Zero;
		}

		public IntPtr LoadFunctionPointer(IntPtr handle, string functionName)
		{
			if (string.IsNullOrWhiteSpace(functionName))
			{
				throw new ArgumentNullException(nameof(functionName), "Name cannot be null, whitespace or empty");
			}

			return CoreLoadFunctionPointer(handle, functionName);
		}

		public void FreeNativeLibrary(IntPtr handle)
		{
			if (handle == IntPtr.Zero)
			{
				throw new ArgumentException("Handle must not be zero", nameof(handle));
			}

			CoreFreeNativeLibrary(handle);
		}

		protected abstract IntPtr CoreLoadNativeLibrary(string name);
		protected abstract void CoreFreeNativeLibrary(IntPtr handle);
		protected abstract IntPtr CoreLoadFunctionPointer(IntPtr handle, string functionName);

		public static LibraryLoader GetPlatformDefaultLoader()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				return new Wind32LibraryLoader();
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				return new UnixLibraryLoader();
			}

			throw new PlatformNotSupportedException("This platform cannot load native libraries");
		}

		private class Wind32LibraryLoader : LibraryLoader
		{
			protected override IntPtr CoreLoadNativeLibrary(string name)
			{
				return Kernel32.LoadLibrary(name);
			}

			protected override void CoreFreeNativeLibrary(IntPtr handle)
			{
				Kernel32.FreeLibrary(handle);
			}

			protected override IntPtr CoreLoadFunctionPointer(IntPtr handle, string functionName)
			{
				return Kernel32.GetProcAddress(handle, functionName);
			}
		}

		private class UnixLibraryLoader : LibraryLoader
		{
			protected override IntPtr CoreLoadNativeLibrary(string name)
			{
				return Libdl.dlopen(name, Libdl.RtldNow);
			}

			protected override void CoreFreeNativeLibrary(IntPtr handle)
			{
				Libdl.dlclose(handle);
			}

			protected override IntPtr CoreLoadFunctionPointer(IntPtr handle, string functionName)
			{
				return Libdl.dlsym(handle, functionName);
			}
		}
	}
	
}