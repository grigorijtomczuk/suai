using System.ComponentModel;

namespace lab
{
	public partial class Lab5 : Form
	{
		// Объявляем переменную currentFile типа FileClass глобально, так как с ней может проводится сразу несколько манипуляций
		private FileClass? currentFile;
		private BindingList<FileClass> fileList = new BindingList<FileClass>();

		public Lab5()
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
				if (!File.Exists($"file{i}.txt"))
				{
					newFile.CreateFile();
					newFile.SaveMetadata();
				}
			}

			// Сканируем рабочую директорию на файлы и добавляем их в список
			foreach (string filePath in Directory.GetFiles(Directory.GetCurrentDirectory()))
			{
				if (Path.GetExtension(filePath) == ".meta") continue;

				string relativeFilePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);
				FileClass foundFile = new FileClass(Path.GetFileName(relativeFilePath), relativeFilePath, "", DateTime.Now, false);
				foundFile.LoadMetadata();
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
			if (fileListBox.SelectedItem != null)
			{
				// Синхронизация изменений при выборе файла
				currentFile = (FileClass)fileListBox.SelectedItem;
				if (currentFile != null) labelSelectedFile.Text = currentFile.Path;
				ShowPhotoConditioned(currentFile);
				listBox_FileAuthors.DataSource = currentFile.Authors;
			}
		}

		private void buttonCreateFile_Click(object sender, EventArgs e)
		{
			NewFileDialog newFileDialog = new();
			newFileDialog.MaximizeBox = false;
			newFileDialog.MinimizeBox = false;
			newFileDialog.ShowDialog(this);

			// if (submittedFilePath != null) ...
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
			currentFile.EditFile(currentFile.FileContents);

			currentFile.SaveMetadata();

			textBox_FileName.Text = currentFile.Name;
			textBox_FilePath.Text = currentFile.Path;

			if (fileListBox.SelectedItem != null) RefreshListBoxDisplay();

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

		// Метод обновления данных в интерфейсе
		private void UpdateUI()
		{
			listBox_FileAuthors.DataSource = null;
			listBox_FileAuthors.DataSource = currentFile.Authors;
		}

		private void buttonFileAuthorsAdd_Click(object sender, EventArgs e)
		{
			if (textBox_FileAuthorsToAdd.Text != "")
			{
				string authorToAdd = textBox_FileAuthorsToAdd.Text;
				currentFile.AddAuthor(authorToAdd);

				textBox_FileAuthorsToAdd.Text = "";
				UpdateUI();
			}
		}

		private void buttonFileAuthorsDelete_Click(object sender, EventArgs e)
		{
			if (listBox_FileAuthors.SelectedItem != null)
			{
				int selectedIndex = listBox_FileAuthors.SelectedIndex;
				currentFile.Authors.RemoveAt(selectedIndex);
				UpdateUI();
			}
		}

		private void buttonOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				//currentFile = new FileClass(Path.GetFileName(openFileDialog.FileName), openFileDialog.FileName);
				FileClass openedFile = new FileClass(Path.GetFileName(openFileDialog.FileName), openFileDialog.FileName);
				fileList.Add(openedFile);
				fileListBox.SetSelected(fileList.Count - 1, true);
				currentFile.LoadMetadata();

				//labelSelectedFile.Text = currentFile.Path;
				//textBox_FileName.Text = currentFile.Name;
				//textBox_FilePath.Text = currentFile.Path;
				//textBox_FileContents.Text = currentFile.FileContents;

				//fileListBox.ClearSelected();
				UpdateUI();
			}
		}

		private void buttonEditFileAs_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			currentFile.EditFile(saveFileDialog, currentFile.FileContents);
			currentFile.SaveMetadata();
		}

		private void buttonChangeTypeByRef_Click(object sender, EventArgs e)
		{
			string fileType = comboBox_FileType.Text;
			currentFile.ModifyFileType(ref fileType);
			UpdateUI();
		}

		private void buttonReadFileDetails_Click(object sender, EventArgs e)
		{
			currentFile.GetFileDetails(out string type, out DateTime creationDate);
			MessageBox.Show($"Тип файла: {type}\nСоздан: {creationDate}");
		}
	}
}
