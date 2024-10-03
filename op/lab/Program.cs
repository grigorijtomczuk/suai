namespace lab
{
	internal static class Program
	{
		// ¬ходна€ точка в программу
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Menu());
		}
	}
}
