namespace lab
{
	partial class NewFileDialog
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
			buttonCreateFile = new Button();
			textBox_FilePath = new TextBox();
			SuspendLayout();
			// 
			// buttonCreateFile
			// 
			buttonCreateFile.ForeColor = Color.Green;
			buttonCreateFile.Location = new Point(12, 41);
			buttonCreateFile.Name = "buttonCreateFile";
			buttonCreateFile.Size = new Size(75, 23);
			buttonCreateFile.TabIndex = 3;
			buttonCreateFile.Text = "Создать";
			buttonCreateFile.UseVisualStyleBackColor = true;
			buttonCreateFile.Click += buttonCreateFile_Click;
			// 
			// textBox_FilePath
			// 
			textBox_FilePath.Location = new Point(12, 12);
			textBox_FilePath.Name = "textBox_FilePath";
			textBox_FilePath.PlaceholderText = "Относительный путь к файлу";
			textBox_FilePath.Size = new Size(245, 23);
			textBox_FilePath.TabIndex = 2;
			// 
			// NewFileDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(268, 75);
			Controls.Add(buttonCreateFile);
			Controls.Add(textBox_FilePath);
			Name = "NewFileDialog";
			Text = "Создать файл";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button buttonCreateFile;
		private TextBox textBox_FilePath;
	}
}