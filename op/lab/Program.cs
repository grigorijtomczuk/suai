namespace lab
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			string workingDirectoryPath = @"files\";
			string workingDirectoryName = "files";
			if (!Directory.Exists(workingDirectoryPath))
			{
				BrowserDirectory workingDirectory = new BrowserDirectory(workingDirectoryName, workingDirectoryPath);
				workingDirectory.Create();
			}
			Directory.SetCurrentDirectory(@"files\");
			Application.Run(new Menu());
		}
	}
}
