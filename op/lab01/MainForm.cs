namespace lab01
{
	public partial class MainForm : Form
	{
		private FileClass currentFile;

		public MainForm()
		{
			InitializeComponent();
		}

		private void buttonSelectFile_Click(object sender, EventArgs e)
		{
			currentFile = new FileClass(textBox_FileName.Text, textBox_FilePath.Text);
			if (!File.Exists(currentFile.Path))
				MessageBox.Show("Файла не существует");
			else
			{
				labelSelectedFile.Text = currentFile.Path;
			}
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
	}
}
