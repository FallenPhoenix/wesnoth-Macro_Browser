/******************************
 * Created with SharpDevelop 3.
 * User: F. Phoenix
 * Date: 05.01.2013 14:43
 ******************************/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Macro_Browser
{
	/// <summary> Окно настроек. </summary>
	public partial class SettingsForm : Form
	{
		ToolStripDropDown tsdViewerArgs;
		
		public SettingsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			tsdViewerArgs = new ToolStripDropDown();
			tsdViewerArgs.Items.AddRange(new[]{
				new ToolStripButton(){Name = "%f", Text = "%f - Файл макроса"},
				new ToolStripButton(){Name = "%l", Text = "%l - Номер строки"}
			});
			tsdViewerArgs.ItemClicked += new ToolStripItemClickedEventHandler(tsdViewerArgs_ItemClicked);
			tsdViewerArgs.Closed += new ToolStripDropDownClosedEventHandler(tsdViewerArgs_Closed);
			
			NeedRefresh = false;
			tGamePath.Text = Settings.GamePath;
			tViewer.Text = Settings.Viewer;
			tViewerArgs.Text = Settings.ViewerArgs;
		}
		
		
		/// <summary> Указывает, что по закрытию этого диалога нужно перечитать данные макросов. </summary>
		public bool NeedRefresh {get; private set;}
		
		
		void bGamePath_Click(object sender, EventArgs e)
		{
			var fb = new FolderBrowserDialog()
			{
				Description = "Укажите корневую папку игры.",
				SelectedPath = tGamePath.Text
			};
			if (fb.ShowDialog() == DialogResult.OK) tGamePath.Text = fb.SelectedPath;
		}
		
		void bViewer_Click(object sender, EventArgs e)
		{
			var of = new OpenFileDialog()
			{
				Title = "Программа просмотра",
				Filter = "Программы (*.exe)|*.exe",
				FileName = tViewer.Text
			};
			if (of.ShowDialog() == DialogResult.OK) tViewer.Text = of.FileName;
		}
		
		void bViewerArgs_Click(object sender, EventArgs e)
		{
			tViewerArgs.HideSelection = (tViewerArgs.SelectionLength == 0);
			//tsdViewerArgs.Show(bViewerArgs, bViewerArgs.Width + 2, 0);
			tsdViewerArgs.Show(bViewerArgs, new Point(bViewerArgs.Width, bViewerArgs.Height + 2), ToolStripDropDownDirection.BelowLeft);
		}
		
		void tsdViewerArgs_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			tViewerArgs.Text = tViewerArgs.Text.Remove(tViewerArgs.SelectionStart, tViewerArgs.SelectionLength).Insert(tViewerArgs.SelectionStart, e.ClickedItem.Name);
		}
		
		void tsdViewerArgs_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			tViewerArgs.HideSelection = true;
		}
		
		void bOK_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(tGamePath.Text)) {tGamePath.Select(); MessageBox.Show("Папка игры указана неверно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;}
			if (tViewer.Text.Length > 0 && !File.Exists(tViewer.Text)) {tViewer.Select(); MessageBox.Show("Неверно указан путь к внешнему текстовому редактору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;}
			
			if (Settings.GamePath != tGamePath.Text)
			{
				Settings.GamePath = tGamePath.Text;
				NeedRefresh = true;
			}
			Settings.Viewer = tViewer.Text;
			Settings.ViewerArgs = tViewerArgs.Text;
			
			DialogResult = DialogResult.OK;
		}
	}
}
