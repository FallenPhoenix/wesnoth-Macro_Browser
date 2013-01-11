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
		public SettingsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			NeedRefresh = false;
			tGamePath.Text = Settings.GamePath;
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
		
		void bOK_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(tGamePath.Text)) {MessageBox.Show("Папка игры указана неверно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;}
			
			if (Settings.GamePath != tGamePath.Text)
			{
				Settings.GamePath = tGamePath.Text;
				NeedRefresh = true;
			}
			DialogResult = DialogResult.OK;
		}
	}
}
