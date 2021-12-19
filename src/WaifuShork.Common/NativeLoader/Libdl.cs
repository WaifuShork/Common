namespace WaifuShork.Common.NativeLoader
{
	using System;
	using System.Runtime.InteropServices;
	
	internal static class Libdl
	{
		private const string _libName = "libdl";
		public const int RtldNow = 0x002;

		[DllImport(_libName)]
		public static extern IntPtr dlopen(string fileName, int flags);

		[DllImport(_libName)]
		public static extern IntPtr dlsym(IntPtr handle, string name);

		[DllImport(_libName)]
		public static extern int dlclose(IntPtr handle);

		[DllImport(_libName)]
		public static extern string dlerror();
	}
}