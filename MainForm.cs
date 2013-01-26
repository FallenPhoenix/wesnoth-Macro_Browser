/******************************
 * Created with SharpDevelop 3.
 * User: F. Phoenix
 * Date: 05.01.2013 10:51
 ******************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Macro_Browser
{
	/// <summary> Главное окно программы. </summary>
	public partial class MainForm : Form
	{
		string GoToMacro = "";
		ViewerModes ViewerMode = ViewerModes.Enabled;
		MacroDataCollection Macros = new MacroDataCollection();
		string[] MacroFiles;
		ToolStripDropDownMenu tsdFilter;
		bool FilterChanged;
		
		public MainForm(string[] args)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			tsdFilter = new ToolStripDropDownMenu();
			tsdFilter.RenderMode = ToolStripRenderMode.System;
			tsdFilter.ItemClicked += new ToolStripItemClickedEventHandler(tsdFilter_ItemClicked);
			tsdFilter.Closing += new ToolStripDropDownClosingEventHandler(tsdFilter_Closing);
			tsdFilter.Closed += new ToolStripDropDownClosedEventHandler(tsdFilter_Closed);
			tsbFilter.DropDown = tsdFilter;
			
			#region Загрузка конфига
			Settings.Ini = Path.ChangeExtension(Application.ExecutablePath, "ini");
			Settings.Load();
			if (Settings.Window_Width > 0) this.Width = Settings.Window_Width;
			if (Settings.Window_Height > 0) this.Height = Settings.Window_Height;
			if (Settings.Window_Separator > 0) splitContainer.SplitterDistance = Settings.Window_Separator;
			if (Settings.Window_Maximized)
			{
				var screen = Screen.PrimaryScreen.WorkingArea.Size;
				this.Location = new Point((screen.Width - Width) / 2, (screen.Height - Height) / 2);
				this.WindowState = FormWindowState.Maximized;
			}
			#endregion
			
			#region Обработка аргументов
			foreach (string arg in args)
			{
				var kvp = arg.Split(new[]{'='}, 2);
				switch (kvp[0].ToLower())
				{
					case "-title":  // Заголовок окна
						this.Text = kvp[1];
						break;
					case "-goto":  // Переход к макросу
						GoToMacro = kvp[1].ToUpper();
						break;
					case "-openviewer":  // Открытие макросов по даблклику
						try
						{
							var mode = (ViewerModes)Enum.Parse(typeof(ViewerModes), kvp[1], true);
							ViewerMode = mode;
						}
						catch {}
						break;
				}
			}
			#endregion
		}
		
		
		void MainForm_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists(Settings.GamePath))
			{
				var fb = new FolderBrowserDialog()
				{
					Description = "Укажите корневую папку игры.",
				};
				if (fb.ShowDialog() == DialogResult.OK) Settings.GamePath = fb.SelectedPath;
			}
			
			LoadMacros();
			
			if (GoToMacro.Length > 0)
			{
				var nodes = tvList.Nodes.Find(GoToMacro, true);
				if (nodes.Length > 0) tvList.SelectedNode = nodes[0];
			}
			
			this.SizeChanged += new EventHandler(MainForm_SizeChanged);
		}
		
		void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool normal = (this.WindowState == FormWindowState.Normal);
			Settings.Window_Width = normal ? this.Width : this.RestoreBounds.Width;
			Settings.Window_Height = normal ? this.Height : this.RestoreBounds.Height;
			Settings.Window_Separator = splitContainer.SplitterDistance;
			//Settings.Window_Maximized = (this.WindowState == FormWindowState.Maximized);
			Settings.Save();
		}
		
		void MainForm_SizeChanged(object sender, EventArgs e)
		{
			// Потому что через свойства нельзя узнать, какое было состояние до сворачивания
			if (this.WindowState != FormWindowState.Minimized)
				Settings.Window_Maximized = (this.WindowState == FormWindowState.Maximized);
		}
		
		void tsToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			switch (e.ClickedItem.Name)
			{
				case "tsbUpdate": LoadMacros(); break;
				case "tsbWordWrap": tCode.WordWrap = tsbWordWrap.Checked = !tsbWordWrap.Checked; break;
				case "tsbSettings":
					var settings = new SettingsForm();
					if (settings.ShowDialog() != DialogResult.OK) break;
					if (settings.NeedRefresh) LoadMacros();
					break;
			}
		}
		
		void tsdFilter_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			var item = e.ClickedItem as ToolStripMenuItem;
			bool state = !item.Checked;
			if (Control.ModifierKeys == Keys.Shift)
				foreach (ToolStripMenuItem li in tsdFilter.Items)  li.Checked = state;
			else item.Checked = state;
			FilterChanged = true;
		}
		
		void tsdFilter_Closing(object sender, ToolStripDropDownClosingEventArgs e)
		{
			e.Cancel = (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked);
		}
		
		void tsdFilter_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			if (!FilterChanged) return;
			FilterChanged = false;
			
			var disabled = new List<string>();
			foreach (ToolStripMenuItem item in tsdFilter.Items)
				if (!item.Checked) disabled.Add(item.Text);
			Settings.DisabledFiles = disabled.ToArray();
			tmRefresh.Start();
		}
		
		void tmRefresh_Tick(object sender, EventArgs e)
		{
			tmRefresh.Stop();
			RefreshTree();
		}
		
		void tSearch_TextChanged(object sender, EventArgs e)
		{
			var text = tSearch.Text;
			foreach (TreeNode n in tvList.Nodes)
				if (n.Text.StartsWith(text)) {tvList.SelectedNode = n; break;}
		}
		
		void tvList_AfterSelect(object sender, TreeViewEventArgs e)
		{
			tCode.Text = (e.Node.Tag as MacroData).Code;
		}
		
		void tvList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			var macro = e.Node.Tag as MacroData;
			
			switch (ViewerMode)
			{
				case ViewerModes.Enabled:
					if (Settings.Viewer.Length > 0 && File.Exists(Settings.Viewer))
						Process.Start(Settings.Viewer, Settings.ViewerArgs.Replace("%f", macro.File).Replace("%l", macro.Line.ToString()));
					break;
				case ViewerModes.Return:
					Console.Write(macro.File + "\t" + macro.Line);
					Application.Exit();
					break;
			}
		}
		
		
		void LoadMacros()
		{
			Macros = new MacroDataCollection();
			if (!Directory.Exists(Settings.MacroPath)) return;
			MacroFiles = Directory.GetFiles(Settings.MacroPath, "*.cfg");
			Array.Sort(MacroFiles);
			var rx_define = new Regex(@"^\s*#define\s+(?<name>[a-z_][a-z_0-9:]*).*", RegexOptions.IgnoreCase);
			var rx_enddef = new Regex(@"^.*?#enddef\s*$", RegexOptions.IgnoreCase);
			Match m;
			var code = new List<string>();
			foreach (string file in MacroFiles)
			{
				var macro_name = string.Empty;
				var line = 0;
				var data = File.ReadAllLines(file);
				for (int i = 0; i < data.Length; i++)
				{
					var str = data[i];
					if (macro_name.Length > 0)
					{
						code.Add(str);
						if (macro_name.Length > 0 && (m = rx_enddef.Match(str)).Success)
						{
							var macro = Macros.Add(macro_name, string.Join("\r\n", code.ToArray()), file, line);
							macro.Node = new TreeNode()
							{
								Name = macro_name,
								Text = macro_name,
								Tag = macro
							};
							macro_name = string.Empty;
							code.Clear();	
						}
					}
					else if ((m = rx_define.Match(str)).Success)
					{
						macro_name = m.Groups["name"].Value;
						line = i + 1;
						code.Add(str);
					}
				}
			}
			
			RefreshTree();
			RefreshFilter();
		}

		void RefreshTree()
		{
			if (MacroFiles == null) return;
			var nodes = new List<TreeNode>();
			foreach (MacroData macro in Macros)
				if (Array.IndexOf(Settings.DisabledFiles, Path.GetFileName(macro.File)) < 0)
					nodes.Add(macro.Node);
			var selected = tvList.SelectedNode;
			tvList.BeginUpdate();
			tvList.Nodes.Clear();
			tvList.Nodes.AddRange(nodes.ToArray());
			tvList.Sort();
			tvList.SelectedNode = selected;
			tvList.EndUpdate();
		}
		
		void RefreshFilter()
		{
			// TODO: Сделать обработку фильтра и сносный внешний вид для этой менюшки: по дефолту слишком большие отступы.
			tsdFilter.Items.Clear();
			foreach (string file in MacroFiles)
			{
				var name = Path.GetFileName(file);
				var item = new ToolStripMenuItem()
				{
					Text = name,
					Height = 12,
					Checked = (Array.IndexOf(Settings.DisabledFiles, name) < 0)
				};
				tsdFilter.Items.Add(item);
			}
		}
		
		void Error(string msg)
		{
			MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
