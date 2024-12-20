using System.ComponentModel;

namespace lab
{
	public partial class Lab6 : Form
	{
		// Объявляем переменную currentFile типа FileClass глобально, так как с ней может проводится сразу несколько манипуляций
		private FileClass? currentFile;
		private BindingList<FileClass> fileList = new BindingList<FileClass>();

		private DirectoryClass? currentDirectory = new DirectoryClass(Path.GetFileName(Directory.GetCurrentDirectory()), Directory.GetCurrentDirectory());

		public Lab6()
		{
			InitializeComponent();
			CreateTestFiles();
			ScanWorkDirForFiles();
			SetupDataBindings();
		}

		private void CreateTestFiles()
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
		}

		private void ScanWorkDirForFiles()
		{
			string currentWorkDir = Directory.GetCurrentDirectory();
			labelSelectedDirectory.Text = Path.GetFileName(currentWorkDir);

			// Сканируем рабочую директорию на файлы и добавляем их в список
			foreach (string filePath in Directory.GetFiles(currentWorkDir))
			{
				if (Path.GetExtension(filePath) == ".meta") continue;

				string relativeFilePath = Path.GetRelativePath(currentWorkDir, filePath);
				FileClass foundFile = new FileClass(Path.GetFileName(relativeFilePath), relativeFilePath, "", DateTime.Now, false);

				foundFile.LoadMetadata();

				fileList.Add(foundFile);
			};

			// Привязка списка файлов к ListBox
			listBox_Files.DataSource = fileList;
			listBox_Files.DisplayMember = "Name"; // Отображаем имя файла
		}

		private void RefreshListBoxDisplay(ListBox listBox)
		{
			string initialDisplayMember = listBox.DisplayMember;
			listBox.DisplayMember = null;
			listBox.DisplayMember = initialDisplayMember;
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
			listBox_FileAuthors.DataBindings.Add("DataSource", fileList, "Authors");
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
			if (listBox_Files.SelectedItem != null)
			{
				// Синхронизация изменений при выборе файла
				currentFile = (FileClass)listBox_Files.SelectedItem;
				ShowPhotoConditioned(currentFile);
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

			if (listBox_Files.SelectedItem != null) RefreshListBoxDisplay(listBox_Files);

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

		private void buttonFileAuthorsAdd_Click(object sender, EventArgs e)
		{
			if (textBox_FileAuthorsToAdd.Text != "")
			{
				string authorToAdd = textBox_FileAuthorsToAdd.Text;
				currentFile.AddAuthor(authorToAdd);
				textBox_FileAuthorsToAdd.Text = "";
			}
			else
			{
				currentFile.AddAuthor();
			}
		}

		private void buttonFileAuthorsDelete_Click(object sender, EventArgs e)
		{
			if (listBox_FileAuthors.SelectedItem != null)
			{
				int selectedIndex = listBox_FileAuthors.SelectedIndex;
				currentFile.Authors.RemoveAt(selectedIndex);
			}
		}

		private void buttonOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				FileClass openedFile = new FileClass(Path.GetFileName(openFileDialog.FileName), openFileDialog.FileName);
				fileList.Add(openedFile);
				listBox_Files.ClearSelected();
				currentFile = openedFile;
				currentFile.LoadMetadata();
				fileList.ResetBindings();
				listBox_Files.SetSelected(fileList.Count - 1, true);
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
			string initialFileType = fileType;
			currentFile.ModifyFileType(ref fileType);
			MessageBox.Show($"Переданный тип до вызова метода: {initialFileType}\nПереданный тип после вызова метода: {fileType}");
			fileList.ResetBindings();
		}

		private void buttonReadFileDetails_Click(object sender, EventArgs e)
		{
			currentFile.GetFileDetails(out string type, out DateTime creationDate);
			MessageBox.Show($"Тип файла: {type}\nСоздан: {creationDate}");
		}

		private void buttonChangeAuthorsList_Click(object sender, EventArgs e)
		{
			List<string> newAuthors = new(["Автор 1", "Автор 2", "Автор 3"]);
			List<string> initialNewAuthors = newAuthors.ToList();
			currentFile.ChangeAuthors(newAuthors);
			MessageBox.Show($"Переданный список до вызова метода: {String.Join(", ", initialNewAuthors)}\n\nПереданный список после вызова метода: {String.Join(", ", newAuthors)}");
			fileList.ResetBindings();
		}
	}
}
