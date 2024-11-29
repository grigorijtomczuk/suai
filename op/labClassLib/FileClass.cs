using System.ComponentModel;

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

		public BindingList<string> Authors { get; set; } = new BindingList<string>();

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

		public void EditFile(SaveFileDialog saveFileDialog, string content)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
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

		// Сохранение и чтение метаинформации
		public void SaveMetadata()
		{
			string metadataPath = System.IO.Path.ChangeExtension(Path, ".meta");
			using (StreamWriter writer = new StreamWriter(metadataPath))
			{
				writer.WriteLine(string.Join(",", Authors));
				writer.WriteLine(FileTypeProperty);
				writer.WriteLine(DateCreated);
				writer.WriteLine(IsReadOnly);
			}
		}

		public void LoadMetadata()
		{
			string metadataPath = System.IO.Path.ChangeExtension(Path, ".meta");
			if (File.Exists(metadataPath))
			{
				using (StreamReader reader = new StreamReader(metadataPath))
				{
					// Здесь, поскольку BindingList является "оберткой" для передаваемого при его инициализации списка,
					// нужно использовать копию списка, чтобы избежать ошибки "Read-Only List" при попытке изменения BindingList
					BindingList<string> parsedAuthors = new BindingList<string>(reader.ReadLine().Split(',').ToList());
					if (parsedAuthors[0] != "") Authors = parsedAuthors;

					FileTypeProperty = reader.ReadLine();
					DateCreated = DateTime.Parse(reader.ReadLine());
					IsReadOnly = bool.Parse(reader.ReadLine());
				}
			}
			else
			{
				SaveMetadata();
				LoadMetadata();
			}
		}

		// Метод изменения авторов с использованием массива
		public void ChangeAuthors(List<string> newAuthors)
		{
			newAuthors.Add("Добавленный автор");
			Authors = new BindingList<string>(newAuthors);
		}

		// Метод с параметром по ссылке (ref)
		public void ModifyFileType(ref string type)
		{
			type = "Польз.: " + type;
			FileTypeProperty = type;
		}

		// Метод с двумя выходными параметрами (out)
		public void GetFileDetails(out string type, out DateTime creationDate)
		{
			type = FileTypeProperty;
			creationDate = DateCreated;
		}

		// Метод с необязательным параметром
		public void AddAuthor(string authorName = "Неизвестный автор")
		{
			Authors.Add(authorName);
		}
	}
}
