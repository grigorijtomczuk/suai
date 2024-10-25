using System.ComponentModel;

namespace lab
{
	public partial class Lab4 : Form
	{
		// Объявляем переменную currentFile типа FileClass глобально, так как с ней может проводится сразу несколько манипуляций
		private FileClass? currentFile;
		private BindingList<FileClass> fileList = new BindingList<FileClass>();

		public Lab4()
		{
			InitializeComponent();
			InitializeFiles();
			SetupDataBindings();
		}

		private void InitializeFiles()
		{
			// Создаем тестовые файлы
			for (int i = 0; i < 3; i++)
			{
				FileClass newFile = new FileClass($"file{i}.txt", $"file{i}.txt", "", DateTime.Now, false);
				if (!File.Exists($"file{i}.txt")) newFile.CreateFile();
			}

			// Сканируем рабочую директорию на файлы и добавляем их в список
			foreach (string filePath in Directory.GetFiles(Directory.GetCurrentDirectory()))
			{
				string relativeFilePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);
				FileClass foundFile = new FileClass(Path.GetFileName(relativeFilePath), relativeFilePath, "", DateTime.Now, false);
				fileList.Add(foundFile);
			};

			// Привязка списка файлов к ListBox
			fileListBox.DataSource = fileList;
			fileListBox.DisplayMember = "Name"; // Отображаем имя файла
		}

		private void RefreshListBoxDisplay()
		{
			fileListBox.DisplayMember = null;
			fileListBox.DisplayMember = "Name";
		}

		private void SetupDataBindings()
		{
			// Связка элементов управления с выбранным объектом
			textBox_FilePath.DataBindings.Add("Text", fileList, "Path");
			textBox_FileName.DataBindings.Add("Text", fileList, "Name");
			textBox_FileContents.DataBindings.Add("Text", fileList, "FileContents");
			comboBox_FileType.DataBindings.Add("Text", fileList, "FileTypeProperty");
			dateTime_DateCreated.DataBindings.Add("Value", fileList, "DateCreated");
			checkBox_isReadOnly.DataBindings.Add("Checked", fileList, "IsReadOnly");

			buttonUpdateBoundName.DataBindings.Add("Text", fileList, "Name");
		}

		private void ShowPhotoConditioned(FileClass currentFile)
		{
			if (radioButtonIconInFrame.Checked)
			{
				currentFile.ResetPhoto(this);
				currentFile.ShowPhoto(pictureBox);
			}
			else
			{
				currentFile.ResetPhoto(pictureBox);
				currentFile.ShowPhoto(this);
			}
		}

		private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Синхронизация изменений при выборе файла
			currentFile = (FileClass)fileListBox.SelectedItem;
			if (currentFile != null) labelSelectedFile.Text = currentFile.Path;
			ShowPhotoConditioned(currentFile);
		}

		private void buttonCreateFile_Click(object sender, EventArgs e)
		{
			NewFileDialog newFileDialog = new();
			newFileDialog.MaximizeBox = false;
			newFileDialog.MinimizeBox = false;
			newFileDialog.ShowDialog(this);

			string newFilePath = newFileDialog.submittedFilePath;
			FileClass newFile = new FileClass(Path.GetFileName(newFilePath), newFilePath);
			newFile.CreateFile();
			fileList.Add(newFile);

			MessageBox.Show("Файл создан");
		}

		private void buttonDeleteFile_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				currentFile.DeleteFile();
				textBox_FilePath.Text = null;
				fileList.Remove(currentFile);
				labelSelectedFile.Text = "Файл не выбран";
				currentFile = null;
				MessageBox.Show("Файл удален");
			}
		}

		private void buttonEditFile_Click(object sender, EventArgs e)
		{
			currentFile.RenameFile(currentFile.Name);
			currentFile.EditFile(currentFile.currentFileContents);

			textBox_FileName.Text = currentFile.Name;
			textBox_FilePath.Text = currentFile.Path;
			RefreshListBoxDisplay();

			MessageBox.Show("Файл изменен");
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
				string fileTypeProperty = currentFile.FileTypeProperty;
				string dateCreated = currentFile.DateCreated.ToString();
				string isReadOnly = currentFile.IsReadOnly.ToString();
				string content = $"Тип файла: {fileTypeProperty}\n" +
								 $"Дата создания: {dateCreated}\n" +
								 $"Read-Only: {isReadOnly}";
				MessageBox.Show(content);
			}
		}

		private void buttonUpdatePlainName_Click(object sender, EventArgs e)
		{
			buttonUpdatePlainName.Text = currentFile.Name;
		}

		private void buttonSetIconFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				currentFile.IconPhotoPath = openFileDialog.FileName;
				ShowPhotoConditioned(currentFile);
			}
		}

		private void radioButtonIconInFrame_CheckedChanged(object sender, EventArgs e)
		{
			ShowPhotoConditioned(currentFile);
		}
	}
}
