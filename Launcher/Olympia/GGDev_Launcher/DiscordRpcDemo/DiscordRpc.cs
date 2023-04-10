using System;
using System.Runtime.InteropServices;

namespace GGDev_Launcher.DiscordRpcDemo
{
	// Token: 0x02000011 RID: 17
	internal class DiscordRpc
	{
		// Token: 0x06000076 RID: 118
		[DllImport("discord-rpc-w32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Initialize")]
		public static extern void Initialize(string applicationId, ref DiscordRpc.EventHandlers handlers, bool autoRegister, string optionalSteamId);

		// Token: 0x06000077 RID: 119
		[DllImport("discord-rpc-w32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RunCallbacks")]
		public static extern void RunCallbacks();

		// Token: 0x06000078 RID: 120
		[DllImport("discord-rpc-w32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Shutdown")]
		public static extern void Shutdown();

		// Token: 0x06000079 RID: 121
		[DllImport("discord-rpc-w32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UpdatePresence")]
		public static extern void UpdatePresence(ref DiscordRpc.RichPresence presence);

		// Token: 0x0600007A RID: 122 RVA: 0x0000354F File Offset: 0x0000174F
		internal static void Initialize(string v1, ref object handlers, bool v2, object p)
		{
			throw new NotImplementedException();
		}

		// Token: 0x02000012 RID: 18
		// (Invoke) Token: 0x0600007D RID: 125
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DisconnectedCallback(int errorCode, string message);

		// Token: 0x02000013 RID: 19
		// (Invoke) Token: 0x06000081 RID: 129
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ErrorCallback(int errorCode, string message);

		// Token: 0x02000014 RID: 20
		public struct EventHandlers
		{
			// Token: 0x04000038 RID: 56
			public DiscordRpc.ReadyCallback readyCallback;

			// Token: 0x04000039 RID: 57
			public DiscordRpc.DisconnectedCallback disconnectedCallback;

			// Token: 0x0400003A RID: 58
			public DiscordRpc.ErrorCallback errorCallback;
		}

		// Token: 0x02000015 RID: 21
		// (Invoke) Token: 0x06000085 RID: 133
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ReadyCallback();

		// Token: 0x02000016 RID: 22
		[Serializable]
		public struct RichPresence
		{
			// Token: 0x0400003B RID: 59
			public string state;

			// Token: 0x0400003C RID: 60
			public string details;

			// Token: 0x0400003D RID: 61
			public long startTimestamp;

			// Token: 0x0400003E RID: 62
			public long endTimestamp;

			// Token: 0x0400003F RID: 63
			public string largeImageKey;

			// Token: 0x04000040 RID: 64
			public string largeImageText;

			// Token: 0x04000041 RID: 65
			public string smallImageKey;

			// Token: 0x04000042 RID: 66
			public string smallImageText;

			// Token: 0x04000043 RID: 67
			public string partyId;

			// Token: 0x04000044 RID: 68
			public int partySize;

			// Token: 0x04000045 RID: 69
			public int partyMax;

			// Token: 0x04000046 RID: 70
			public string matchSecret;

			// Token: 0x04000047 RID: 71
			public string joinSecret;

			// Token: 0x04000048 RID: 72
			public string spectateSecret;

			// Token: 0x04000049 RID: 73
			public bool instance;
		}
	}
}
