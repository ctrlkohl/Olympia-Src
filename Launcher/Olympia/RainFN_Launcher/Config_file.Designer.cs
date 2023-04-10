using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RainFN_Launcher
{
	// Token: 0x02000002 RID: 2
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
	internal sealed partial class Config_file : ApplicationSettingsBase
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002061 File Offset: 0x00000261
		public static Config_file Default
		{
			get
			{
				return Config_file.defaultInstance;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002068 File Offset: 0x00000268
		// (set) Token: 0x06000007 RID: 7 RVA: 0x0000207A File Offset: 0x0000027A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Path
		{
			get
			{
				return (string)this["Path"];
			}
			set
			{
				this["Path"] = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002088 File Offset: 0x00000288
		// (set) Token: 0x06000009 RID: 9 RVA: 0x0000209A File Offset: 0x0000029A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool Show
		{
			get
			{
				return (bool)this["Show"];
			}
			set
			{
				this["Show"] = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020AD File Offset: 0x000002AD
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020BF File Offset: 0x000002BF
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool AC_bypass
		{
			get
			{
				return (bool)this["AC_bypass"];
			}
			set
			{
				this["AC_bypass"] = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020D2 File Offset: 0x000002D2
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000020E4 File Offset: 0x000002E4
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Exchange
		{
			get
			{
				return (string)this["Exchange"];
			}
			set
			{
				this["Exchange"] = value;
			}
		}

		// Token: 0x04000001 RID: 1
		private static Config_file defaultInstance = (Config_file)SettingsBase.Synchronized(new Config_file());
	}
}
