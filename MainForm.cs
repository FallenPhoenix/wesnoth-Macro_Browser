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
	/// <summary>Description of MainForm.</summary>
	public partial class MainForm : Form
	{
		MacroDataCollection Macros = new MacroDataCollection();
		
		public MainForm(string[] args)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		
		void MainForm_Load(object sender, EventArgs e)
		{
			Settings.Ini = Path.ChangeExtension(Application.ExecutablePath, "ini");
			Settings.Load();
			LoadMacros();
		}
		
		void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Save();
		}
		
		void tsToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			switch (e.ClickedItem.Name)
			{
				case "tsbUpdate": LoadMacros(); break;
				case "tsbWordWrap": tCode.WordWrap = tsbWordWrap.Checked = !tsbWordWrap.Checked; break;
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
			var files = Directory.GetFiles(Settings.MacroDir, "*.cfg");
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
			tsbFilter.DropDownItems.Clear();
			foreach (string file in files)
				tsbFilter.DropDownItems.Add(Path.GetFileName(file));
			#endregion
		}

		void Error(string msg)
		{
			MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
