using System;
using System.Text.Json.Serialization;

namespace GGDev_Launcher.Epic
{
	// Token: 0x0200000F RID: 15
	public class Exchange
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00003004 File Offset: 0x00001204
		// (set) Token: 0x0600006B RID: 107 RVA: 0x0000300C File Offset: 0x0000120C
		[JsonPropertyName("expiresInSeconds")]
		public int ExpiresInSeconds { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003015 File Offset: 0x00001215
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000301D File Offset: 0x0000121D
		[JsonPropertyName("code")]
		public string Code { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00003026 File Offset: 0x00001226
		// (set) Token: 0x0600006F RID: 111 RVA: 0x0000302E File Offset: 0x0000122E
		[JsonPropertyName("creatingClientId")]
		public string CreatingClientId { get; set; }
	}
}
