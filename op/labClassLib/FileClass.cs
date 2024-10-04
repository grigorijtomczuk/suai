namespace lab
{
	public class FileClass : FileSystemItem
	{
		public struct FileMetadata
		{
			// Нельзя инициализировать поля структуры при их объявлении
			public DateTime DateCreated { get; set; } // Свойство даты и времени

			private string fileType;
			public string FileType // Свойство с проверкой на первую прописную букву
			{
				get { return fileType; }
				set
				{
					if (char.IsLower(value[0]))
						fileType = char.ToUpper(value[0]) + value.Substring(1);
					else
						fileType = value;
				}
			}

			// Конструктор с параметрами
			public FileMetadata(string fileType, DateTime dateCreated)
			{
				FileType = fileType;
				DateCreated = dateCreated;
			}

			public void printData() { Console.WriteLine($"Type: {FileType}, Date created: {DateCreated}."); }
		}

		public FileMetadata fileMetadata;

		public int FileSize { private get; set; } // Числовое свойство с ограниченным get (доступ только из класса)

		private bool _isReadOnly;
		public bool IsReadOnly
		{
			get { return _isReadOnly; }
			set { _isReadOnly = value; }
		}

		public FileClass() : base() { }
		public FileClass(string name) : base(name) { }
		public FileClass(string name, string path) : base(name, path) { }
		public FileClass(string name, string path, string fileType) : this(name, path)
		{
			fileMetadata.FileType = fileType; // Значение устанавливается в конструкторе
		}
		public FileClass(string name, string path, string fileType, DateTime dateCreated) : this(name, path, fileType)
		{
			fileMetadata.DateCreated = dateCreated;
		}
		public FileClass(string name, string path, string fileType, DateTime dateCreated, bool isReadOnly) : this(name, path, fileType, dateCreated)
		{
			IsReadOnly = isReadOnly;
		}

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
			fileMetadata.FileType = "Обычный тип";
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

			FileSize = (int)new System.IO.FileInfo(Path).Length;
			IsReadOnly = false;
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

		public void ChangeType(string fileType)
		{
			if (File.Exists(Path))
			{
				fileMetadata.FileType = fileType;
			}
		}

		public void ChangeDateCreated(DateTime dateCreated)
		{
			if (File.Exists(Path))
			{
				fileMetadata.DateCreated = dateCreated;
			}
		}

		public void ChangeReadOnly(bool isReadOnly)
		{
			if (File.Exists(Path))
			{
				IsReadOnly = isReadOnly;
			}
		}
	}
}
