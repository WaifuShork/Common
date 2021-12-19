namespace WaifuShork.Common.NativeLoader
{
	using System;
	using System.Runtime.InteropServices;

	internal static class Kernel32
	{
		[DllImport("kernel32"/*, CharSet = CharSet.Unicode*/)]
		public static extern IntPtr LoadLibrary(string fileName);

		[DllImport("kernel32")]
		public static extern IntPtr GetProcAddress(IntPtr module, string procName);

		[DllImport("kernel32")]
		public static extern int FreeLibrary(IntPtr module);
	}
}