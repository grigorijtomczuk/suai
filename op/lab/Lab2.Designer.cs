namespace lab
{
	partial class Lab2
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			textBox_FileName = new TextBox();
			textBox_FilePath = new TextBox();
			textBox_FileContents = new TextBox();
			buttonCreateFile = new Button();
			buttonDeleteFile = new Button();
			buttonRenameFile = new Button();
			buttonEditFile = new Button();
			buttonReadFile = new Button();
			buttonSelectFile = new Button();
			labelSelectedFile = new Label();
			buttonReadHashCode = new Button();
			buttonReadFileMetadata = new Button();
			SuspendLayout();
			// 
			// textBox_FileName
			// 
			textBox_FileName.Location = new Point(11, 41);
			textBox_FileName.Name = "textBox_FileName";
			textBox_FileName.Size = new Size(460, 23);
			textBox_FileName.TabIndex = 0;
			// 
			// textBox_FilePath
			// 
			textBox_FilePath.Location = new Point(12, 12);
			textBox_FilePath.Name = "textBox_FilePath";
			textBox_FilePath.Size = new Size(236, 23);
			textBox_FilePath.TabIndex = 0;
			// 
			// textBox_FileContents
			// 
			textBox_FileContents.Location = new Point(12, 70);
			textBox_FileContents.Multiline = true;
			textBox_FileContents.Name = "textBox_FileContents";
			textBox_FileContents.Size = new Size(460, 117);
			textBox_FileContents.TabIndex = 0;
			// 
			// buttonCreateFile
			// 
			buttonCreateFile.ForeColor = Color.Green;
			buttonCreateFile.Location = new Point(12, 193);
			buttonCreateFile.Name = "buttonCreateFile";
			buttonCreateFile.Size = new Size(75, 23);
			buttonCreateFile.TabIndex = 1;
			buttonCreateFile.Text = "Создать";
			buttonCreateFile.UseVisualStyleBackColor = true;
			buttonCreateFile.Click += buttonCreateFile_Click;
			// 
			// buttonDeleteFile
			// 
			buttonDeleteFile.ForeColor = Color.Red;
			buttonDeleteFile.Location = new Point(93, 193);
			buttonDeleteFile.Name = "buttonDeleteFile";
			buttonDeleteFile.Size = new Size(75, 23);
			buttonDeleteFile.TabIndex = 1;
			buttonDeleteFile.Text = "Удалить";
			buttonDeleteFile.UseVisualStyleBackColor = true;
			buttonDeleteFile.Click += buttonDeleteFile_Click;
			// 
			// buttonRenameFile
			// 
			buttonRenameFile.Location = new Point(174, 193);
			buttonRenameFile.Name = "buttonRenameFile";
			buttonRenameFile.Size = new Size(112, 23);
			buttonRenameFile.TabIndex = 1;
			buttonRenameFile.Text = "Переименовать";
			buttonRenameFile.UseVisualStyleBackColor = true;
			buttonRenameFile.Click += buttonRenameFile_Click;
			// 
			// buttonEditFile
			// 
			buttonEditFile.Location = new Point(292, 193);
			buttonEditFile.Name = "buttonEditFile";
			buttonEditFile.Size = new Size(87, 23);
			buttonEditFile.TabIndex = 1;
			buttonEditFile.Text = "Изменить";
			buttonEditFile.UseVisualStyleBackColor = true;
			buttonEditFile.Click += buttonEditFile_Click;
			// 
			// buttonReadFile
			// 
			buttonReadFile.Location = new Point(385, 193);
			buttonReadFile.Name = "buttonReadFile";
			buttonReadFile.Size = new Size(87, 23);
			buttonReadFile.TabIndex = 1;
			buttonReadFile.Text = "Прочитать";
			buttonReadFile.UseVisualStyleBackColor = true;
			buttonReadFile.Click += buttonReadFile_Click;
			// 
			// buttonSelectFile
			// 
			buttonSelectFile.Location = new Point(254, 12);
			buttonSelectFile.Name = "buttonSelectFile";
			buttonSelectFile.Size = new Size(75, 23);
			buttonSelectFile.TabIndex = 2;
			buttonSelectFile.Text = "Выбрать";
			buttonSelectFile.UseVisualStyleBackColor = true;
			buttonSelectFile.Click += buttonSelectFile_Click;
			// 
			// labelSelectedFile
			// 
			labelSelectedFile.AutoSize = true;
			labelSelectedFile.Location = new Point(335, 16);
			labelSelectedFile.Name = "labelSelectedFile";
			labelSelectedFile.Size = new Size(97, 15);
			labelSelectedFile.TabIndex = 3;
			labelSelectedFile.Text = "Файл не выбран";
			// 
			// buttonReadHashCode
			// 
			buttonReadHashCode.Location = new Point(132, 223);
			buttonReadHashCode.Name = "buttonReadHashCode";
			buttonReadHashCode.Size = new Size(123, 23);
			buttonReadHashCode.TabIndex = 4;
			buttonReadHashCode.Text = "Показать HashCode";
			buttonReadHashCode.UseVisualStyleBackColor = true;
			buttonReadHashCode.Click += buttonReadHashCode_Click;
			// 
			// buttonReadFileMetadata
			// 
			buttonReadFileMetadata.Location = new Point(12, 223);
			buttonReadFileMetadata.Name = "buttonReadFileMetadata";
			buttonReadFileMetadata.Size = new Size(114, 23);
			buttonReadFileMetadata.TabIndex = 5;
			buttonReadFileMetadata.Text = "Атрибуты файла";
			buttonReadFileMetadata.UseVisualStyleBackColor = true;
			buttonReadFileMetadata.Click += buttonReadFileMetadata_Click;
			// 
			// Lab2
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(483, 255);
			Controls.Add(buttonReadFileMetadata);
			Controls.Add(buttonReadHashCode);
			Controls.Add(labelSelectedFile);
			Controls.Add(buttonSelectFile);
			Controls.Add(buttonReadFile);
			Controls.Add(buttonEditFile);
			Controls.Add(buttonRenameFile);
			Controls.Add(buttonDeleteFile);
			Controls.Add(buttonCreateFile);
			Controls.Add(textBox_FileContents);
			Controls.Add(textBox_FilePath);
			Controls.Add(textBox_FileName);
			Name = "Lab2";
			Text = "ЛР2";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox_FileName;
		private TextBox textBox_FilePath;
		private TextBox textBox_FileContents;
		private Button buttonCreateFile;
		private Button buttonDeleteFile;
		private Button buttonRenameFile;
		private Button buttonEditFile;
		private Button buttonReadFile;
		private Button buttonSelectFile;
		private Label labelSelectedFile;
		private Button buttonReadHashCode;
		private Button buttonReadFileMetadata;
	}
}