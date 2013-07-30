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
			this.btnLoadSave = new System.Windows.Forms.ToolStripButton();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.openSaveFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadSave,
            this.btnSave});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(736, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnLoadSave
			// 
			this.btnLoadSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnLoadSave.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadSave.Image")));
			this.btnLoadSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnLoadSave.Name = "btnLoadSave";
			this.btnLoadSave.Size = new System.Drawing.Size(37, 22);
			this.btnLoadSave.Text = "Load";
			this.btnLoadSave.Click += new System.EventHandler(this.btnLoadSave_Click);
			// 
			// btnSave
			// 
			this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(51, 22);
			this.btnSave.Text = "Save As";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// openSaveFileDialog
			// 
			this.openSaveFileDialog.FileName = "openFileDialog1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(302, 142);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(145, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "load temp_decrypted.dat";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(252, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(242, 128);
			this.label1.TabIndex = 2;
			this.label1.Text = "Currently, there is not much here!  That\'s because this is still being worked on." +
				"\r\n\r\npressing \"load temp_decrypted.dat\" will load the decrypted save data from th" +
				"e local directory.\r\n";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 290);
			this.Controls.Add(this.button1);
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
		private System.Windows.Forms.ToolStripButton btnLoadSave;
		private System.Windows.Forms.OpenFileDialog openSaveFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
	}
}

