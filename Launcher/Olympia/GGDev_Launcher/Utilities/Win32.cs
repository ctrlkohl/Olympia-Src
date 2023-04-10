using System;
using System.Runtime.InteropServices;

namespace GGDev_Launcher.Utilities
{
	// Token: 0x0200000C RID: 12
	public static class Win32
	{
		// Token: 0x0600004A RID: 74
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

		// Token: 0x0600004B RID: 75
		[DllImport("kernel32.dll")]
		public static extern int SuspendThread(IntPtr hThread);

		// Token: 0x0600004C RID: 76
		[DllImport("kernel32.dll")]
		public static extern int ResumeThread(IntPtr hThread);

		// Token: 0x0600004D RID: 77
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool AllocConsole();

		// Token: 0x0600004E RID: 78
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool SetConsoleCtrlHandler(Win32.HandlerRoutine HandlerRoutine, bool Add);

		// Token: 0x0600004F RID: 79
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x06000050 RID: 80
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		// Token: 0x06000051 RID: 81
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000052 RID: 82
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x06000053 RID: 83
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

		// Token: 0x06000054 RID: 84
		[DllImport("kernel32.dll")]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x04000025 RID: 37
		public const int PROCESS_CREATE_THREAD = 2;

		// Token: 0x04000026 RID: 38
		public const int PROCESS_VM_OPERATION = 8;

		// Token: 0x04000027 RID: 39
		public const int PROCESS_VM_WRITE = 32;

		// Token: 0x04000028 RID: 40
		public const int PROCESS_VM_READ = 16;

		// Token: 0x04000029 RID: 41
		public const int PROCESS_QUERY_INFORMATION = 1024;

		// Token: 0x0400002A RID: 42
		public const uint PAGE_READWRITE = 4U;

		// Token: 0x0400002B RID: 43
		public const uint MEM_COMMIT = 4096U;

		// Token: 0x0400002C RID: 44
		public const uint MEM_RESERVE = 8192U;

		// Token: 0x0200000D RID: 13
		// (Invoke) Token: 0x06000056 RID: 86
		public delegate bool HandlerRoutine(int dwCtrlType);
	}
}
