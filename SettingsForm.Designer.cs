/******************************
 * Created with SharpDevelop 3.
 * User: F. Phoenix
 * Date: 05.01.2013 14:43
 ******************************/

namespace Macro_Browser
{
	partial class SettingsForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tGamePath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bGamePath = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.bOK = new System.Windows.Forms.Button();
			this.tViewer = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.bViewer = new System.Windows.Forms.Button();
			this.tViewerArgs = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.bViewerArgs = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tGamePath
			// 
			this.tGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tGamePath.Location = new System.Drawing.Point(12, 34);
			this.tGamePath.Name = "tGamePath";
			this.tGamePath.Size = new System.Drawing.Size(388, 20);
			this.tGamePath.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Папка игры";
			// 
			// bGamePath
			// 
			this.bGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bGamePath.Location = new System.Drawing.Point(406, 33);
			this.bGamePath.Name = "bGamePath";
			this.bGamePath.Size = new System.Drawing.Size(24, 22);
			this.bGamePath.TabIndex = 4;
			this.bGamePath.Text = "...";
			this.bGamePath.UseVisualStyleBackColor = true;
			this.bGamePath.Click += new System.EventHandler(this.bGamePath_Click);
			// 
			// bCancel
			// 
			this.bCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(224, 141);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 1;
			this.bCancel.Text = "Отмена";
			this.bCancel.UseVisualStyleBackColor = true;
			// 
			// bOK
			// 
			this.bOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bOK.Location = new System.Drawing.Point(143, 141);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(75, 23);
			this.bOK.TabIndex = 0;
			this.bOK.Text = "OK";
			this.bOK.UseVisualStyleBackColor = true;
			this.bOK.Click += new System.EventHandler(this.bOK_Click);
			// 
			// tViewer
			// 
			this.tViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tViewer.Location = new System.Drawing.Point(12, 83);
			this.tViewer.Name = "tViewer";
			this.tViewer.Size = new System.Drawing.Size(238, 20);
			this.tViewer.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Внешний редактор";
			// 
			// bViewer
			// 
			this.bViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bViewer.Location = new System.Drawing.Point(256, 82);
			this.bViewer.Name = "bViewer";
			this.bViewer.Size = new System.Drawing.Size(24, 22);
			this.bViewer.TabIndex = 7;
			this.bViewer.Text = "...";
			this.bViewer.UseVisualStyleBackColor = true;
			this.bViewer.Click += new System.EventHandler(this.bViewer_Click);
			// 
			// tViewerArgs
			// 
			this.tViewerArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tViewerArgs.Location = new System.Drawing.Point(298, 83);
			this.tViewerArgs.Name = "tViewerArgs";
			this.tViewerArgs.Size = new System.Drawing.Size(102, 20);
			this.tViewerArgs.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(298, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Аргументы";
			// 
			// bViewerArgs
			// 
			this.bViewerArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bViewerArgs.Location = new System.Drawing.Point(406, 82);
			this.bViewerArgs.Name = "bViewerArgs";
			this.bViewerArgs.Size = new System.Drawing.Size(24, 22);
			this.bViewerArgs.TabIndex = 10;
			this.bViewerArgs.Text = "...";
			this.bViewerArgs.UseVisualStyleBackColor = true;
			this.bViewerArgs.Click += new System.EventHandler(this.bViewerArgs_Click);
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.bOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancel;
			this.ClientSize = new System.Drawing.Size(442, 176);
			this.Controls.Add(this.bViewerArgs);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tViewerArgs);
			this.Controls.Add(this.bViewer);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tViewer);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.bGamePath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tGamePath);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Настройки";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button bViewerArgs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tViewerArgs;
		private System.Windows.Forms.Button bViewer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tViewer;
		private System.Windows.Forms.TextBox tGamePath;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bGamePath;
		private System.Windows.Forms.Label label1;
	}
}
