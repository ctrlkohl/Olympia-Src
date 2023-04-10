using System;
using System.Text.Json.Serialization;

namespace GGDev_Launcher.Epic
{
	// Token: 0x0200000E RID: 14
	public class devicecode
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002F7C File Offset: 0x0000117C
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002F84 File Offset: 0x00001184
		[JsonPropertyName("user_code")]
		public int user_code { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002F8D File Offset: 0x0000118D
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002F95 File Offset: 0x00001195
		[JsonPropertyName("device_code")]
		public string device_code { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002F9E File Offset: 0x0000119E
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002FA6 File Offset: 0x000011A6
		[JsonPropertyName("verification_uri")]
		public string verification_uri { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002FAF File Offset: 0x000011AF
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002FB7 File Offset: 0x000011B7
		[JsonPropertyName("verification_uri_complete")]
		public string verification_uri_complete { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002FC0 File Offset: 0x000011C0
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00002FC8 File Offset: 0x000011C8
		[JsonPropertyName("prompt")]
		public string prompt { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002FD1 File Offset: 0x000011D1
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00002FD9 File Offset: 0x000011D9
		[JsonPropertyName("expires_in")]
		public string expires_in { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002FE2 File Offset: 0x000011E2
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00002FEA File Offset: 0x000011EA
		[JsonPropertyName("interval")]
		public string interval { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002FF3 File Offset: 0x000011F3
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00002FFB File Offset: 0x000011FB
		[JsonPropertyName("client_id")]
		public string client_id { get; set; }
	}
}
