namespace lab
{
	public interface IFileSystemNode
	{
		string Name { get; set; }
		string Path { get; set; }
		DateTime DateCreated { get; set; }

		void Create();
		void Delete();
		void Rename(string newName);
		void Move(string newPath);
	}
}
