using System.ComponentModel;
using System.Diagnostics;

namespace lab
{
	public partial class Lab10 : Form
	{
		// Объявляем переменную currentFile типа BrowserTextFile глобально, так как с ней может проводится сразу несколько манипуляций
		private BrowserTextFile? currentFile;
		private BindingList<BrowserTextFile> fileList = new BindingList<BrowserTextFile>();
		private BindingList<BrowserDirectory> dirList = new BindingList<BrowserDirectory>();

		private readonly string rootWorkDirPath = Directory.GetCurrentDirectory();

		private BrowserDirectory currentDirectory = new BrowserDirectory(Path.GetFileName(Directory.GetCurrentDirectory()), Directory.GetCurrentDirectory());

		public Lab10()
		{
			InitializeComponent();
			CreateTestFiles();
			ScanWorkDirForEntries();
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

		private void ScanWorkDirForEntries()
		{
			string currentWorkDir = Directory.GetCurrentDirectory();
			labelSelectedDirectory.Text = Path.GetRelativePath(Path.GetDirectoryName(rootWorkDirPath), currentWorkDir) + @"\";

			BindingList<BrowserTextFile> tempFileList = new();
			BindingList<BrowserDirectory> tempDirList = new();

			// Сканируем рабочую директорию на файлы и добавляем их в список
			foreach (string filePath in Directory.GetFiles(currentWorkDir))
			{
				if (Path.GetExtension(filePath) == ".meta") continue;

				string relativeFilePath = Path.GetRelativePath(currentWorkDir, filePath);
				BrowserTextFile foundFile = new BrowserTextFile(Path.GetFileName(relativeFilePath), relativeFilePath, "", DateTime.Now, false);

				foundFile.LoadMetadata();

				tempFileList.Add(foundFile);
				currentDirectory.Children.Add(foundFile);
			};

			foreach (string dirPath in Directory.GetDirectories(currentWorkDir))
			{
				string relativeDirPath = Path.GetRelativePath(currentWorkDir, dirPath);
				BrowserDirectory foundDirectory = new BrowserDirectory(Path.GetFileName(relativeDirPath), relativeDirPath);

				tempDirList.Add(foundDirectory);
				currentDirectory.Children.Add(foundDirectory);
			}

			fileList = tempFileList;
			dirList = tempDirList;

			// Привязка списка файлов к ListBox
			listBox_Files.DataSource = fileList;
			listBox_Files.DisplayMember = "Name"; // Отображаем имя файла

			listBox_Dirs.DataSource = dirList;
			listBox_Dirs.DisplayMember = "Name";

			listBox_Dirs.ClearSelected();
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
				Debug.WriteLine(currentFile.Description);
			}
		}

		private void listBox_Dirs_DoubleClick(object sender, EventArgs e)
		{
			if (listBox_Dirs.SelectedItem != null)
			{
				BrowserDirectory selectedDir = (BrowserDirectory)listBox_Dirs.SelectedItem;
				Directory.SetCurrentDirectory(selectedDir.Path);
				ScanWorkDirForEntries();
				ClearDataBindings();
				SetupDataBindings();
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
				ScanWorkDirForEntries();
				ClearDataBindings();
				SetupDataBindings();
			}
		}

		private void buttonTestCasting_Click(object sender, EventArgs e)
		{
			// UpCasting - объект BrowserFile (как и объект любого другого класса) представляет объект object
			object obj = new BrowserFile();

			// DownCasting - явно преобразуем объект object к объекту производного класса BrowserFileSystemItem
			BrowserFileSystemItem fsItem = (BrowserFileSystemItem)obj;

			// UpCasting - объект производного класса BrowserFile представляет объект BrowserFileSystemItem
			BrowserFileSystemItem fsItem1 = new BrowserFile();
			// fsItem1.FileContents = "Sample Text"; - Ошибка, так как объекту BrowserFileSystemItem недоступны параметры объекта BrowserFile

			// DownCasting - явно преобразуем объект BrowserFileSystemItem к объекту производного класса BrowserFile
			BrowserFile browserFile = (BrowserFile)fsItem1;
			browserFile.FileContents = "Sample Text"; // Ошибки нет

			string content = $"GetHashCode() у BrowserFile: {browserFile.GetHashCode()}\n" +
							 $"fsItem1: {fsItem1.GetType()}\n" +
							 $"fsItem1.FileContents: Ошибка!\n" +
							 $"browserFile.FileContents: {browserFile.FileContents}";
			MessageBox.Show(content);
		}

		private void buttonResetToRoot_Click(object sender, EventArgs e)
		{
			Directory.SetCurrentDirectory(rootWorkDirPath);
			ScanWorkDirForEntries();
			ClearDataBindings();
			SetupDataBindings();
		}

		private void buttonIdxIndex_Click(object sender, EventArgs e)
		{
			Random r = new Random();
			MessageBox.Show(currentDirectory[r.Next(0, currentDirectory.ChildrenCount - 1)].ToString());
		}

		private void buttonIdxName_Click(object sender, EventArgs e)
		{
			MessageBox.Show(currentDirectory["file0.txt"].ToString());
		}

		private void buttonIdxIndexType_Click(object sender, EventArgs e)
		{
			Random r = new Random();
			MessageBox.Show(currentDirectory[r.Next(0, 3 - 1), ".txt File"].ToString());
		}
	}
}
