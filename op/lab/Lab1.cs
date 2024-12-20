namespace lab
{
	public partial class Lab1 : Form
	{
		// Объявляем переменную currentFile типа BrowserTextFile глобально, так как с ней может проводится сразу несколько манипуляций
		private BrowserTextFile? currentFile;

		// Создание объекта с помощью конструктора по умолчанию
		//BrowserTextFile defaultFile = new BrowserTextFile();

		// Создание объекта с именем файла
		//BrowserTextFile namedFile = new BrowserTextFile("MyFile.txt");

		// Создание объекта с именем файла и путем
		BrowserTextFile fullFile = new BrowserTextFile("MyFile.txt", @"MyDir\123\");

		public Lab1()
		{
			InitializeComponent();
		}

		private void buttonSelectFile_Click(object sender, EventArgs e)
		{
			currentFile = new BrowserTextFile(textBox_FileName.Text, textBox_FilePath.Text);
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
				currentFile = new BrowserTextFile(textBox_FileName.Text, textBox_FilePath.Text);
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

		private void buttonChangeFileType_Click(object sender, EventArgs e)
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
				string fileType = currentFile.FileTypeProperty;
				string dateCreated = currentFile.DateCreated.ToString();
				string isReadOnly = currentFile.IsReadOnly.ToString();
				string content = $"Тип файла: {fileType}\n" +
								 $"Дата создания: {dateCreated}\n" +
								 $"Read-Only: {isReadOnly}";
				MessageBox.Show(content);
			}
		}

		// Тестирование методов GetHashCode и ToString базового класса Object
		private void buttonReadHashCode_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				string content = currentFile.GetHashCode().ToString();
				MessageBox.Show(content);
			}
		}
	}
}
