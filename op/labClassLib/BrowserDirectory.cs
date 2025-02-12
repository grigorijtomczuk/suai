using System.Diagnostics;

namespace lab
{
	public class BrowserDirectory : BrowserFileSystemItem, IFileSystemNode
	{
		public int ChildrenCount
		{
			get { return Directory.GetFileSystemEntries(Path).Length; }
		}

		// Переопределение виртуального свойства Description для директорий
		public override string Description
		{
			get { return $"Имя папки: {Name}, путь папки: {Path}, количество элементов: {ChildrenCount}"; }
		}

		public BrowserDirectory() : base() { }
		public BrowserDirectory(string name) : base(name) { }
		public BrowserDirectory(string name, string path) : base(name, path) { }

		public override void Create()
		{
			if (!Directory.Exists(Path) && Path != "")
			{
				Directory.CreateDirectory(Path);
			}
		}

		public override void Delete()
		{
			if (Directory.Exists(Path))
			{
				Directory.Delete(Path, true);
			}
		}

		// Переопределяем абстрактное свойство для директорий
		public override string NodeType => "Directory";

		public override void Rename(string newName)
		{
			Debug.WriteLine("Переименование папки");
			string newPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path), newName);
			if (Directory.Exists(Path))
			{
				Directory.Move(Path, newPath);
				Path = newPath;
			}
		}

		public override string ToString()
		{
			return $"Имя папки: {Name}, путь папки: {Path}, количество элементов: {ChildrenCount}";
		}

		// Коллекция дочерних узлов (файлов и папок)
		public List<BrowserFileSystemItem> Children { get; set; } = new List<BrowserFileSystemItem>();

		// Индексатор для доступа по целочисленному индексу
		public BrowserFileSystemItem this[int index]
		{
			get { return Children[index]; }
			set { Children[index] = value; }
		}

		// Индексатор для доступа по имени дочернего элемента
		public BrowserFileSystemItem this[string name]
		{
			get { return Children.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase)); }
			set
			{
				int idx = Children.FindIndex(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
				if (idx >= 0)
					Children[idx] = value;
			}
		}

		// Индексатор для доступа по двум параметрам: индекс и тип узла
		public BrowserFileSystemItem this[int index, string nodeType]
		{
			get
			{
				var filtered = Children.Where(item => item.NodeType == nodeType).ToList();
				return (index >= 0 && index < filtered.Count) ? filtered[index] : null;
			}
			set
			{
				var filtered = Children.Where(item => item.NodeType == nodeType).ToList();
				if (index >= 0 && index < filtered.Count)
				{
					int origIndex = Children.FindIndex(item => item == filtered[index]);
					if (origIndex != -1)
						Children[origIndex] = value;
				}
			}
		}
	}
}
