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
			this.SuspendLayout();
			// 
			// tGamePath
			// 
			this.tGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tGamePath.Location = new System.Drawing.Point(12, 34);
			this.tGamePath.Name = "tGamePath";
			this.tGamePath.Size = new System.Drawing.Size(292, 20);
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
			this.bGamePath.Location = new System.Drawing.Point(310, 33);
			this.bGamePath.Name = "bGamePath";
			this.bGamePath.Size = new System.Drawing.Size(30, 22);
			this.bGamePath.TabIndex = 4;
			this.bGamePath.Text = "...";
			this.bGamePath.UseVisualStyleBackColor = true;
			this.bGamePath.Click += new System.EventHandler(this.bGamePath_Click);
			// 
			// bCancel
			// 
			this.bCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(179, 89);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 1;
			this.bCancel.Text = "Отмена";
			this.bCancel.UseVisualStyleBackColor = true;
			// 
			// bOK
			// 
			this.bOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bOK.Location = new System.Drawing.Point(98, 89);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(75, 23);
			this.bOK.TabIndex = 0;
			this.bOK.Text = "OK";
			this.bOK.UseVisualStyleBackColor = true;
			this.bOK.Click += new System.EventHandler(this.bOK_Click);
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.bOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancel;
			this.ClientSize = new System.Drawing.Size(352, 124);
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
		private System.Windows.Forms.TextBox tGamePath;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bGamePath;
		private System.Windows.Forms.Label label1;
	}
}
