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

namespace Macro_Browser
{
	/// <summary> Главное окно программы. </summary>
	public partial class MainForm : Form
	{
		MacroDataCollection Macros = new MacroDataCollection();
		
		public MainForm(string[] args)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			Settings.Ini = Path.ChangeExtension(Application.ExecutablePath, "ini");
			Settings.Load();
			if (Settings.Window_Width > 0) this.Width = Settings.Window_Width;
			if (Settings.Window_Height > 0) this.Height = Settings.Window_Height;
			if (Settings.Window_Separator > 0) splitContainer.SplitterDistance = Settings.Window_Separator;
		}
		
		
		void MainForm_Load(object sender, EventArgs e)
		{
			LoadMacros();
		}
		
		void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Window_Width = this.Width;
			Settings.Window_Height = this.Height;
			Settings.Window_Separator = splitContainer.SplitterDistance;
			Settings.Save();
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
		
		
		void LoadMacros()
		{
			#region Анализ файлов
			Macros = new MacroDataCollection();
			var rx_define = new Regex(@"^\s*#define\s+(?<name>[a-z_][a-z_0-9:]*).*", RegexOptions.IgnoreCase);
			var rx_enddef = new Regex(@"^.*?#enddef\s*$", RegexOptions.IgnoreCase);
			var files = Directory.GetFiles(Settings.MacroPath, "*.cfg");
			Array.Sort(files);
			Match m;
			var code = new List<string>();
			foreach (string file in files)
			{
				var macro = string.Empty;
				var line = 0;
				var data = File.ReadAllLines(file);
				for (int i = 0; i < data.Length; i++)
				{
					var str = data[i];
					if (macro.Length > 0)
					{
						code.Add(str);
						if (macro.Length > 0 && (m = rx_enddef.Match(str)).Success)
						{
							Macros.Add(macro, string.Join("\r\n", code.ToArray()), file, line);
							macro = string.Empty;
							code.Clear();	
						}
					}
					else if ((m = rx_define.Match(str)).Success)
					{
						macro = m.Groups["name"].Value;
						line = i;
						code.Add(str);
					}
				}
			}
			#endregion
			
			#region Заполнение списка
			tvList.BeginUpdate();
			tvList.Nodes.Clear();
			foreach (MacroData macro in Macros)
			{
				var node = tvList.Nodes.Add(macro.Name);
				node.Tag = macro;
			}
			tvList.Sort();
			tvList.EndUpdate();
			
			// Фильтр
			// TODO: Сделать обработку фильтра и сносный внешний вид для этой менюшки: по дефолту слишком большие отступы.
			tsbFilter.DropDownItems.Clear();
			foreach (string file in files)
			{
				var item = new ToolStripMenuItem()
				{
					Text = Path.GetFileName(file),
					Height = 12,
					CheckOnClick = true
				};
				tsbFilter.DropDownItems.Add(item);
			}
			#endregion
		}

		void Error(string msg)
		{
			MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
