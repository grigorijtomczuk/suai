namespace lab
{
	partial class Lab12
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
			labelSelectedDirectory = new Label();
			buttonReadFileMetadata = new Button();
			dateTime_DateCreated = new DateTimePicker();
			checkBox_isReadOnly = new CheckBox();
			label1 = new Label();
			listBox_Files = new ListBox();
			groupBox1 = new GroupBox();
			buttonTestCasting = new Button();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			comboBox_FileType = new ComboBox();
			pictureBox = new PictureBox();
			buttonSetIconFile = new Button();
			groupBox2 = new GroupBox();
			listBox_FileAuthors = new ListBox();
			label5 = new Label();
			buttonOpenFile = new Button();
			buttonEditFileAs = new Button();
			buttonFileAuthorsAdd = new Button();
			buttonFileAuthorsDelete = new Button();
			textBox_FileAuthorsToAdd = new TextBox();
			buttonUnsetIconFile = new Button();
			groupBox3 = new GroupBox();
			buttonOpenDirectory = new Button();
			buttonTestInterface = new Button();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// textBox_FileName
			// 
			textBox_FileName.Location = new Point(97, 97);
			textBox_FileName.Margin = new Padding(5, 6, 5, 6);
			textBox_FileName.Name = "textBox_FileName";
			textBox_FileName.PlaceholderText = "Имя файла";
			textBox_FileName.Size = new Size(664, 35);
			textBox_FileName.TabIndex = 0;
			// 
			// textBox_FilePath
			// 
			textBox_FilePath.Enabled = false;
			textBox_FilePath.Location = new Point(97, 40);
			textBox_FilePath.Margin = new Padding(5, 6, 5, 6);
			textBox_FilePath.Name = "textBox_FilePath";
			textBox_FilePath.PlaceholderText = "Путь к файлу";
			textBox_FilePath.Size = new Size(664, 35);
			textBox_FilePath.TabIndex = 0;
			// 
			// textBox_FileContents
			// 
			textBox_FileContents.Location = new Point(313, 217);
			textBox_FileContents.Margin = new Padding(5, 6, 5, 6);
			textBox_FileContents.Multiline = true;
			textBox_FileContents.Name = "textBox_FileContents";
			textBox_FileContents.PlaceholderText = "Содержимое файла";
			textBox_FileContents.Size = new Size(736, 479);
			textBox_FileContents.TabIndex = 0;
			// 
			// buttonCreateFile
			// 
			buttonCreateFile.ForeColor = Color.Green;
			buttonCreateFile.Location = new Point(1276, 1032);
			buttonCreateFile.Margin = new Padding(5, 6, 5, 6);
			buttonCreateFile.Name = "buttonCreateFile";
			buttonCreateFile.Size = new Size(128, 46);
			buttonCreateFile.TabIndex = 1;
			buttonCreateFile.Text = "Создать";
			buttonCreateFile.UseVisualStyleBackColor = true;
			buttonCreateFile.Click += buttonCreateFile_Click;
			// 
			// buttonDeleteFile
			// 
			buttonDeleteFile.ForeColor = Color.Red;
			buttonDeleteFile.Location = new Point(1415, 1032);
			buttonDeleteFile.Margin = new Padding(5, 6, 5, 6);
			buttonDeleteFile.Name = "buttonDeleteFile";
			buttonDeleteFile.Size = new Size(128, 46);
			buttonDeleteFile.TabIndex = 1;
			buttonDeleteFile.Text = "Удалить";
			buttonDeleteFile.UseVisualStyleBackColor = true;
			buttonDeleteFile.Click += buttonDeleteFile_Click;
			// 
			// buttonEditFile
			// 
			buttonEditFile.Location = new Point(19, 1032);
			buttonEditFile.Margin = new Padding(5, 6, 5, 6);
			buttonEditFile.Name = "buttonEditFile";
			buttonEditFile.Size = new Size(149, 46);
			buttonEditFile.TabIndex = 1;
			buttonEditFile.Text = "Сохранить";
			buttonEditFile.UseVisualStyleBackColor = true;
			buttonEditFile.Click += buttonEditFile_Click;
			// 
			// buttonReadFile
			// 
			buttonReadFile.Location = new Point(11, 44);
			buttonReadFile.Margin = new Padding(5, 6, 5, 6);
			buttonReadFile.Name = "buttonReadFile";
			buttonReadFile.Size = new Size(277, 46);
			buttonReadFile.TabIndex = 1;
			buttonReadFile.Text = "Прочитать содержание";
			buttonReadFile.UseVisualStyleBackColor = true;
			buttonReadFile.Click += buttonReadFile_Click;
			// 
			// labelSelectedDirectory
			// 
			labelSelectedDirectory.AutoSize = true;
			labelSelectedDirectory.Location = new Point(19, 26);
			labelSelectedDirectory.Margin = new Padding(5, 0, 5, 0);
			labelSelectedDirectory.Name = "labelSelectedDirectory";
			labelSelectedDirectory.Size = new Size(191, 30);
			labelSelectedDirectory.TabIndex = 3;
			labelSelectedDirectory.Text = "Папка не выбрана";
			// 
			// buttonReadFileMetadata
			// 
			buttonReadFileMetadata.Location = new Point(299, 44);
			buttonReadFileMetadata.Margin = new Padding(5, 6, 5, 6);
			buttonReadFileMetadata.Name = "buttonReadFileMetadata";
			buttonReadFileMetadata.Size = new Size(235, 46);
			buttonReadFileMetadata.TabIndex = 5;
			buttonReadFileMetadata.Text = "Прочитать атрибуты";
			buttonReadFileMetadata.UseVisualStyleBackColor = true;
			buttonReadFileMetadata.Click += buttonReadFileMetadata_Click;
			// 
			// dateTime_DateCreated
			// 
			dateTime_DateCreated.Format = DateTimePickerFormat.Short;
			dateTime_DateCreated.Location = new Point(1019, 407);
			dateTime_DateCreated.Margin = new Padding(5, 6, 5, 6);
			dateTime_DateCreated.Name = "dateTime_DateCreated";
			dateTime_DateCreated.Size = new Size(215, 35);
			dateTime_DateCreated.TabIndex = 6;
			dateTime_DateCreated.Value = new DateTime(2024, 10, 4, 4, 6, 17, 0);
			// 
			// checkBox_isReadOnly
			// 
			checkBox_isReadOnly.AutoSize = true;
			checkBox_isReadOnly.Location = new Point(1019, 456);
			checkBox_isReadOnly.Margin = new Padding(5, 6, 5, 6);
			checkBox_isReadOnly.Name = "checkBox_isReadOnly";
			checkBox_isReadOnly.Size = new Size(136, 34);
			checkBox_isReadOnly.TabIndex = 8;
			checkBox_isReadOnly.Text = "Read-Only";
			checkBox_isReadOnly.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(1019, 371);
			label1.Margin = new Padding(5, 0, 5, 0);
			label1.Name = "label1";
			label1.Size = new Size(153, 30);
			label1.TabIndex = 9;
			label1.Text = "Дата создания";
			// 
			// listBox_Files
			// 
			listBox_Files.FormattingEnabled = true;
			listBox_Files.ItemHeight = 30;
			listBox_Files.Location = new Point(19, 78);
			listBox_Files.Margin = new Padding(5, 6, 5, 6);
			listBox_Files.Name = "listBox_Files";
			listBox_Files.Size = new Size(260, 934);
			listBox_Files.TabIndex = 13;
			listBox_Files.SelectedIndexChanged += fileListBox_SelectedIndexChanged;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(buttonTestInterface);
			groupBox1.Controls.Add(buttonTestCasting);
			groupBox1.Controls.Add(buttonReadFileMetadata);
			groupBox1.Controls.Add(buttonReadFile);
			groupBox1.Location = new Point(292, 752);
			groupBox1.Margin = new Padding(5, 6, 5, 6);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(5, 6, 5, 6);
			groupBox1.Size = new Size(1252, 260);
			groupBox1.TabIndex = 14;
			groupBox1.TabStop = false;
			groupBox1.Text = "Тестирование";
			// 
			// buttonTestCasting
			// 
			buttonTestCasting.Location = new Point(542, 44);
			buttonTestCasting.Margin = new Padding(4, 4, 4, 4);
			buttonTestCasting.Name = "buttonTestCasting";
			buttonTestCasting.Size = new Size(390, 46);
			buttonTestCasting.TabIndex = 6;
			buttonTestCasting.Text = "Тест UpCasting/DownCasting";
			buttonTestCasting.UseVisualStyleBackColor = true;
			buttonTestCasting.Click += buttonTestCasting_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(25, 46);
			label2.Margin = new Padding(5, 0, 5, 0);
			label2.Name = "label2";
			label2.Size = new Size(63, 30);
			label2.TabIndex = 15;
			label2.Text = "Путь:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(25, 103);
			label3.Margin = new Padding(5, 0, 5, 0);
			label3.Name = "label3";
			label3.Size = new Size(60, 30);
			label3.TabIndex = 15;
			label3.Text = "Имя:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(1019, 289);
			label4.Margin = new Padding(5, 0, 5, 0);
			label4.Name = "label4";
			label4.Size = new Size(113, 30);
			label4.TabIndex = 15;
			label4.Text = "Тип файла";
			// 
			// comboBox_FileType
			// 
			comboBox_FileType.FormattingEnabled = true;
			comboBox_FileType.Items.AddRange(new object[] { "Plain Text", "Source Code", "Rich Text" });
			comboBox_FileType.Location = new Point(1019, 325);
			comboBox_FileType.Margin = new Padding(5, 6, 5, 6);
			comboBox_FileType.Name = "comboBox_FileType";
			comboBox_FileType.Size = new Size(215, 38);
			comboBox_FileType.TabIndex = 16;
			// 
			// pictureBox
			// 
			pictureBox.ImageLocation = "";
			pictureBox.Location = new Point(24, 41);
			pictureBox.Margin = new Padding(5, 6, 5, 6);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(180, 180);
			pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox.TabIndex = 17;
			pictureBox.TabStop = false;
			// 
			// buttonSetIconFile
			// 
			buttonSetIconFile.Location = new Point(1021, 101);
			buttonSetIconFile.Margin = new Padding(5, 6, 5, 6);
			buttonSetIconFile.Name = "buttonSetIconFile";
			buttonSetIconFile.Size = new Size(134, 46);
			buttonSetIconFile.TabIndex = 18;
			buttonSetIconFile.Text = "Изменить";
			buttonSetIconFile.UseVisualStyleBackColor = true;
			buttonSetIconFile.Click += buttonSetIconFile_Click;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(pictureBox);
			groupBox2.Location = new Point(774, 25);
			groupBox2.Margin = new Padding(5, 6, 5, 6);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(5, 6, 5, 6);
			groupBox2.Size = new Size(229, 244);
			groupBox2.TabIndex = 19;
			groupBox2.TabStop = false;
			groupBox2.Text = "Иконка";
			// 
			// listBox_FileAuthors
			// 
			listBox_FileAuthors.FormattingEnabled = true;
			listBox_FileAuthors.ItemHeight = 30;
			listBox_FileAuthors.Location = new Point(772, 325);
			listBox_FileAuthors.Margin = new Padding(5, 6, 5, 6);
			listBox_FileAuthors.Name = "listBox_FileAuthors";
			listBox_FileAuthors.Size = new Size(231, 244);
			listBox_FileAuthors.TabIndex = 20;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(772, 289);
			label5.Margin = new Padding(5, 0, 5, 0);
			label5.Name = "label5";
			label5.Size = new Size(86, 30);
			label5.TabIndex = 9;
			label5.Text = "Авторы";
			// 
			// buttonOpenFile
			// 
			buttonOpenFile.Location = new Point(1142, 18);
			buttonOpenFile.Margin = new Padding(5, 6, 5, 6);
			buttonOpenFile.Name = "buttonOpenFile";
			buttonOpenFile.Size = new Size(191, 46);
			buttonOpenFile.TabIndex = 21;
			buttonOpenFile.Text = "Открыть файл";
			buttonOpenFile.UseVisualStyleBackColor = true;
			buttonOpenFile.Click += buttonOpenFile_Click;
			// 
			// buttonEditFileAs
			// 
			buttonEditFileAs.Location = new Point(179, 1032);
			buttonEditFileAs.Margin = new Padding(5, 6, 5, 6);
			buttonEditFileAs.Name = "buttonEditFileAs";
			buttonEditFileAs.Size = new Size(188, 46);
			buttonEditFileAs.TabIndex = 22;
			buttonEditFileAs.Text = "Сохранить как";
			buttonEditFileAs.UseVisualStyleBackColor = true;
			buttonEditFileAs.Click += buttonEditFileAs_Click;
			// 
			// buttonFileAuthorsAdd
			// 
			buttonFileAuthorsAdd.Location = new Point(923, 583);
			buttonFileAuthorsAdd.Margin = new Padding(5, 6, 5, 6);
			buttonFileAuthorsAdd.Name = "buttonFileAuthorsAdd";
			buttonFileAuthorsAdd.Size = new Size(36, 36);
			buttonFileAuthorsAdd.TabIndex = 23;
			buttonFileAuthorsAdd.Text = "+";
			buttonFileAuthorsAdd.UseVisualStyleBackColor = true;
			buttonFileAuthorsAdd.Click += buttonFileAuthorsAdd_Click;
			// 
			// buttonFileAuthorsDelete
			// 
			buttonFileAuthorsDelete.Location = new Point(967, 583);
			buttonFileAuthorsDelete.Margin = new Padding(5, 6, 5, 6);
			buttonFileAuthorsDelete.Name = "buttonFileAuthorsDelete";
			buttonFileAuthorsDelete.Size = new Size(36, 36);
			buttonFileAuthorsDelete.TabIndex = 23;
			buttonFileAuthorsDelete.Text = "-";
			buttonFileAuthorsDelete.UseVisualStyleBackColor = true;
			buttonFileAuthorsDelete.Click += buttonFileAuthorsDelete_Click;
			// 
			// textBox_FileAuthorsToAdd
			// 
			textBox_FileAuthorsToAdd.Location = new Point(772, 582);
			textBox_FileAuthorsToAdd.Margin = new Padding(5, 6, 5, 6);
			textBox_FileAuthorsToAdd.Name = "textBox_FileAuthorsToAdd";
			textBox_FileAuthorsToAdd.PlaceholderText = "Автор";
			textBox_FileAuthorsToAdd.Size = new Size(141, 35);
			textBox_FileAuthorsToAdd.TabIndex = 24;
			// 
			// buttonUnsetIconFile
			// 
			buttonUnsetIconFile.Enabled = false;
			buttonUnsetIconFile.Location = new Point(1021, 164);
			buttonUnsetIconFile.Margin = new Padding(4, 4, 4, 4);
			buttonUnsetIconFile.Name = "buttonUnsetIconFile";
			buttonUnsetIconFile.Size = new Size(134, 41);
			buttonUnsetIconFile.TabIndex = 25;
			buttonUnsetIconFile.Text = "Удалить";
			buttonUnsetIconFile.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(textBox_FileAuthorsToAdd);
			groupBox3.Controls.Add(buttonUnsetIconFile);
			groupBox3.Controls.Add(buttonFileAuthorsDelete);
			groupBox3.Controls.Add(textBox_FilePath);
			groupBox3.Controls.Add(buttonFileAuthorsAdd);
			groupBox3.Controls.Add(textBox_FileName);
			groupBox3.Controls.Add(label2);
			groupBox3.Controls.Add(label3);
			groupBox3.Controls.Add(listBox_FileAuthors);
			groupBox3.Controls.Add(label5);
			groupBox3.Controls.Add(label4);
			groupBox3.Controls.Add(dateTime_DateCreated);
			groupBox3.Controls.Add(buttonSetIconFile);
			groupBox3.Controls.Add(checkBox_isReadOnly);
			groupBox3.Controls.Add(comboBox_FileType);
			groupBox3.Controls.Add(label1);
			groupBox3.Controls.Add(groupBox2);
			groupBox3.Location = new Point(288, 65);
			groupBox3.Margin = new Padding(4, 4, 4, 4);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(4, 4, 4, 4);
			groupBox3.Size = new Size(1254, 659);
			groupBox3.TabIndex = 26;
			groupBox3.TabStop = false;
			groupBox3.Text = "Файл";
			// 
			// buttonOpenDirectory
			// 
			buttonOpenDirectory.Location = new Point(1342, 18);
			buttonOpenDirectory.Margin = new Padding(4, 4, 4, 4);
			buttonOpenDirectory.Name = "buttonOpenDirectory";
			buttonOpenDirectory.Size = new Size(202, 46);
			buttonOpenDirectory.TabIndex = 27;
			buttonOpenDirectory.Text = "Открыть папку";
			buttonOpenDirectory.UseVisualStyleBackColor = true;
			buttonOpenDirectory.Click += buttonOpenDirectory_Click;
			// 
			// buttonTestInterface
			// 
			buttonTestInterface.Location = new Point(11, 99);
			buttonTestInterface.Name = "buttonTestInterface";
			buttonTestInterface.Size = new Size(328, 40);
			buttonTestInterface.TabIndex = 7;
			buttonTestInterface.Text = "Тест IBrowserFileSystemItem";
			buttonTestInterface.UseVisualStyleBackColor = true;
			buttonTestInterface.Click += buttonTestInterface_Click;
			// 
			// Lab12
			// 
			AutoScaleDimensions = new SizeF(12F, 30F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1568, 1116);
			Controls.Add(buttonOpenDirectory);
			Controls.Add(buttonEditFileAs);
			Controls.Add(buttonOpenFile);
			Controls.Add(listBox_Files);
			Controls.Add(labelSelectedDirectory);
			Controls.Add(buttonEditFile);
			Controls.Add(buttonDeleteFile);
			Controls.Add(buttonCreateFile);
			Controls.Add(textBox_FileContents);
			Controls.Add(groupBox1);
			Controls.Add(groupBox3);
			Margin = new Padding(5, 6, 5, 6);
			Name = "Lab12";
			Text = "ЛР6";
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
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
		private Label labelSelectedDirectory;
		private Button buttonReadFileMetadata;
		private DateTimePicker dateTime_DateCreated;
		private CheckBox checkBox_isReadOnly;
		private Label label1;
		private ListBox listBox_Files;
		private GroupBox groupBox1;
		private Label label2;
		private Label label3;
		private Label label4;
		private ComboBox comboBox_FileType;
		private PictureBox pictureBox;
		private Button buttonSetIconFile;
		private GroupBox groupBox2;
		private ListBox listBox_FileAuthors;
		private Label label5;
		private Button buttonOpenFile;
		private Button buttonEditFileAs;
		private Button buttonFileAuthorsAdd;
		private Button buttonFileAuthorsDelete;
		private TextBox textBox_FileAuthorsToAdd;
		private Button buttonUnsetIconFile;
		private GroupBox groupBox3;
		private Button buttonOpenDirectory;
		private Button buttonTestCasting;
		private Button buttonTestInterface;
	}
}