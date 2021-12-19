namespace WaifuShork.Common.NativeLoader;

using System;
using System.Runtime.InteropServices;
	
internal static class Libdl
{
	private const string _libName = "libdl";
	public const int RtldNow = 0x002;

	[DllImport(_libName, EntryPoint = "dlopen", CharSet = CharSet.Unicode)]
	public static extern IntPtr DlOpen(string fileName, int flags);

	[DllImport(_libName, EntryPoint = "dlclose", CharSet = CharSet.Unicode)]
	public static extern int DlClose(IntPtr handle);

	[DllImport(_libName, EntryPoint = "dlsym", CharSet = CharSet.Unicode)]
	public static extern IntPtr DlSym(IntPtr handle, string name);

	[DllImport(_libName, EntryPoint = "dlerror", CharSet = CharSet.Unicode)]
	public static extern string DlError();
}