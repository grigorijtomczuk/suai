using System.Diagnostics;

namespace lab
{
	public class BrowserFile : BrowserFileSystemItem, IFileSystemNode
	{
		public BrowserDirectory FileDirectory { get; set; } // Ассоциация BrowserFile -> BrowserDirectory (каждый файл в ФС содержится в какой-то одной директории)

		public string currentFileContents;
		public string FileContents
		{
			get
			{
				if (currentFileContents == null) return this.ReadFile();
				else return currentFileContents;
			}
			set { currentFileContents = value; }
		}

		// Переопределение виртуального свойства Description для файлов
		public override string Description
		{
			get { return $"Имя файла: {Name}, путь файла: {Path}, содержание: {FileContents}"; }
		}

		public BrowserFile() : base() { }
		public BrowserFile(string name) : base(name) { }
		public BrowserFile(string name, string path) : base(name, path) { }

		public override void Create()
		{
			// Получаем директорию файла
			string directoryPath = System.IO.Path.GetDirectoryName(this.Path);

			// Проверяем, существует ли директория
			if (!Directory.Exists(directoryPath))
			{
				// Создаем директорию и все её вложенные папки, если это требуется
				BrowserDirectory currentDirectory = new BrowserDirectory(this.Name, directoryPath);
				currentDirectory.Create();
			}

			// Создаем файл, если его нет
			if (!File.Exists(Path))
			{
				File.Create(Path).Close(); // .Close() нужен, чтобы освободить файл сразу после создания
			}
		}

		public override void Delete()
		{
			if (File.Exists(Path))
			{
				File.Delete(Path);
			}
		}

		// Переопределяем абстрактное свойство для файлов
		public override string NodeType => "File";

		// Переопределенный метод с запретом на дальнейшее переопределение (дальнейшие производные классы не смогут изменить реализацию, что гарантирует неизменность критически важной логики переименования)
		public override sealed void Rename(string newName)
		{
			Debug.WriteLine("Переименование файла");
			Name = newName;
			string newPath = System.IO.Path.GetRelativePath(Directory.GetCurrentDirectory(),
							 System.IO.Path.Join(System.IO.Path.GetDirectoryName(Path), newName));

			if (File.Exists(Path) && !File.Exists(newPath))
			{
				File.Move(Path, newPath);
				Path = newPath;
			}
		}

		public void EditFile(string content)
		{
			if (File.Exists(Path))
			{
				File.WriteAllText(Path, content);
			}
		}

		public void EditFile(SaveFileDialog saveFileDialog, string content)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Name = System.IO.Path.GetFileName(saveFileDialog.FileName);
				Path = saveFileDialog.FileName;
				using (StreamWriter writer = new StreamWriter(Path))
				{
					writer.Write(content);
				}
			}
		}

		public string ReadFile()
		{
			if (File.Exists(Path))
			{
				return File.ReadAllText(Path);
			}
			return string.Empty;
		}

		public string ReadFile(OpenFileDialog openFileDialog)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Path = openFileDialog.FileName;
				using (StreamReader reader = new StreamReader(Path))
				{
					return reader.ReadToEnd();
				}
			}
			return null;
		}

		public override string ToString()
		{
			return $"Имя файла: {Name}, путь файла: {Path}, содержание: {FileContents}";
		}
	}
}
