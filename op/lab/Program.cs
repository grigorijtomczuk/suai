namespace lab
{
	internal static class Program
	{
		// ������� ����� � ���������
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			string workingDirectoryPath = @"files\";
			string workingDirectoryName = "files";
			// ���������, ���������� �� ������� ����������
			if (!Directory.Exists(workingDirectoryPath))
			{
				// ������� ������� ����������
				DirectoryClass workingDirectory = new DirectoryClass(workingDirectoryName, workingDirectoryPath);
				workingDirectory.CreateDirectory();
			}
			// ������ ������� ����������
			Directory.SetCurrentDirectory(@"files\");
			Application.Run(new Menu());
		}
	}
}
