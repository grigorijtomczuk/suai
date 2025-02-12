using System.ComponentModel;
using System.Diagnostics;

namespace lab
{
	public sealed class BrowserTextFile : BrowserFile
	{
		private BrowserMetaFile linkedMetadataFile;

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

		public DateTime DateModified { get; set; }

		private Graphics iconGraphics;

		public BindingList<string> Authors { get; set; } = new BindingList<string>();

		public BrowserTextFile(string name, string path) : base(name, path)
		{
			string metadataFilePath = System.IO.Path.ChangeExtension(this.Path, ".meta");
			linkedMetadataFile = new BrowserMetaFile(System.IO.Path.GetFileName(metadataFilePath), metadataFilePath, this); // Композиция BrowserTextFile <-> BrowserMetaFile (новый объект)
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

		// Переопределяем метод Create для определения некоторых параметров текстового файла
		public override void Create()
		{
			base.Create();

			DateCreated = DateTime.Now;
			DateModified = DateCreated;
			FileSize = (int)new FileInfo(Path).Length;
			IsReadOnly = false;
		}

		// public override void Rename() {} - ошибка: метод запрещен для переопределения через sealed.

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
			linkedMetadataFile.Write(Authors.ToList(), FileTypeProperty, DateCreated, IsReadOnly, IconPhotoPath);
		}

		public void LoadMetadata()
		{
			linkedMetadataFile.Read();
		}

		public void DeleteMetadataFile()
		{
			linkedMetadataFile.Delete();
		}

		// Метод изменения авторов с использованием массива
		public void ChangeAuthors(List<string> newAuthors)
		{
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

		// Сокрытие базового метода EditFile (получить доступ к исходному методу можно, выполнив upcasting к базовому классу)
		public new void EditFile(string content)
		{
			if (File.Exists(Path))
			{
				this.DateModified = DateTime.Now;
				File.WriteAllText(Path, content);
			}
		}

		// Переопределяем абстрактное свойство для редактируемых файлов
		public override string NodeType
		{
			get { return $"{System.IO.Path.GetExtension(this.Path)} File"; }
		}

		// Переопределяем метод OnPathChanged для добавления логики
		protected override void OnPathChanged(string newPath)
		{
			Debug.WriteLine($"[BrowserTextFile: {Name}] Путь изменяется на: {newPath}");
			// Вызов базового метода для порождения события
			base.OnPathChanged(newPath);
		}
	}
}
