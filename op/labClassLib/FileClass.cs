namespace lab
{
	public class FileClass : FileSystemItem
	{
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

		public DateTime DateCreated { get; set; } // Свойство даты и времени

		private string fileTypeProperty;
		public string FileTypeProperty // Свойство с проверкой на первую прописную букву
		{
			get { return fileTypeProperty; }
			set
			{
				if (value.Length > 0 && char.IsLower(value[0]))
					fileTypeProperty = char.ToUpper(value[0]) + value.Substring(1);
				else
					fileTypeProperty = value;
			}
		}

		public string fileTypeField;

		// Числовое свойство с ограниченным get (доступ только из класса)
		public int FileSize
		{
			private get;
			set;
		}

		private bool isReadOnly;
		public bool IsReadOnly
		{
			get { return isReadOnly; }
			set { isReadOnly = value; }
		}

		private string iconPhotoPath;
		public string IconPhotoPath { get; set; }

		private Graphics iconGraphics;

		public FileClass() : base() { }
		public FileClass(string name) : base(name) { }
		public FileClass(string name, string path) : base(name, path) { }
		public FileClass(string name, string path, string fileType) : this(name, path)
		{
			FileTypeProperty = fileType; // Значение устанавливается в конструкторе
		}
		public FileClass(string name, string path, string fileType, DateTime dateCreated) : this(name, path, fileType)
		{
			DateCreated = dateCreated;
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

			DateCreated = DateTime.Now;

			FileSize = (int)new FileInfo(Path).Length;
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

		public string ReadFile()
		{
			if (File.Exists(Path))
			{
				return File.ReadAllText(Path);
			}
			return string.Empty;
		}

		public void ChangeTypeProperty(string fileType)
		{
			if (File.Exists(Path))
			{
				FileTypeProperty = fileType;
			}
		}

		public void ChangeTypeField(string fileType)
		{
			if (File.Exists(Path))
			{
				fileTypeField = fileType;
			}
		}

		public void ChangeDateCreated(DateTime dateCreated)
		{
			if (File.Exists(Path))
			{
				DateCreated = dateCreated;
			}
		}

		public void ChangeReadOnly(bool isReadOnly)
		{
			if (File.Exists(Path))
			{
				IsReadOnly = isReadOnly;
			}
		}

		public void ShowPhoto(PictureBox pictureBox)
		{
			if (File.Exists(IconPhotoPath))
				pictureBox.Image = Image.FromFile(IconPhotoPath);
			else
				pictureBox.Image = null;
		}

		public void ShowPhoto(Form formBox)
		{
			// formBox.Invalidate(); - перерисовать фон при смене файла
			iconGraphics = Graphics.FromHwnd(formBox.Handle);
			if (File.Exists(IconPhotoPath))
			{
				iconGraphics.DrawImage(Image.FromFile(IconPhotoPath), new Rectangle(0, 0, formBox.Width, formBox.Height));
			}
			else
				formBox.Invalidate();
		}

		public void ResetPhoto(PictureBox pictureBox)
		{
			pictureBox.Image = null;
		}

		public void ResetPhoto(Form formBox)
		{
			formBox.Invalidate();
		}
	}
}
