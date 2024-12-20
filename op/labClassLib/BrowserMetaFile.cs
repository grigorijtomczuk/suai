using System.ComponentModel;
using System.Diagnostics;

namespace lab
{
	public class BrowserMetaFile : BrowserFile
	{
		private BrowserTextFile linkedTextFile;

		public BrowserMetaFile(string name, string path, BrowserTextFile linkedFile) : base(name, path)
		{
			linkedTextFile = linkedFile; // Агрегация BrowserMetaFile <-> BrowserTextFile (ссылка на имеющийся объект)
			linkedTextFile.PathChanged += LinkedTextFile_PathChanged; // Подписка на событие
		}

		// Обработчик события изменения пути текстового файла
		private void LinkedTextFile_PathChanged(object sender, BrowserFileSystemItemEventArgs e)
		{
			Debug.WriteLine($"Новый путь текстового файла: {e.NewPath}");
			this.Path = System.IO.Path.ChangeExtension(e.NewPath, ".meta"); // Меняем рабочий путь метафайла на соответсвующий новому пути текстового файла
		}

		public void Write(List<string> authors, string fileType, DateTime dateCreated, bool isReadOnly, string IconPhotoPath)
		{
			using (StreamWriter writer = new StreamWriter(this.Path))
			{
				writer.WriteLine(string.Join(",", authors));
				writer.WriteLine(fileType);
				writer.WriteLine(dateCreated);
				writer.WriteLine(isReadOnly);
				writer.WriteLine(IconPhotoPath);
			}
		}

		public void Read()
		{
			if (!File.Exists(this.Path))
			{
				linkedTextFile.SaveMetadata();
				Read();
			}
			else
			{
				using (StreamReader reader = new StreamReader(this.Path))
				{
					// Здесь, поскольку BindingList является "оберткой" для передаваемого при его инициализации списка,
					// нужно использовать копию списка, чтобы избежать ошибки "Read-Only List" при попытке изменения BindingList
					BindingList<string> parsedAuthors = new BindingList<string>(reader.ReadLine().Split(',').ToList());
					if (parsedAuthors[0] != "") linkedTextFile.Authors = parsedAuthors;

					linkedTextFile.FileTypeProperty = reader.ReadLine();
					linkedTextFile.DateCreated = DateTime.Parse(reader.ReadLine());
					linkedTextFile.IsReadOnly = bool.Parse(reader.ReadLine());
					linkedTextFile.IconPhotoPath = reader.ReadLine();
				}
			}
		}
	}
}
