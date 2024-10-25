namespace lab
{
	public partial class Lab3 : Form
	{
		// Объявляем переменную currentFile типа FileClass глобально, так как с ней может проводится сразу несколько манипуляций
		private FileClass? currentFile;

		// Создание объекта с помощью конструктора по умолчанию
		FileClass defaultFile = new FileClass();

		// Создание объекта с именем файла
		FileClass namedFile = new FileClass("MyFile.txt");

		// Создание объекта с именем файла и путем
		FileClass fullFile = new FileClass("MyFile.txt", @"MyDir\123\");

		public Lab3()
		{
			InitializeComponent();
			this.BackColor = FileClass.BackgroundColor; // Изменение цвета фона формы
		}

		private void buttonSelectFile_Click(object sender, EventArgs e)
		{
			currentFile = new FileClass(textBox_FileName.Text, textBox_FilePath.Text);
			if (!File.Exists(currentFile.Path))
			{
				currentFile = null;
				MessageBox.Show("Файла не существует");
			}
			else
				labelSelectedFile.Text = currentFile.Path;
		}

		private void buttonCreateFile_Click(object sender, EventArgs e)
		{
			if (textBox_FilePath.Text == "")
				MessageBox.Show("Не указан путь к файлу");
			else
			{
				currentFile = new FileClass(textBox_FileName.Text, textBox_FilePath.Text);
				currentFile.CreateFile();
				labelSelectedFile.Text = currentFile.Path;
				MessageBox.Show("Файл создан");
			}
		}

		private void buttonDeleteFile_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				currentFile.DeleteFile();
				textBox_FilePath.Text = null;
				labelSelectedFile.Text = "Файл не выбран";
				currentFile = null;
				MessageBox.Show("Файл удален");
			}
		}

		private void buttonRenameFile_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				if (textBox_FileName.Text == "")
					MessageBox.Show("Новое имя не указано");
				else
				{
					currentFile.RenameFile(textBox_FileName.Text);
					textBox_FilePath.Text = currentFile.Path;
					labelSelectedFile.Text = currentFile.Path;
					textBox_FileName.Text = null;
					MessageBox.Show("Файл переименован");
				}
			}
		}

		private void buttonEditFile_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				currentFile.EditFile(textBox_FileContents.Text);
				textBox_FileContents.Text = null;
				MessageBox.Show("Файл изменен");
			}
		}

		private void buttonReadFile_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				string content = currentFile.ReadFile();
				MessageBox.Show(content);
			}
		}

		private void buttonChangeFileTypeProperty_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				if (textBox_FileType.Text == "")
					MessageBox.Show("Тип не указан");
				else
				{
					currentFile.ChangeTypeProperty(textBox_FileType.Text);
					textBox_FileType.Text = null;
					MessageBox.Show("Тип файла изменен");
				}
			}
		}

		private void buttonChangeFileTypeField_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				if (textBox_FileType.Text == "")
					MessageBox.Show("Тип не указан");
				else
				{
					currentFile.ChangeTypeField(textBox_FileType.Text);
					textBox_FileType.Text = null;
					MessageBox.Show("Тип файла изменен");
				}
			}
		}

		private void buttonChangeDateCreated_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				currentFile.ChangeDateCreated(dateTime_DateCreated.Value);
				MessageBox.Show("Дата создания файла изменена");
			}
		}

		private void buttonChangeReadOnly_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				currentFile.ChangeReadOnly(checkBox_isReadOnly.Checked);
				MessageBox.Show("Аттрибут \"Read-Only\" изменен");
			}
		}

		private void buttonReadFileMetadata_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				string fileTypeProperty = currentFile.FileTypeProperty;
				string fileTypeField = currentFile.fileTypeField;
				string dateCreated = currentFile.DateCreated.ToString();
				string isReadOnly = currentFile.IsReadOnly.ToString();
				string content = $"Тип файла (свойство): {fileTypeProperty}\n" +
								 $"Тип файла (поле): {fileTypeField}\n" +
								 $"Дата создания: {dateCreated}\n" +
								 $"Read-Only: {isReadOnly}";
				MessageBox.Show(content);
			}
		}
	}
}
