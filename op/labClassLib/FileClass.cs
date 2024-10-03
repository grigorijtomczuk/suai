namespace lab
{
	public class FileClass : FileSystemItem
	{
		public FileClass() : base() { }
		public FileClass(string name) : base(name) { }
		public FileClass(string name, string path) : base(name, path) { }

		public struct FileMetadata
		{
			// Нельзя инициализировать поля структуры при их объявлении
			public string FileType;
			public DateTime DateCreated;

			// Конструктор с параметрами
			public FileMetadata(string fileType, DateTime dateCreated)
			{
				FileType = fileType;
				DateCreated = dateCreated;
			}

			public void printData() { Console.WriteLine($"Type: {FileType}, Date created: {DateCreated}."); }
		}

		public FileMetadata fileMetadata;

		public void CreateFile()
		{
			// Получаем директорию файла
			string directoryPath = System.IO.Path.GetDirectoryName(this.Path);

			// Проверяем, существует ли директория
			if (!Directory.Exists(directoryPath))
			{
				// Создаем директорию и все её вложенные папки, если это требуется
				DirectoryClass currentDirectory = new DirectoryClass(this.Name, directoryPath);
				currentDirectory.CreateDirectory();
			}

			// Создаем файл, если его нет
			if (!File.Exists(Path))
			{
				File.Create(Path).Close(); // .Close() нужен, чтобы освободить файл сразу после создания
			}

			// Присваивание атрибутов через структуру FileMetadata
			fileMetadata.FileType = "Test Type";
			fileMetadata.DateCreated = DateTime.Now;
			fileMetadata.printData();

			// Тестирование конструктора по умолчанию для структуры
			FileMetadata defaultFileMetadataStruct = new FileMetadata(); // Все поля проинициализированы значениями по умолчанию
			defaultFileMetadataStruct.printData();
			//fileMetadata = defaultFileMetadataStruct;

			FileMetadata paramFileMetadataStruct = new FileMetadata("Custom Type Parameter", DateTime.Now); // Инициализация с параметрами
			paramFileMetadataStruct.printData();
			//fileMetadata = paramFileMetadataStruct;

			// Использование инициализаторов со структурами
			FileMetadata fileMetadataStructWithInitializer = new FileMetadata
			{
				FileType = "Custom Initializer Type",
				DateCreated = DateTime.Now
			};
			fileMetadataStructWithInitializer.printData();
			//fileMetadata = fileMetadataStructWithInitializer;
		}

		public void DeleteFile()
		{
			if (File.Exists(Path))
			{
				File.Delete(Path);
			}
		}

		public void RenameFile(string newName)
		{
			Name = newName;
			string newPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path), newName);
			if (File.Exists(Path))
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

		public string ReadFile()
		{
			if (File.Exists(Path))
			{
				return File.ReadAllText(Path);
			}
			return string.Empty;
		}
	}
}
