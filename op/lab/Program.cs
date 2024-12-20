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
				BrowserDirectory workingDirectory = new BrowserDirectory(workingDirectoryName, workingDirectoryPath);
				workingDirectory.Create();
			}
			// Задаем рабочую директорию
			Directory.SetCurrentDirectory(@"files\");
			Application.Run(new Menu());
		}
	}
}
