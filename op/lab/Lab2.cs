namespace lab
{
	public partial class Lab2 : Form
	{
		// Объявляем переменную currentFile типа BrowserTextFile глобально, так как с ней может проводится сразу несколько манипуляций
		private BrowserTextFile? currentFile;

		// Создание объекта с помощью конструктора по умолчанию
		//BrowserTextFile defaultFile = new BrowserTextFile();

		// Создание объекта с именем файла
		//BrowserTextFile namedFile = new BrowserTextFile("MyFile.txt");

		// Создание объекта с именем файла и путем
		BrowserTextFile fullFile = new BrowserTextFile("MyFile.txt", @"MyDir\123\");

		public Lab2()
		{
			InitializeComponent();
			this.BackColor = BrowserTextFile.BackgroundColor; // Изменение цвета фона формы
		}

		private void buttonSelectFile_Click(object sender, EventArgs e)
		{
			currentFile = new BrowserTextFile(textBox_FileName.Text, textBox_FilePath.Text);
			if (!File.Exists(currentFile.Path))
				MessageBox.Show("Файла не существует");
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

		private void buttonReadFileMetadata_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				string fileType = currentFile.FileTypeProperty;
				string dateCreated = currentFile.DateCreated.ToString();
				string content = $"Тип файла: {fileType}\nДата создания: {dateCreated}.";
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
