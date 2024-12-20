using System.ComponentModel;

namespace lab
{
	public class BrowserTextFile : BrowserFile
	{
		private BrowserMetaFile linkedMetadataFile;

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

		public BrowserTextFile(string name, string path) : base(name, path)
		{
			string metadataFilePath = System.IO.Path.ChangeExtension(this.Path, ".meta");
			linkedMetadataFile = new BrowserMetaFile(System.IO.Path.GetFileName(metadataFilePath), metadataFilePath, this);
		}
		public BrowserTextFile(string name, string path, string fileType) : this(name, path)
		{
			FileTypeProperty = fileType; // Значение устанавливается в конструкторе
		}
		public BrowserTextFile(string name, string path, string fileType, DateTime dateCreated) : this(name, path, fileType)
		{
			DateCreated = dateCreated;
		}
		public BrowserTextFile(string name, string path, string fileType, DateTime dateCreated, bool isReadOnly) : this(name, path, fileType, dateCreated)
		{
			IsReadOnly = isReadOnly;
		}

		public void CreateTextFile()
		{
			this.CreateFile();

			DateCreated = DateTime.Now;
			FileSize = (int)new FileInfo(Path).Length;
			IsReadOnly = false;
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
			linkedMetadataFile.Write(Authors.ToList(), FileTypeProperty, DateCreated, IsReadOnly);
		}

		public void LoadMetadata()
		{
			linkedMetadataFile.Read();
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
