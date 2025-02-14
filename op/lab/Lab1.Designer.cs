﻿namespace lab
{
	partial class Lab1
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
			dateTime_DateCreated = new DateTimePicker();
			textBox_FileType = new TextBox();
			checkBox_isReadOnly = new CheckBox();
			label1 = new Label();
			buttonReadHashCode = new Button();
			SuspendLayout();
			// 
			// textBox_FileName
			// 
			textBox_FileName.Location = new Point(11, 41);
			textBox_FileName.Name = "textBox_FileName";
			textBox_FileName.PlaceholderText = "Имя файла";
			textBox_FileName.Size = new Size(237, 23);
			textBox_FileName.TabIndex = 0;
			// 
			// textBox_FilePath
			// 
			textBox_FilePath.Location = new Point(12, 12);
			textBox_FilePath.Name = "textBox_FilePath";
			textBox_FilePath.PlaceholderText = "Путь к файлу*";
			textBox_FilePath.Size = new Size(236, 23);
			textBox_FilePath.TabIndex = 0;
			// 
			// textBox_FileContents
			// 
			textBox_FileContents.Location = new Point(12, 99);
			textBox_FileContents.Multiline = true;
			textBox_FileContents.Name = "textBox_FileContents";
			textBox_FileContents.PlaceholderText = "Содержимое файла";
			textBox_FileContents.Size = new Size(460, 88);
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
			// dateTime_DateCreated
			// 
			dateTime_DateCreated.Format = DateTimePickerFormat.Short;
			dateTime_DateCreated.Location = new Point(254, 70);
			dateTime_DateCreated.Name = "dateTime_DateCreated";
			dateTime_DateCreated.Size = new Size(130, 23);
			dateTime_DateCreated.TabIndex = 6;
			dateTime_DateCreated.Value = new DateTime(2024, 10, 4, 4, 6, 17, 0);
			// 
			// textBox_FileType
			// 
			textBox_FileType.Location = new Point(11, 70);
			textBox_FileType.Name = "textBox_FileType";
			textBox_FileType.PlaceholderText = "Тип файла";
			textBox_FileType.Size = new Size(237, 23);
			textBox_FileType.TabIndex = 7;
			// 
			// checkBox_isReadOnly
			// 
			checkBox_isReadOnly.AutoSize = true;
			checkBox_isReadOnly.Location = new Point(390, 72);
			checkBox_isReadOnly.Name = "checkBox_isReadOnly";
			checkBox_isReadOnly.Size = new Size(82, 19);
			checkBox_isReadOnly.TabIndex = 8;
			checkBox_isReadOnly.Text = "Read-Only";
			checkBox_isReadOnly.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(276, 49);
			label1.Name = "label1";
			label1.Size = new Size(85, 15);
			label1.TabIndex = 9;
			label1.Text = "Дата создания";
			// 
			// buttonReadHashCode
			// 
			buttonReadHashCode.Location = new Point(12, 222);
			buttonReadHashCode.Name = "buttonReadHashCode";
			buttonReadHashCode.Size = new Size(123, 23);
			buttonReadHashCode.TabIndex = 10;
			buttonReadHashCode.Text = "Показать HashCode";
			buttonReadHashCode.UseVisualStyleBackColor = true;
			buttonReadHashCode.Click += buttonReadHashCode_Click;
			// 
			// Lab1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(483, 255);
			Controls.Add(buttonReadHashCode);
			Controls.Add(label1);
			Controls.Add(checkBox_isReadOnly);
			Controls.Add(textBox_FileType);
			Controls.Add(dateTime_DateCreated);
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
			Name = "Lab1";
			Text = "ЛР1";
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
		private DateTimePicker dateTime_DateCreated;
		private TextBox textBox_FileType;
		private CheckBox checkBox_isReadOnly;
		private Label label1;
		private Button buttonReadHashCode;
	}
}