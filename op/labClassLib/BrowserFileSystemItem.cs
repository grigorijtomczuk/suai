namespace lab
{
	// Обобщенный класс сущности файловой системы
	public abstract class BrowserFileSystemItem : IFileSystemNode
	{
		public static Color BackgroundColor;

		public string Name { get; set; }

		private string path;
		public string Path
		{
			get => path;
			set
			{
				if (path != value)
				{
					path = value;
					PathChanged?.Invoke(this, new BrowserFileSystemItemEventArgs(value)); // Вызов события при изменении Path
				}
			}
		}

		public DateTime DateCreated { get; set; }

		// Обработчик и событие, уведомляющее об изменении свойства Path
		public delegate void BrowserFileSystemItemHandler(object sender, BrowserFileSystemItemEventArgs e);
		public event BrowserFileSystemItemHandler PathChanged;

		// Класс аргументов события
		public class BrowserFileSystemItemEventArgs : EventArgs
		{
			public string NewPath { get; }

			public BrowserFileSystemItemEventArgs(string newPath)
			{
				NewPath = newPath;
			}
		}

		// Статический конструктор
		static BrowserFileSystemItem()
		{
			// Цвет фона зависит от времени суток
			DateTime now = DateTime.Now;
			if (now.TimeOfDay.Hours >= 12)
				BackgroundColor = Color.FromArgb(-4861441);
			else
				BackgroundColor = Color.FromArgb(-10571);
		}

		// Конструктор по умолчанию
		public BrowserFileSystemItem()
		{
			Name = "NewItem";
			Path = @"NewDirectory\";
		}

		// Перегруженный конструктор с параметрами
		public BrowserFileSystemItem(string name) : this() => Name = name;

		// Перегруженный конструктор с двумя параметрами
		public BrowserFileSystemItem(string name, string path) : this(name) => Path = path;

		// Create, Delete - данные методы абстрактные, так как реализация создания и удаления сущностей ФС (папок и файлов) не имеет ничего общего
		public abstract void Create();
		public abstract void Delete();

		public virtual void Rename(string newName)
		{
			Name = newName;
			// Обновить путь в зависимости от имени
			Path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path), newName);
		}

		public virtual void Move(string newPath)
		{
			Path = newPath;
		}
	}
}
