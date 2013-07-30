namespace PaydaySaveEditor
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.encryptedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.decryptedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.encryptedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.decryptedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSaveFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(736, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encryptedToolStripMenuItem1,
            this.decryptedToolStripMenuItem1});
			this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
			this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(65, 22);
			this.toolStripDropDownButton2.Text = "Open";
			// 
			// encryptedToolStripMenuItem1
			// 
			this.encryptedToolStripMenuItem1.Name = "encryptedToolStripMenuItem1";
			this.encryptedToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.encryptedToolStripMenuItem1.Text = "Encrypted";
			this.encryptedToolStripMenuItem1.Click += new System.EventHandler(this.encryptedToolStripMenuItem1_Click);
			// 
			// decryptedToolStripMenuItem1
			// 
			this.decryptedToolStripMenuItem1.Name = "decryptedToolStripMenuItem1";
			this.decryptedToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.decryptedToolStripMenuItem1.Text = "Decrypted";
			this.decryptedToolStripMenuItem1.Click += new System.EventHandler(this.decryptedToolStripMenuItem1_Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encryptedToolStripMenuItem,
            this.decryptedToolStripMenuItem});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 22);
			this.toolStripDropDownButton1.Text = "Save";
			// 
			// encryptedToolStripMenuItem
			// 
			this.encryptedToolStripMenuItem.Name = "encryptedToolStripMenuItem";
			this.encryptedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.encryptedToolStripMenuItem.Text = "Encrypted";
			this.encryptedToolStripMenuItem.Click += new System.EventHandler(this.encryptedToolStripMenuItem_Click);
			// 
			// decryptedToolStripMenuItem
			// 
			this.decryptedToolStripMenuItem.Name = "decryptedToolStripMenuItem";
			this.decryptedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.decryptedToolStripMenuItem.Text = "Decrypted";
			this.decryptedToolStripMenuItem.Click += new System.EventHandler(this.decryptedToolStripMenuItem_Click);
			// 
			// openSaveFileDialog
			// 
			this.openSaveFileDialog.FileName = "openFileDialog1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(251, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(242, 128);
			this.label1.TabIndex = 2;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 290);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "PAYDAY 2 Save Editor";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.OpenFileDialog openSaveFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem encryptedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem decryptedToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.ToolStripMenuItem encryptedToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem decryptedToolStripMenuItem1;
	}
}

