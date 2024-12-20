namespace lab
{
	public class BrowserDirectory : BrowserFileSystemItem
	{
		public BrowserDirectory() : base() { }
		public BrowserDirectory(string name) : base(name) { }
		public BrowserDirectory(string name, string path) : base(name, path) { }

		public void CreateDirectory()
		{
			if (!Directory.Exists(Path) && Path != "")
			{
				Directory.CreateDirectory(Path);
			}
		}

		public void DeleteDirectory()
		{
			if (Directory.Exists(Path))
			{
				Directory.Delete(Path, true);
			}
		}

		public void RenameDirectory(string newName)
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
