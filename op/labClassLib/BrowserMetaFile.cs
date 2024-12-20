using System.ComponentModel;

namespace lab
{
	public class BrowserMetaFile : BrowserFile
	{
		private BrowserTextFile linkedTextFile;

		public BrowserMetaFile(string name, string path, BrowserTextFile linkedFile) : base(name, path)
		{
			linkedTextFile = linkedFile;
		}

		public void Write(List<string> authors, string fileType, DateTime dateCreated, bool isReadOnly)
		{
			using (StreamWriter writer = new StreamWriter(this.Path))
			{
				writer.WriteLine(string.Join(",", authors));
				writer.WriteLine(fileType);
				writer.WriteLine(dateCreated);
				writer.WriteLine(isReadOnly);
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
				}
			}
		}
	}
}
