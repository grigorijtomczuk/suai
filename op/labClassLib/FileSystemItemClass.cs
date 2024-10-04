namespace lab
{
	// Обобщенный класс сущности файловой системы
	public class FileSystemItem
	{
		public string Name { get; set; } // Строковое свойство
		public string Path { get; set; }
		public static Color BackgroundColor;

		// Статический конструктор
		static FileSystemItem()
		{
			// Цвет фона зависит от времени суток
			DateTime now = DateTime.Now;
			if (now.TimeOfDay.Hours >= 12)
				BackgroundColor = Color.LightBlue;
			else
				BackgroundColor = Color.ForestGreen;
		}

		// Конструктор по умолчанию
		public FileSystemItem()
		{
			Name = "NewItem";
			Path = @"TestDirectory\";
		}

		// Перегруженный конструктор с параметрами
		public FileSystemItem(string name) : this() => Name = name;

		// Перегруженный конструктор с двумя параметрами
		public FileSystemItem(string name, string path) : this(name) => Path = path;
	}
}
