namespace lab
{
	partial class Lab6
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
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// textBox_FileName
			// 
			textBox_FileName.Location = new Point(81, 81);
			textBox_FileName.Margin = new Padding(4, 5, 4, 5);
			textBox_FileName.Name = "textBox_FileName";
			textBox_FileName.PlaceholderText = "Имя файла";
			textBox_FileName.Size = new Size(554, 31);
			textBox_FileName.TabIndex = 0;
			// 
			// textBox_FilePath
			// 
			textBox_FilePath.Enabled = false;
			textBox_FilePath.Location = new Point(81, 33);
			textBox_FilePath.Margin = new Padding(4, 5, 4, 5);
			textBox_FilePath.Name = "textBox_FilePath";
			textBox_FilePath.PlaceholderText = "Путь к файлу";
			textBox_FilePath.Size = new Size(554, 31);
			textBox_FilePath.TabIndex = 0;
			// 
			// textBox_FileContents
			// 
			textBox_FileContents.Location = new Point(261, 181);
			textBox_FileContents.Margin = new Padding(4, 5, 4, 5);
			textBox_FileContents.Multiline = true;
			textBox_FileContents.Name = "textBox_FileContents";
			textBox_FileContents.PlaceholderText = "Содержимое файла";
			textBox_FileContents.Size = new Size(614, 400);
			textBox_FileContents.TabIndex = 0;
			// 
			// buttonCreateFile
			// 
			buttonCreateFile.ForeColor = Color.Green;
			buttonCreateFile.Location = new Point(1063, 860);
			buttonCreateFile.Margin = new Padding(4, 5, 4, 5);
			buttonCreateFile.Name = "buttonCreateFile";
			buttonCreateFile.Size = new Size(107, 38);
			buttonCreateFile.TabIndex = 1;
			buttonCreateFile.Text = "Создать";
			buttonCreateFile.UseVisualStyleBackColor = true;
			buttonCreateFile.Click += buttonCreateFile_Click;
			// 
			// buttonDeleteFile
			// 
			buttonDeleteFile.ForeColor = Color.Red;
			buttonDeleteFile.Location = new Point(1179, 860);
			buttonDeleteFile.Margin = new Padding(4, 5, 4, 5);
			buttonDeleteFile.Name = "buttonDeleteFile";
			buttonDeleteFile.Size = new Size(107, 38);
			buttonDeleteFile.TabIndex = 1;
			buttonDeleteFile.Text = "Удалить";
			buttonDeleteFile.UseVisualStyleBackColor = true;
			buttonDeleteFile.Click += buttonDeleteFile_Click;
			// 
			// buttonEditFile
			// 
			buttonEditFile.Location = new Point(16, 860);
			buttonEditFile.Margin = new Padding(4, 5, 4, 5);
			buttonEditFile.Name = "buttonEditFile";
			buttonEditFile.Size = new Size(124, 38);
			buttonEditFile.TabIndex = 1;
			buttonEditFile.Text = "Сохранить";
			buttonEditFile.UseVisualStyleBackColor = true;
			buttonEditFile.Click += buttonEditFile_Click;
			// 
			// buttonReadFile
			// 
			buttonReadFile.Location = new Point(9, 37);
			buttonReadFile.Margin = new Padding(4, 5, 4, 5);
			buttonReadFile.Name = "buttonReadFile";
			buttonReadFile.Size = new Size(231, 38);
			buttonReadFile.TabIndex = 1;
			buttonReadFile.Text = "Прочитать содержание";
			buttonReadFile.UseVisualStyleBackColor = true;
			buttonReadFile.Click += buttonReadFile_Click;
			// 
			// labelSelectedDirectory
			// 
			labelSelectedDirectory.AutoSize = true;
			labelSelectedDirectory.Location = new Point(16, 22);
			labelSelectedDirectory.Margin = new Padding(4, 0, 4, 0);
			labelSelectedDirectory.Name = "labelSelectedDirectory";
			labelSelectedDirectory.Size = new Size(163, 25);
			labelSelectedDirectory.TabIndex = 3;
			labelSelectedDirectory.Text = "Папка не выбрана";
			// 
			// buttonReadFileMetadata
			// 
			buttonReadFileMetadata.Location = new Point(249, 37);
			buttonReadFileMetadata.Margin = new Padding(4, 5, 4, 5);
			buttonReadFileMetadata.Name = "buttonReadFileMetadata";
			buttonReadFileMetadata.Size = new Size(196, 38);
			buttonReadFileMetadata.TabIndex = 5;
			buttonReadFileMetadata.Text = "Прочитать атрибуты";
			buttonReadFileMetadata.UseVisualStyleBackColor = true;
			buttonReadFileMetadata.Click += buttonReadFileMetadata_Click;
			// 
			// dateTime_DateCreated
			// 
			dateTime_DateCreated.Format = DateTimePickerFormat.Short;
			dateTime_DateCreated.Location = new Point(849, 339);
			dateTime_DateCreated.Margin = new Padding(4, 5, 4, 5);
			dateTime_DateCreated.Name = "dateTime_DateCreated";
			dateTime_DateCreated.Size = new Size(180, 31);
			dateTime_DateCreated.TabIndex = 6;
			dateTime_DateCreated.Value = new DateTime(2024, 10, 4, 4, 6, 17, 0);
			// 
			// checkBox_isReadOnly
			// 
			checkBox_isReadOnly.AutoSize = true;
			checkBox_isReadOnly.Location = new Point(849, 380);
			checkBox_isReadOnly.Margin = new Padding(4, 5, 4, 5);
			checkBox_isReadOnly.Name = "checkBox_isReadOnly";
			checkBox_isReadOnly.Size = new Size(121, 29);
			checkBox_isReadOnly.TabIndex = 8;
			checkBox_isReadOnly.Text = "Read-Only";
			checkBox_isReadOnly.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(849, 309);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(129, 25);
			label1.TabIndex = 9;
			label1.Text = "Дата создания";
			// 
			// listBox_Files
			// 
			listBox_Files.FormattingEnabled = true;
			listBox_Files.ItemHeight = 25;
			listBox_Files.Location = new Point(16, 65);
			listBox_Files.Margin = new Padding(4, 5, 4, 5);
			listBox_Files.Name = "listBox_Files";
			listBox_Files.Size = new Size(217, 779);
			listBox_Files.TabIndex = 13;
			listBox_Files.SelectedIndexChanged += fileListBox_SelectedIndexChanged;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(buttonReadFileMetadata);
			groupBox1.Controls.Add(buttonReadFile);
			groupBox1.Location = new Point(243, 627);
			groupBox1.Margin = new Padding(4, 5, 4, 5);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 5, 4, 5);
			groupBox1.Size = new Size(1043, 217);
			groupBox1.TabIndex = 14;
			groupBox1.TabStop = false;
			groupBox1.Text = "Тестирование";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(21, 38);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(54, 25);
			label2.TabIndex = 15;
			label2.Text = "Путь:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(21, 86);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(51, 25);
			label3.TabIndex = 15;
			label3.Text = "Имя:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(849, 241);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(95, 25);
			label4.TabIndex = 15;
			label4.Text = "Тип файла";
			// 
			// comboBox_FileType
			// 
			comboBox_FileType.FormattingEnabled = true;
			comboBox_FileType.Items.AddRange(new object[] { "Plain Text", "Source Code", "Rich Text" });
			comboBox_FileType.Location = new Point(849, 271);
			comboBox_FileType.Margin = new Padding(4, 5, 4, 5);
			comboBox_FileType.Name = "comboBox_FileType";
			comboBox_FileType.Size = new Size(180, 33);
			comboBox_FileType.TabIndex = 16;
			// 
			// pictureBox
			// 
			pictureBox.ImageLocation = "";
			pictureBox.Location = new Point(20, 34);
			pictureBox.Margin = new Padding(4, 5, 4, 5);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(150, 150);
			pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox.TabIndex = 17;
			pictureBox.TabStop = false;
			// 
			// buttonSetIconFile
			// 
			buttonSetIconFile.Location = new Point(851, 84);
			buttonSetIconFile.Margin = new Padding(4, 5, 4, 5);
			buttonSetIconFile.Name = "buttonSetIconFile";
			buttonSetIconFile.Size = new Size(112, 38);
			buttonSetIconFile.TabIndex = 18;
			buttonSetIconFile.Text = "Изменить";
			buttonSetIconFile.UseVisualStyleBackColor = true;
			buttonSetIconFile.Click += buttonSetIconFile_Click;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(pictureBox);
			groupBox2.Location = new Point(645, 21);
			groupBox2.Margin = new Padding(4, 5, 4, 5);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(4, 5, 4, 5);
			groupBox2.Size = new Size(191, 203);
			groupBox2.TabIndex = 19;
			groupBox2.TabStop = false;
			groupBox2.Text = "Иконка";
			// 
			// listBox_FileAuthors
			// 
			listBox_FileAuthors.FormattingEnabled = true;
			listBox_FileAuthors.ItemHeight = 25;
			listBox_FileAuthors.Location = new Point(643, 271);
			listBox_FileAuthors.Margin = new Padding(4, 5, 4, 5);
			listBox_FileAuthors.Name = "listBox_FileAuthors";
			listBox_FileAuthors.Size = new Size(193, 204);
			listBox_FileAuthors.TabIndex = 20;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(643, 241);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(76, 25);
			label5.TabIndex = 9;
			label5.Text = "Авторы";
			// 
			// buttonOpenFile
			// 
			buttonOpenFile.Location = new Point(952, 15);
			buttonOpenFile.Margin = new Padding(4, 5, 4, 5);
			buttonOpenFile.Name = "buttonOpenFile";
			buttonOpenFile.Size = new Size(159, 38);
			buttonOpenFile.TabIndex = 21;
			buttonOpenFile.Text = "Открыть файл";
			buttonOpenFile.UseVisualStyleBackColor = true;
			buttonOpenFile.Click += buttonOpenFile_Click;
			// 
			// buttonEditFileAs
			// 
			buttonEditFileAs.Location = new Point(149, 860);
			buttonEditFileAs.Margin = new Padding(4, 5, 4, 5);
			buttonEditFileAs.Name = "buttonEditFileAs";
			buttonEditFileAs.Size = new Size(157, 38);
			buttonEditFileAs.TabIndex = 22;
			buttonEditFileAs.Text = "Сохранить как";
			buttonEditFileAs.UseVisualStyleBackColor = true;
			buttonEditFileAs.Click += buttonEditFileAs_Click;
			// 
			// buttonFileAuthorsAdd
			// 
			buttonFileAuthorsAdd.Location = new Point(769, 486);
			buttonFileAuthorsAdd.Margin = new Padding(4, 5, 4, 5);
			buttonFileAuthorsAdd.Name = "buttonFileAuthorsAdd";
			buttonFileAuthorsAdd.Size = new Size(30, 30);
			buttonFileAuthorsAdd.TabIndex = 23;
			buttonFileAuthorsAdd.Text = "+";
			buttonFileAuthorsAdd.UseVisualStyleBackColor = true;
			buttonFileAuthorsAdd.Click += buttonFileAuthorsAdd_Click;
			// 
			// buttonFileAuthorsDelete
			// 
			buttonFileAuthorsDelete.Location = new Point(806, 486);
			buttonFileAuthorsDelete.Margin = new Padding(4, 5, 4, 5);
			buttonFileAuthorsDelete.Name = "buttonFileAuthorsDelete";
			buttonFileAuthorsDelete.Size = new Size(30, 30);
			buttonFileAuthorsDelete.TabIndex = 23;
			buttonFileAuthorsDelete.Text = "-";
			buttonFileAuthorsDelete.UseVisualStyleBackColor = true;
			buttonFileAuthorsDelete.Click += buttonFileAuthorsDelete_Click;
			// 
			// textBox_FileAuthorsToAdd
			// 
			textBox_FileAuthorsToAdd.Location = new Point(643, 485);
			textBox_FileAuthorsToAdd.Margin = new Padding(4, 5, 4, 5);
			textBox_FileAuthorsToAdd.Name = "textBox_FileAuthorsToAdd";
			textBox_FileAuthorsToAdd.PlaceholderText = "Автор";
			textBox_FileAuthorsToAdd.Size = new Size(118, 31);
			textBox_FileAuthorsToAdd.TabIndex = 24;
			// 
			// buttonUnsetIconFile
			// 
			buttonUnsetIconFile.Enabled = false;
			buttonUnsetIconFile.Location = new Point(851, 137);
			buttonUnsetIconFile.Name = "buttonUnsetIconFile";
			buttonUnsetIconFile.Size = new Size(112, 34);
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
			groupBox3.Location = new Point(240, 54);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(1045, 549);
			groupBox3.TabIndex = 26;
			groupBox3.TabStop = false;
			groupBox3.Text = "Файл";
			// 
			// buttonOpenDirectory
			// 
			buttonOpenDirectory.Location = new Point(1118, 15);
			buttonOpenDirectory.Name = "buttonOpenDirectory";
			buttonOpenDirectory.Size = new Size(168, 38);
			buttonOpenDirectory.TabIndex = 27;
			buttonOpenDirectory.Text = "Открыть папку";
			buttonOpenDirectory.UseVisualStyleBackColor = true;
			buttonOpenDirectory.Click += buttonOpenDirectory_Click;
			// 
			// Lab6
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1307, 930);
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
			Margin = new Padding(4, 5, 4, 5);
			Name = "Lab6";
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
	}
}