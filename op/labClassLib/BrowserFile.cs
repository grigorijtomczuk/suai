namespace lab
{
	public class BrowserFile : BrowserFileSystemItem
	{
		public string currentFileContents;
		public string FileContents
		{
			get
			{
				if (currentFileContents == null) return this.ReadFile();
				else return currentFileContents;
			}
			set { currentFileContents = value; }
		}

		public BrowserFile() : base() { }
		public BrowserFile(string name) : base(name) { }
		public BrowserFile(string name, string path) : base(name, path) { }

		public void CreateFile()
		{
			// Получаем директорию файла
			string directoryPath = System.IO.Path.GetDirectoryName(this.Path);

			// Проверяем, существует ли директория
			if (!Directory.Exists(directoryPath))
			{
				// Создаем директорию и все её вложенные папки, если это требуется
				BrowserDirectory currentDirectory = new BrowserDirectory(this.Name, directoryPath);
				currentDirectory.CreateDirectory();
			}

			// Создаем файл, если его нет
			if (!File.Exists(Path))
			{
				File.Create(Path).Close(); // .Close() нужен, чтобы освободить файл сразу после создания
			}
		}

		public void DeleteFile()
		{
			if (File.Exists(Path))
			{
				File.Delete(Path);
			}
		}

		public void RenameFile(string newName)
		{
			Name = newName;
			string newPath = System.IO.Path.GetRelativePath(Directory.GetCurrentDirectory(),
							 System.IO.Path.Join(System.IO.Path.GetDirectoryName(Path), newName));

			if (File.Exists(Path) && !File.Exists(newPath))
			{
				File.Move(Path, newPath);
				Path = newPath;
			}
		}

		public void EditFile(string content)
		{
			if (File.Exists(Path))
			{
				File.WriteAllText(Path, content);
			}
		}

		public void EditFile(SaveFileDialog saveFileDialog, string content)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Path = saveFileDialog.FileName;
				using (StreamWriter writer = new StreamWriter(Path))
				{
					writer.Write(content);
				}
			}
		}

		public string ReadFile()
		{
			if (File.Exists(Path))
			{
				return File.ReadAllText(Path);
			}
			return string.Empty;
		}

		public string ReadFile(OpenFileDialog openFileDialog)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Path = openFileDialog.FileName;
				using (StreamReader reader = new StreamReader(Path))
				{
					return reader.ReadToEnd();
				}
			}
			return null;
		}
	}
}
