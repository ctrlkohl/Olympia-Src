using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;
using GGDev_Launcher.DiscordRpcDemo;
using GGDev_Launcher.Epic;
using GGDev_Launcher.Utilities;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using RainFN_Launcher;

namespace GGDev_Launcher
{
	// Token: 0x02000007 RID: 7
	public partial class MainWindow : Window
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000021D0 File Offset: 0x000003D0
		public static string foldername
		{
			get
			{
				return Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)) + "\\";
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000021FC File Offset: 0x000003FC
		private void Give_AntiCheat_Love()
		{
			using (PowerShell powerShell = PowerShell.Create())
			{
				string str = "system*";
				powerShell.AddScript("Set-Service 'BEService' -StartupType Disabled" + str);
				powerShell.AddScript("Set-Service 'EasyAntiCheat' -StartupType Disabled" + str);
				Config_file.Default.AC_bypass = true;
				Config_file.Default.Save();
				foreach (PSObject psobject in powerShell.Invoke())
				{
					if (psobject != null)
					{
						this.msg("An Error occured \n" + psobject.Properties["Status"].Value.ToString() + " - ");
					}
				}
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000022D0 File Offset: 0x000004D0
		private void Save_settings(object sender, EventArgs e)
		{
			Config_file.Default.Path = this.FN_Path.Text;
			Config_file.Default.Save();
			Application.Current.Shutdown();
			Config_file.Default.Exchange = this.exchange;
			Config_file.Default.Save();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002320 File Offset: 0x00000520
		private void MainWindow_Load(object sender, EventArgs e)
		{
			this.DeleteCms();
			if (this.FN_Path.Text == "Fortnite Path" || this.FN_Path.Text == "" || string.IsNullOrEmpty(this.FN_Path.Text))
			{
				TextBox fn_Path = this.FN_Path;
				MainWindow.Installation installation = MainWindow.GetEpicInstallLocations().FirstOrDefault((MainWindow.Installation i) => i.AppName == "Fortnite");
				fn_Path.Text = ((installation != null) ? installation.InstallLocation : null);
			}
			else
			{
				this.FN_Path.Text = Config_file.Default.Path;
			}
			if (!Config_file.Default.AC_bypass)
			{
				this.Give_AntiCheat_Love();
			}
			if (Config_file.Default.Show)
			{
				Config_file.Default.Show = false;
				Config_file.Default.Save();
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002400 File Offset: 0x00000600
		public void ShowLi(bool yesorno)
		{
			if (!yesorno)
			{
				this.Logged_in_as.Visibility = Visibility.Hidden;
				this.DisplayName.Visibility = Visibility.Hidden;
				this.LoginButton.Content = "Login";
				return;
			}
			this.Logged_in_as.Visibility = Visibility.Visible;
			this.DisplayName.Visibility = Visibility.Visible;
			this.LoginButton.Content = "Launch";
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002461 File Offset: 0x00000661
		public void msg(string text)
		{
			MessageBox.Show(text.ToString(), "Olympia Launcher");
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002474 File Offset: 0x00000674
		private void Login_click(object sender, RoutedEventArgs e)
		{
			if (!(this.LoginButton.Content.ToString() == "Login"))
			{
				if (this.LoginButton.Content.ToString() == "Launch")
				{
					Config_file.Default.Path = this.FN_Path.Text;
					Config_file.Default.Save();
					this.exchange = Auth.GetExchange(this.token);
					string text = Path.Combine(Config_file.Default.Path, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");
					string text2 = Path.Combine(Config_file.Default.Path, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_EAC.exe");
					string text3 = Path.Combine(Config_file.Default.Path, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe");
					if (!File.Exists(text))
					{
						this.msg("\"" + text + "\" wasn't found, stop deleting game files!");
						this.ShowLi(false);
						return;
					}
					if (!File.Exists(text2))
					{
						this.msg("\"" + text2 + "\" wasn't found, stop deleting game files!");
						this.ShowLi(false);
						return;
					}
					if (!File.Exists(text3))
					{
						this.msg("\"" + text3 + "\" wasn't found, stop deleting game files!");
						this.ShowLi(false);
						return;
					}
					Config_file.Default.Path = this.FN_Path.Text;
					Config_file.Default.Save();
					string arguments = "-obfuscationid=AqIHXG2ib9xcbISl_E2ui9ctgMCdzw -AUTH_LOGIN=unused -AUTH_PASSWORD=" + this.exchange + " -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -nobe -noeac -fltoken=919348d6add4c4c7c7507e61";
					Process process = new Process
					{
						StartInfo = new ProcessStartInfo(text, arguments)
						{
							UseShellExecute = false,
							RedirectStandardOutput = false,
							CreateNoWindow = true
						}
					};
					Process process2 = new Process();
					process2.StartInfo.FileName = text3;
					process2.Start();
					foreach (object obj in process2.Threads)
					{
						ProcessThread processThread = (ProcessThread)obj;
						Win32.SuspendThread(Win32.OpenThread(2, false, processThread.Id));
					}
					Process process3 = new Process();
					process3.StartInfo.FileName = text2;
					process3.StartInfo.Arguments = "-epiclocale=en -noeac -fromfl=be -fltoken=6a3cc577a8858d6da3aa5313 -frombe";
					process3.Start();
					foreach (object obj2 in process3.Threads)
					{
						ProcessThread processThread2 = (ProcessThread)obj2;
						Win32.SuspendThread(Win32.OpenThread(2, false, processThread2.Id));
					}
					process.Start();
					Thread.Sleep(2000);
					base.Hide();
					Thread.Sleep(6000);
					try
					{
						File.Delete(MainWindow.tempPath + "/Injector.exe");
					}
					catch
					{
					}
					try
					{
						this.webClient.DownloadFile("https://cdn.discordapp.com/attachments/870681151302426637/870681198765162546/Injector.exe", MainWindow.tempPath + "/Injector.exe");
						this.webClient.DownloadFile("https://cdn.discordapp.com/attachments/870681151302426637/897451989544370216/NoKick.dll", MainWindow.tempPath + "NoKick.dll");
						bool? isChecked = this.isDevAccount.IsChecked;
						bool flag = false;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							this.webClient.DownloadFile("https://cdn.discordapp.com/attachments/1075108159305293864/1075108180813676575/Olympia.dll", MainWindow.tempPath + "Olympia.dll");
						}
						isChecked = this.isDevAccount.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							this.webClient.DownloadFile("https://cdn.discordapp.com/attachments/1073998682850086943/1074779638984888340/CeriumS13.dll", MainWindow.tempPath + "CeriumS13.dll");
						}
						this.webClient.DownloadFile("https://cdn.discordapp.com/attachments/870681151302426637/897451770521997402/FortConsole.dll", MainWindow.tempPath + "FortConsole.dll");
					}
					catch
					{
						MessageBox.Show("Please make sure that you are connected to the internet.");
						this.ShowLi(true);
						base.Show();
						return;
					}
					new Process
					{
						StartInfo = 
						{
							Arguments = string.Format("\"{0}\" \"{1}\"", process.Id, MainWindow.GGDevdllpath),
							CreateNoWindow = true,
							UseShellExecute = false,
							FileName = MainWindow.tempPath + "/Injector.exe"
						}
					}.Start();
					process.WaitForInputIdle();
					MessageBox.Show("Press OK After You Passed First Loading Screeen", "Olympia Launcher");
					new Process
					{
						StartInfo = 
						{
							Arguments = string.Format("\"{0}\" \"{1}\"", process.Id, MainWindow.NoKickdllpath),
							CreateNoWindow = true,
							UseShellExecute = false,
							FileName = MainWindow.tempPath + "/Injector.exe"
						}
					}.Start();
					new Process
					{
						StartInfo = 
						{
							Arguments = string.Format("\"{0}\" \"{1}\"", process.Id, MainWindow.ConsoleUnlockerdllpath),
							CreateNoWindow = true,
							UseShellExecute = false,
							FileName = MainWindow.tempPath + "/Injector.exe"
						}
					}.Start();
					process.WaitForExit();
					try
					{
						process2.Close();
						process3.Close();
					}
					catch
					{
					}
					base.Show();
					this.ShowLi(true);
					this.LoginButton.Content = "Login";
					this.Logged_in_as.Visibility = Visibility.Hidden;
					this.DisplayName.Visibility = Visibility.Hidden;
				}
				return;
			}
			base.Hide();
			this.ShowLi(false);
			string devicecode = Auth.GetDevicecode(Auth.GetDevicecodetoken());
			string[] array = devicecode.Split(new char[]
			{
				','
			}, 2);
			if (devicecode.Contains("error"))
			{
				return;
			}
			this.username = array[1];
			this.DisplayName.Content = (string)(array[1] ?? "");
			this.ShowLi(true);
			base.Show();
			this.token = array[0];
			this.LoginButton.Content = "Launch";
			Config_file.Default.Path = this.FN_Path.Text;
			Config_file.Default.Save();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002AA8 File Offset: 0x00000CA8
		public static List<MainWindow.Installation> GetEpicInstallLocations()
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat");
			if (!Directory.Exists(Path.GetDirectoryName(path)) || !File.Exists(path))
			{
				return null;
			}
			return JsonConvert.DeserializeObject<MainWindow.EpicInstallLocations>(File.ReadAllText(path)).InstallationList;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002AF0 File Offset: 0x00000CF0
		private void Select_fn_path_button_Click(object sender, EventArgs e)
		{
			string text = this.FN_Path.Text;
			CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog
			{
				IsFolderPicker = true
			};
			if (commonOpenFileDialog.ShowDialog() == 1)
			{
				this.FN_Path.Text = commonOpenFileDialog.FileName;
				Config_file.Default.Path = this.FN_Path.Text;
				Config_file.Default.Save();
				return;
			}
			this.FN_Path.Text = text;
			Config_file.Default.Path = this.FN_Path.Text;
			Config_file.Default.Save();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002B7C File Offset: 0x00000D7C
		private void DeleteCms()
		{
			try
			{
				string path = Environment.GetEnvironmentVariable("LocalAppData") + "\\FortniteGame\\Saved\\PersistentDownloadDir";
				string path2 = Environment.GetEnvironmentVariable("LocalAppData") + "\\FortniteGame\\Saved\\webcache";
				Directory.Delete(path, true);
				Directory.Delete(path2, true);
			}
			catch
			{
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002BD4 File Offset: 0x00000DD4
		private void Console_Checked(object sender, RoutedEventArgs e)
		{
			MainWindow.disableConsole = false;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002BDC File Offset: 0x00000DDC
		private void Console_UnChecked(object sender, RoutedEventArgs e)
		{
			MainWindow.disableConsole = true;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002BE4 File Offset: 0x00000DE4
		private void Info_Click(object sender, EventArgs e)
		{
			Process.Start("https://dsc.gg/Olympia");
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002BF1 File Offset: 0x00000DF1
		private void Settings_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Settings is not working we gonna delete thm.", "Olympia Launcher", MessageBoxButton.OK);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002BE4 File Offset: 0x00000DE4
		private void Info_Click2(object sender, EventArgs e)
		{
			Process.Start("https://dsc.gg/Olympia");
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002C04 File Offset: 0x00000E04
		private void FortniteKill_click(object sender, EventArgs e)
		{
			Process.Start("taskkill", "/F /IM FortniteLauncher.exe && echo e && taskkill /F /IM FortniteClient-Win64-Shipping_EAC.exe && taskkill /F /IM FortniteClient-Win64-Shipping_BE.exe && taskkill /F /IM FortniteClient-Win64-Shipping.exe && pause");
			MessageBox.Show("Killed Fortnite Process", "Olympia Launcher");
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000205F File Offset: 0x0000025F
		private void Settings_click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002C26 File Offset: 0x00000E26
		private void ThreadSLeep_click(object sender, EventArgs e)
		{
			Process.Start("Thread.Sleep(80000)");
			Process.Start("                            Fortnite.WaitForInputIdle();");
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000205F File Offset: 0x0000025F
		private void SettingsFrame_Navigated(object sender, NavigationEventArgs e)
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000205F File Offset: 0x0000025F
		private void isDevAccount_Checked(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x04000007 RID: 7
		private DiscordRpc.EventHandlers handlers;

		// Token: 0x04000008 RID: 8
		private DiscordRpc.RichPresence presence;

		// Token: 0x04000009 RID: 9
		public static bool disableConsole = false;

		// Token: 0x0400000A RID: 10
		private string token;

		// Token: 0x0400000B RID: 11
		private string exchange;

		// Token: 0x0400000C RID: 12
		private string username;

		// Token: 0x0400000D RID: 13
		public static string tempPath = Path.GetTempPath();

		// Token: 0x0400000E RID: 14
		private readonly WebClient webClient = new WebClient();

		// Token: 0x0400000F RID: 15
		public static string plataniumdllpath = MainWindow.foldername + "Platanium.dll";

		// Token: 0x04000010 RID: 16
		public static string nothingdllpath = MainWindow.foldername + "Nothing.dll";

		// Token: 0x04000011 RID: 17
		public static string GGDevdllpath = MainWindow.tempPath + "Olympia.dll";

		// Token: 0x04000012 RID: 18
		public static string NoKickdllpath = MainWindow.tempPath + "Nokick.dll";

		// Token: 0x04000013 RID: 19
		public static string ConsoleUnlockerdllpath = MainWindow.tempPath + "FortConsole.dll";

		// Token: 0x04000014 RID: 20
		private bool Initalized;

		// Token: 0x02000008 RID: 8
		public class EpicInstallLocations
		{
			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000033 RID: 51 RVA: 0x00002EA5 File Offset: 0x000010A5
			// (set) Token: 0x06000034 RID: 52 RVA: 0x00002EAD File Offset: 0x000010AD
			[JsonProperty("InstallationList")]
			public List<MainWindow.Installation> InstallationList { get; set; }
		}

		// Token: 0x02000009 RID: 9
		public class Installation
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000036 RID: 54 RVA: 0x00002EB6 File Offset: 0x000010B6
			// (set) Token: 0x06000037 RID: 55 RVA: 0x00002EBE File Offset: 0x000010BE
			[JsonProperty("InstallLocation")]
			public string InstallLocation { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000038 RID: 56 RVA: 0x00002EC7 File Offset: 0x000010C7
			// (set) Token: 0x06000039 RID: 57 RVA: 0x00002ECF File Offset: 0x000010CF
			[JsonProperty("AppName")]
			public string AppName { get; set; }
		}
	}
}
