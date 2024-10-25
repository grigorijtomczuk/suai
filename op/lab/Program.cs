namespace lab
{
	internal static class Program
	{
		// Входная точка в программу
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			string workingDirectoryPath = @"files\";
			string workingDirectoryName = "files";
			// Проверяем, существует ли рабочая директория
			if (!Directory.Exists(workingDirectoryPath))
			{
				// Создаем рабочую директорию
				DirectoryClass workingDirectory = new DirectoryClass(workingDirectoryName, workingDirectoryPath);
				workingDirectory.CreateDirectory();
			}
			// Задаем рабочую директорию
			Directory.SetCurrentDirectory(@"files\");
			Application.Run(new Menu());
		}
	}
}
