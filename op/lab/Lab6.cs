using System.ComponentModel;

namespace lab
{
	public partial class Lab6 : Form
	{
		// Объявляем переменную currentFile типа BrowserTextFile глобально, так как с ней может проводится сразу несколько манипуляций
		private BrowserTextFile? currentFile;
		private BindingList<BrowserTextFile> fileList = new BindingList<BrowserTextFile>();

		//private BrowserDirectory? currentDirectory = new BrowserDirectory(Path.GetFileName(Directory.GetCurrentDirectory()), Directory.GetCurrentDirectory());

		public Lab6()
		{
			InitializeComponent();
			CreateTestFiles();
			ScanWorkDirForFiles();
			SetupDataBindings();

			// Убираем изначальный фокус с окна
			this.ActiveControl = label1;
		}

		private void CreateTestFiles()
		{
			// Создаем тестовые файлы
			for (int i = 0; i < 3; i++)
			{
				BrowserTextFile newFile = new BrowserTextFile($"file{i}.txt", $"file{i}.txt", "", DateTime.Now, false);
				if (!File.Exists($"file{i}.txt"))
				{
					newFile.Create();
					newFile.SaveMetadata();
				}
			}
		}

		private void ScanWorkDirForFiles()
		{
			string currentWorkDir = Directory.GetCurrentDirectory();
			labelSelectedDirectory.Text = Path.GetFileName(currentWorkDir) + @"\";

			BindingList<BrowserTextFile> tempFileList = new();

			// Сканируем рабочую директорию на файлы и добавляем их в список
			foreach (string filePath in Directory.GetFiles(currentWorkDir))
			{
				if (Path.GetExtension(filePath) == ".meta") continue;

				string relativeFilePath = Path.GetRelativePath(currentWorkDir, filePath);
				BrowserTextFile foundFile = new BrowserTextFile(Path.GetFileName(relativeFilePath), relativeFilePath, "", DateTime.Now, false);

				foundFile.LoadMetadata();

				tempFileList.Add(foundFile);
			};

			fileList = tempFileList;

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

		private void ClearDataBindings()
		{
			// Связка элементов управления с выбранным объектом
			textBox_FilePath.DataBindings.Clear();
			textBox_FileName.DataBindings.Clear();
			textBox_FileContents.DataBindings.Clear();
			comboBox_FileType.DataBindings.Clear();
			dateTime_DateCreated.DataBindings.Clear();
			checkBox_isReadOnly.DataBindings.Clear();
			listBox_FileAuthors.DataBindings.Clear();
		}

		private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox_Files.SelectedItem != null)
			{
				// Синхронизация изменений при выборе файла
				currentFile = (BrowserTextFile)listBox_Files.SelectedItem;
				currentFile.ShowPhoto(pictureBox);
			}
		}

		private void buttonCreateFile_Click(object sender, EventArgs e)
		{
			NewFileDialog newFileDialog = new();
			newFileDialog.MaximizeBox = false;
			newFileDialog.MinimizeBox = false;
			newFileDialog.ShowDialog(this);

			if (newFileDialog.submittedFilePath != null)
			{
				string newFilePath = newFileDialog.submittedFilePath;
				BrowserTextFile newFile = new BrowserTextFile(Path.GetFileName(newFilePath), newFilePath);
				newFile.Create();
				newFile.SaveMetadata();
				fileList.Add(newFile);

				listBox_Files.ClearSelected();
				currentFile = newFile;
				currentFile.LoadMetadata();
				fileList.ResetBindings();
				listBox_Files.SetSelected(fileList.Count - 1, true);

				MessageBox.Show("Файл создан");
			}
		}

		private void buttonDeleteFile_Click(object sender, EventArgs e)
		{
			if (currentFile == null)
				MessageBox.Show("Файл не выбран");
			else
			{
				currentFile.Delete();
				currentFile.DeleteMetadataFile();
				fileList.Remove(currentFile);
				listBox_Files.SetSelected(0, true);

				MessageBox.Show("Файл удален");
			}
		}

		private void buttonEditFile_Click(object sender, EventArgs e)
		{
			currentFile.Rename(currentFile.Name);
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
				currentFile.ShowPhoto(pictureBox);
			}
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
				BrowserTextFile openedFile = new BrowserTextFile(Path.GetFileName(openFileDialog.FileName), openFileDialog.FileName);
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
			fileList.ResetBindings();
		}

		private void buttonOpenDirectory_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new();
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				Directory.SetCurrentDirectory(folderBrowserDialog.SelectedPath);
				ScanWorkDirForFiles();
				ClearDataBindings();
				SetupDataBindings();
			}
		}
	}
}
