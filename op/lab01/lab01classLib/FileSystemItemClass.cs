namespace lab01
{
	// Обобщенный класс сущности файловой системы
	public class FileSystemItem
	{
		public string Name;
		public string Path;

		public FileSystemItem(string name, string path)
		{
			this.Name = name;
			this.Path = path;
		}
	}
}
