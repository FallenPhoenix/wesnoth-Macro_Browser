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
		// TODO: Сделать выпадающий список переменных для аргументов.
		public SettingsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
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
