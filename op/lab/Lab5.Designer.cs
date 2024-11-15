namespace lab
{
	partial class Lab5
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
			buttonEditFile = new Button();
			buttonReadFile = new Button();
			labelSelectedFile = new Label();
			buttonReadFileMetadata = new Button();
			dateTime_DateCreated = new DateTimePicker();
			checkBox_isReadOnly = new CheckBox();
			label1 = new Label();
			fileListBox = new ListBox();
			groupBox1 = new GroupBox();
			buttonChangeTypeByRef = new Button();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			comboBox_FileType = new ComboBox();
			pictureBox = new PictureBox();
			buttonSetIconFile = new Button();
			groupBox2 = new GroupBox();
			radioButtonIconInBackground = new RadioButton();
			radioButtonIconInFrame = new RadioButton();
			listBox_FileAuthors = new ListBox();
			label5 = new Label();
			buttonOpenFile = new Button();
			buttonEditFileAs = new Button();
			buttonFileAuthorsAdd = new Button();
			buttonFileAuthorsDelete = new Button();
			textBox_FileAuthorsToAdd = new TextBox();
			buttonReadFileDetails = new Button();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// textBox_FileName
			// 
			textBox_FileName.Location = new Point(211, 68);
			textBox_FileName.Name = "textBox_FileName";
			textBox_FileName.PlaceholderText = "Имя файла";
			textBox_FileName.Size = new Size(195, 23);
			textBox_FileName.TabIndex = 0;
			// 
			// textBox_FilePath
			// 
			textBox_FilePath.Enabled = false;
			textBox_FilePath.Location = new Point(211, 39);
			textBox_FilePath.Name = "textBox_FilePath";
			textBox_FilePath.PlaceholderText = "Путь к файлу";
			textBox_FilePath.Size = new Size(195, 23);
			textBox_FilePath.TabIndex = 0;
			// 
			// textBox_FileContents
			// 
			textBox_FileContents.Location = new Point(170, 126);
			textBox_FileContents.Multiline = true;
			textBox_FileContents.Name = "textBox_FileContents";
			textBox_FileContents.PlaceholderText = "Содержимое файла";
			textBox_FileContents.Size = new Size(352, 179);
			textBox_FileContents.TabIndex = 0;
			// 
			// buttonCreateFile
			// 
			buttonCreateFile.ForeColor = Color.Green;
			buttonCreateFile.Location = new Point(569, 9);
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
			buttonDeleteFile.Location = new Point(650, 9);
			buttonDeleteFile.Name = "buttonDeleteFile";
			buttonDeleteFile.Size = new Size(75, 23);
			buttonDeleteFile.TabIndex = 1;
			buttonDeleteFile.Text = "Удалить";
			buttonDeleteFile.UseVisualStyleBackColor = true;
			buttonDeleteFile.Click += buttonDeleteFile_Click;
			// 
			// buttonEditFile
			// 
			buttonEditFile.Location = new Point(170, 311);
			buttonEditFile.Name = "buttonEditFile";
			buttonEditFile.Size = new Size(87, 23);
			buttonEditFile.TabIndex = 1;
			buttonEditFile.Text = "Сохранить";
			buttonEditFile.UseVisualStyleBackColor = true;
			buttonEditFile.Click += buttonEditFile_Click;
			// 
			// buttonReadFile
			// 
			buttonReadFile.Location = new Point(6, 22);
			buttonReadFile.Name = "buttonReadFile";
			buttonReadFile.Size = new Size(162, 23);
			buttonReadFile.TabIndex = 1;
			buttonReadFile.Text = "Прочитать содержание";
			buttonReadFile.UseVisualStyleBackColor = true;
			buttonReadFile.Click += buttonReadFile_Click;
			// 
			// labelSelectedFile
			// 
			labelSelectedFile.AutoSize = true;
			labelSelectedFile.Location = new Point(11, 13);
			labelSelectedFile.Name = "labelSelectedFile";
			labelSelectedFile.Size = new Size(97, 15);
			labelSelectedFile.TabIndex = 3;
			labelSelectedFile.Text = "Файл не выбран";
			// 
			// buttonReadFileMetadata
			// 
			buttonReadFileMetadata.Location = new Point(174, 22);
			buttonReadFileMetadata.Name = "buttonReadFileMetadata";
			buttonReadFileMetadata.Size = new Size(137, 23);
			buttonReadFileMetadata.TabIndex = 5;
			buttonReadFileMetadata.Text = "Прочитать атрибуты";
			buttonReadFileMetadata.UseVisualStyleBackColor = true;
			buttonReadFileMetadata.Click += buttonReadFileMetadata_Click;
			// 
			// dateTime_DateCreated
			// 
			dateTime_DateCreated.Format = DateTimePickerFormat.Short;
			dateTime_DateCreated.Location = new Point(424, 57);
			dateTime_DateCreated.Name = "dateTime_DateCreated";
			dateTime_DateCreated.Size = new Size(98, 23);
			dateTime_DateCreated.TabIndex = 6;
			dateTime_DateCreated.Value = new DateTime(2024, 10, 4, 4, 6, 17, 0);
			// 
			// checkBox_isReadOnly
			// 
			checkBox_isReadOnly.AutoSize = true;
			checkBox_isReadOnly.Location = new Point(424, 96);
			checkBox_isReadOnly.Name = "checkBox_isReadOnly";
			checkBox_isReadOnly.Size = new Size(82, 19);
			checkBox_isReadOnly.TabIndex = 8;
			checkBox_isReadOnly.Text = "Read-Only";
			checkBox_isReadOnly.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(424, 39);
			label1.Name = "label1";
			label1.Size = new Size(85, 15);
			label1.TabIndex = 9;
			label1.Text = "Дата создания";
			// 
			// fileListBox
			// 
			fileListBox.FormattingEnabled = true;
			fileListBox.ItemHeight = 15;
			fileListBox.Location = new Point(11, 39);
			fileListBox.Name = "fileListBox";
			fileListBox.Size = new Size(153, 499);
			fileListBox.TabIndex = 13;
			fileListBox.SelectedIndexChanged += fileListBox_SelectedIndexChanged;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(buttonReadFileDetails);
			groupBox1.Controls.Add(buttonChangeTypeByRef);
			groupBox1.Controls.Add(buttonReadFileMetadata);
			groupBox1.Controls.Add(buttonReadFile);
			groupBox1.Location = new Point(170, 340);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(352, 198);
			groupBox1.TabIndex = 14;
			groupBox1.TabStop = false;
			groupBox1.Text = "Тестирование";
			// 
			// buttonChangeTypeByRef
			// 
			buttonChangeTypeByRef.Location = new Point(6, 51);
			buttonChangeTypeByRef.Name = "buttonChangeTypeByRef";
			buttonChangeTypeByRef.Size = new Size(131, 23);
			buttonChangeTypeByRef.TabIndex = 6;
			buttonChangeTypeByRef.Text = "Изменить тип по ref";
			buttonChangeTypeByRef.UseVisualStyleBackColor = true;
			buttonChangeTypeByRef.Click += buttonChangeTypeByRef_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(169, 42);
			label2.Name = "label2";
			label2.Size = new Size(36, 15);
			label2.TabIndex = 15;
			label2.Text = "Путь:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(169, 71);
			label3.Name = "label3";
			label3.Size = new Size(34, 15);
			label3.TabIndex = 15;
			label3.Text = "Имя:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(170, 100);
			label4.Name = "label4";
			label4.Size = new Size(30, 15);
			label4.TabIndex = 15;
			label4.Text = "Тип:";
			// 
			// comboBox_FileType
			// 
			comboBox_FileType.FormattingEnabled = true;
			comboBox_FileType.Items.AddRange(new object[] { "Plain Text", "Source Code", "Rich Text" });
			comboBox_FileType.Location = new Point(211, 97);
			comboBox_FileType.Name = "comboBox_FileType";
			comboBox_FileType.Size = new Size(195, 23);
			comboBox_FileType.TabIndex = 16;
			// 
			// pictureBox
			// 
			pictureBox.ImageLocation = "";
			pictureBox.Location = new Point(560, 300);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(136, 136);
			pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox.TabIndex = 17;
			pictureBox.TabStop = false;
			// 
			// buttonSetIconFile
			// 
			buttonSetIconFile.Location = new Point(592, 442);
			buttonSetIconFile.Name = "buttonSetIconFile";
			buttonSetIconFile.Size = new Size(75, 23);
			buttonSetIconFile.TabIndex = 18;
			buttonSetIconFile.Text = "Изменить";
			buttonSetIconFile.UseVisualStyleBackColor = true;
			buttonSetIconFile.Click += buttonSetIconFile_Click;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(radioButtonIconInBackground);
			groupBox2.Controls.Add(radioButtonIconInFrame);
			groupBox2.Location = new Point(529, 471);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(197, 66);
			groupBox2.TabIndex = 19;
			groupBox2.TabStop = false;
			groupBox2.Text = "Отображение";
			// 
			// radioButtonIconInBackground
			// 
			radioButtonIconInBackground.AutoSize = true;
			radioButtonIconInBackground.Location = new Point(6, 37);
			radioButtonIconInBackground.Name = "radioButtonIconInBackground";
			radioButtonIconInBackground.Size = new Size(114, 19);
			radioButtonIconInBackground.TabIndex = 0;
			radioButtonIconInBackground.TabStop = true;
			radioButtonIconInBackground.Text = "На заднем фоне";
			radioButtonIconInBackground.UseVisualStyleBackColor = true;
			// 
			// radioButtonIconInFrame
			// 
			radioButtonIconInFrame.AutoSize = true;
			radioButtonIconInFrame.Checked = true;
			radioButtonIconInFrame.Location = new Point(6, 18);
			radioButtonIconInFrame.Name = "radioButtonIconInFrame";
			radioButtonIconInFrame.Size = new Size(69, 19);
			radioButtonIconInFrame.TabIndex = 0;
			radioButtonIconInFrame.TabStop = true;
			radioButtonIconInFrame.Text = "В рамке";
			radioButtonIconInFrame.UseVisualStyleBackColor = true;
			radioButtonIconInFrame.CheckedChanged += radioButtonIconInFrame_CheckedChanged;
			// 
			// listBox_FileAuthors
			// 
			listBox_FileAuthors.FormattingEnabled = true;
			listBox_FileAuthors.ItemHeight = 15;
			listBox_FileAuthors.Location = new Point(560, 57);
			listBox_FileAuthors.Name = "listBox_FileAuthors";
			listBox_FileAuthors.Size = new Size(136, 199);
			listBox_FileAuthors.TabIndex = 20;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(560, 39);
			label5.Name = "label5";
			label5.Size = new Size(49, 15);
			label5.TabIndex = 9;
			label5.Text = "Авторы";
			// 
			// buttonOpenFile
			// 
			buttonOpenFile.Location = new Point(452, 9);
			buttonOpenFile.Name = "buttonOpenFile";
			buttonOpenFile.Size = new Size(111, 23);
			buttonOpenFile.TabIndex = 21;
			buttonOpenFile.Text = "Открыть файл";
			buttonOpenFile.UseVisualStyleBackColor = true;
			buttonOpenFile.Click += buttonOpenFile_Click;
			// 
			// buttonEditFileAs
			// 
			buttonEditFileAs.Location = new Point(263, 311);
			buttonEditFileAs.Name = "buttonEditFileAs";
			buttonEditFileAs.Size = new Size(110, 23);
			buttonEditFileAs.TabIndex = 22;
			buttonEditFileAs.Text = "Сохранить как";
			buttonEditFileAs.UseVisualStyleBackColor = true;
			buttonEditFileAs.Click += buttonEditFileAs_Click;
			// 
			// buttonFileAuthorsAdd
			// 
			buttonFileAuthorsAdd.Location = new Point(650, 262);
			buttonFileAuthorsAdd.Name = "buttonFileAuthorsAdd";
			buttonFileAuthorsAdd.Size = new Size(21, 23);
			buttonFileAuthorsAdd.TabIndex = 23;
			buttonFileAuthorsAdd.Text = "+";
			buttonFileAuthorsAdd.UseVisualStyleBackColor = true;
			buttonFileAuthorsAdd.Click += buttonFileAuthorsAdd_Click;
			// 
			// buttonFileAuthorsDelete
			// 
			buttonFileAuthorsDelete.Location = new Point(674, 262);
			buttonFileAuthorsDelete.Name = "buttonFileAuthorsDelete";
			buttonFileAuthorsDelete.Size = new Size(22, 23);
			buttonFileAuthorsDelete.TabIndex = 23;
			buttonFileAuthorsDelete.Text = "-";
			buttonFileAuthorsDelete.UseVisualStyleBackColor = true;
			buttonFileAuthorsDelete.Click += buttonFileAuthorsDelete_Click;
			// 
			// textBox_FileAuthorsToAdd
			// 
			textBox_FileAuthorsToAdd.Location = new Point(560, 263);
			textBox_FileAuthorsToAdd.Name = "textBox_FileAuthorsToAdd";
			textBox_FileAuthorsToAdd.PlaceholderText = "Автор";
			textBox_FileAuthorsToAdd.Size = new Size(84, 23);
			textBox_FileAuthorsToAdd.TabIndex = 24;
			// 
			// buttonReadFileDetails
			// 
			buttonReadFileDetails.Location = new Point(143, 51);
			buttonReadFileDetails.Name = "buttonReadFileDetails";
			buttonReadFileDetails.Size = new Size(179, 23);
			buttonReadFileDetails.TabIndex = 7;
			buttonReadFileDetails.Text = "Прочитать детали через out";
			buttonReadFileDetails.UseVisualStyleBackColor = true;
			buttonReadFileDetails.Click += buttonReadFileDetails_Click;
			// 
			// Lab5
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(732, 547);
			Controls.Add(textBox_FileAuthorsToAdd);
			Controls.Add(buttonFileAuthorsDelete);
			Controls.Add(buttonFileAuthorsAdd);
			Controls.Add(buttonEditFileAs);
			Controls.Add(buttonOpenFile);
			Controls.Add(listBox_FileAuthors);
			Controls.Add(groupBox2);
			Controls.Add(buttonSetIconFile);
			Controls.Add(pictureBox);
			Controls.Add(comboBox_FileType);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(fileListBox);
			Controls.Add(label5);
			Controls.Add(label1);
			Controls.Add(checkBox_isReadOnly);
			Controls.Add(dateTime_DateCreated);
			Controls.Add(labelSelectedFile);
			Controls.Add(buttonEditFile);
			Controls.Add(buttonDeleteFile);
			Controls.Add(buttonCreateFile);
			Controls.Add(textBox_FileContents);
			Controls.Add(textBox_FilePath);
			Controls.Add(textBox_FileName);
			Controls.Add(groupBox1);
			Name = "Lab5";
			Text = "ЛР5";
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox_FileName;
		private TextBox textBox_FilePath;
		private TextBox textBox_FileContents;
		private Button buttonCreateFile;
		private Button buttonDeleteFile;
		private Button buttonEditFile;
		private Button buttonReadFile;
		private Label labelSelectedFile;
		private Button buttonReadFileMetadata;
		private DateTimePicker dateTime_DateCreated;
		private CheckBox checkBox_isReadOnly;
		private Label label1;
		private ListBox fileListBox;
		private GroupBox groupBox1;
		private Label label2;
		private Label label3;
		private Label label4;
		private ComboBox comboBox_FileType;
		private PictureBox pictureBox;
		private Button buttonSetIconFile;
		private GroupBox groupBox2;
		private RadioButton radioButtonIconInBackground;
		private RadioButton radioButtonIconInFrame;
		private ListBox listBox_FileAuthors;
		private Label label5;
		private Button buttonOpenFile;
		private Button buttonEditFileAs;
		private Button buttonFileAuthorsAdd;
		private Button buttonFileAuthorsDelete;
		private TextBox textBox_FileAuthorsToAdd;
		private Button buttonChangeTypeByRef;
		private Button buttonReadFileDetails;
	}
}