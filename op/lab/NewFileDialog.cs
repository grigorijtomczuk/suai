namespace lab
{
	public partial class NewFileDialog : Form
	{
		public string submittedFilePath;

		public NewFileDialog()
		{
			InitializeComponent();
		}

		private void buttonCreateFile_Click(object sender, EventArgs e)
		{

			if (textBox_FilePath.Text == "")
				MessageBox.Show("Не указан путь к файлу");
			else
			{
				submittedFilePath = textBox_FilePath.Text;
				this.Close();
			}
		}
	}
}
