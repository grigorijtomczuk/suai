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
	}
}
