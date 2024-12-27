namespace lab
{
	public class BrowserDirectory : BrowserFileSystemItem, IFileSystemNode
	{
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

		public override void Rename(string newName)
		{
			string newPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path), newName);
			if (Directory.Exists(Path))
			{
				Directory.Move(Path, newPath);
				Path = newPath;
			}
		}
	}
}
