using System.Diagnostics;

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
					OnPathChanged(value); // Вызов виртуального метода, порождающего событие
				}
			}
		}

		public DateTime DateCreated { get; set; } // Свойство даты и времени

		// Виртуальное свойство, возвращающее описание узла файловой системы
		public virtual string Description
		{
			get { return $"Имя узла: {Name}, путь узла: {Path}, дата создания: {DateCreated}"; }
		}

		// Класс аргументов события
		public class PathChangedEventArgs : EventArgs
		{
			public string NewPath { get; }

			public PathChangedEventArgs(string newPath)
			{
				NewPath = newPath;
			}
		}

		// Обработчик и событие, уведомляющее об изменении свойства Path
		public delegate void PathChangedHandler(object sender, PathChangedEventArgs e);
		public event PathChangedHandler PathChanged;

		// Защищённый виртуальный метод для вызова события (можно переопределять в наследниках, чтобы добавить дополнительное поведение)
		protected virtual void OnPathChanged(string newPath)
		{
			PathChanged?.Invoke(this, new PathChangedEventArgs(newPath)); // Вызов события при изменении Path
		}

		// Статический обработчик событий (статическая подписка)
		public static void StaticPathChangedHandler(object sender, BrowserFileSystemItem.PathChangedEventArgs e)
		{
			Debug.WriteLine($"[Static Handler] новый путь = {e.NewPath}");
		}

		// Динамический (экземплярный) обработчик событий
		public void DynamicPathChangedHandler(object sender, BrowserFileSystemItem.PathChangedEventArgs e)
		{
			Debug.WriteLine($"[Dynamic Handler] новый путь = {e.NewPath}");
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

		// Абстрактное свойство, возвращающее тип узла (например, "File" или "Directory")
		public abstract string NodeType { get; }

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

		public override string ToString()
		{
			return $"Имя узла: {Name}, путь узла: {Path}, дата создания: {DateCreated}";
		}
	}
}
