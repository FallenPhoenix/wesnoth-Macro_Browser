/******************************
 * Created with SharpDevelop 3.
 * User: F. Phoenix
 * Date: 05.01.2013 10:51
 ******************************/

namespace Macro_Browser
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tvList = new System.Windows.Forms.TreeView();
			this.tCode = new System.Windows.Forms.TextBox();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tSearch = new System.Windows.Forms.TextBox();
			this.tsToolBar = new System.Windows.Forms.ToolStrip();
			this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
			this.tsbFilter = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbWordWrap = new System.Windows.Forms.ToolStripButton();
			this.tsbSettings = new System.Windows.Forms.ToolStripButton();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.tsToolBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvList
			// 
			this.tvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tvList.FullRowSelect = true;
			this.tvList.HideSelection = false;
			this.tvList.Location = new System.Drawing.Point(0, 24);
			this.tvList.Name = "tvList";
			this.tvList.ShowLines = false;
			this.tvList.ShowPlusMinus = false;
			this.tvList.ShowRootLines = false;
			this.tvList.Size = new System.Drawing.Size(171, 312);
			this.tvList.TabIndex = 0;
			this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
			// 
			// tCode
			// 
			this.tCode.BackColor = System.Drawing.SystemColors.Window;
			this.tCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tCode.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tCode.Location = new System.Drawing.Point(0, 0);
			this.tCode.Multiline = true;
			this.tCode.Name = "tCode";
			this.tCode.ReadOnly = true;
			this.tCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tCode.Size = new System.Drawing.Size(353, 336);
			this.tCode.TabIndex = 1;
			this.tCode.WordWrap = false;
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(12, 28);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.tSearch);
			this.splitContainer.Panel1.Controls.Add(this.tvList);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.tCode);
			this.splitContainer.Size = new System.Drawing.Size(528, 336);
			this.splitContainer.SplitterDistance = 171;
			this.splitContainer.TabIndex = 2;
			// 
			// tSearch
			// 
			this.tSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.tSearch.Location = new System.Drawing.Point(0, 0);
			this.tSearch.Name = "tSearch";
			this.tSearch.Size = new System.Drawing.Size(171, 20);
			this.tSearch.TabIndex = 1;
			this.tSearch.TextChanged += new System.EventHandler(this.tSearch_TextChanged);
			// 
			// tsToolBar
			// 
			this.tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsbUpdate,
									this.tsbFilter,
									this.tsbWordWrap,
									this.tsbSettings});
			this.tsToolBar.Location = new System.Drawing.Point(0, 0);
			this.tsToolBar.Name = "tsToolBar";
			this.tsToolBar.Size = new System.Drawing.Size(552, 25);
			this.tsToolBar.TabIndex = 3;
			this.tsToolBar.Text = "toolStrip1";
			this.tsToolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsToolBar_ItemClicked);
			// 
			// tsbUpdate
			// 
			this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdate.Image")));
			this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUpdate.Name = "tsbUpdate";
			this.tsbUpdate.Size = new System.Drawing.Size(23, 22);
			this.tsbUpdate.Text = "Обновить макросы";
			// 
			// tsbFilter
			// 
			this.tsbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem1});
			this.tsbFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbFilter.Image")));
			this.tsbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbFilter.Name = "tsbFilter";
			this.tsbFilter.Size = new System.Drawing.Size(29, 22);
			this.tsbFilter.Text = "Фильтр по файлам";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Checked = true;
			this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripMenuItem1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
			this.toolStripMenuItem1.Text = "Отладочный итем";
			// 
			// tsbWordWrap
			// 
			this.tsbWordWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbWordWrap.Image = ((System.Drawing.Image)(resources.GetObject("tsbWordWrap.Image")));
			this.tsbWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbWordWrap.Name = "tsbWordWrap";
			this.tsbWordWrap.Size = new System.Drawing.Size(23, 22);
			this.tsbWordWrap.Text = "Переносить строки кода";
			// 
			// tsbSettings
			// 
			this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
			this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSettings.Name = "tsbSettings";
			this.tsbSettings.Size = new System.Drawing.Size(23, 22);
			this.tsbSettings.Text = "Настройки";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(552, 376);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.tsToolBar);
			this.MinimumSize = new System.Drawing.Size(400, 250);
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Macro Browser";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			this.splitContainer.ResumeLayout(false);
			this.tsToolBar.ResumeLayout(false);
			this.tsToolBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripDropDownButton tsbFilter;
		private System.Windows.Forms.ToolStripButton tsbSettings;
		private System.Windows.Forms.ToolStripButton tsbWordWrap;
		private System.Windows.Forms.ToolStripButton tsbUpdate;
		private System.Windows.Forms.ToolStrip tsToolBar;
		private System.Windows.Forms.TextBox tSearch;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.TextBox tCode;
		private System.Windows.Forms.TreeView tvList;
	}
}
