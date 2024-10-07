namespace lab
{
	public partial class Menu : Form
	{
		public Menu()
		{
			InitializeComponent();
		}

		private void ShowForm(Form form)
		{
			form.MdiParent = this;
			form.MaximizeBox = false;
			form.MinimizeBox = false;
			form.ControlBox = false;
			form.Show();
			form.WindowState = FormWindowState.Maximized;
		}

		private void Lab1MenuItem_Click(object sender, EventArgs e)
		{
			Lab1_1 form = new Lab1_1();
			ShowForm(form);
		}

		private void Lab2MenuItem_Click(object sender, EventArgs e)
		{
			Lab2 form = new Lab2();
			ShowForm(form);
		}

		private void Lab3MenuItem_Click(object sender, EventArgs e)
		{
			Lab3 form = new Lab3();
			ShowForm(form);
		}

		private void Lab4MenuItem_Click(object sender, EventArgs e)
		{
			//Lab4 form = new Lab3();
			//showForm(form);
		}
	}
}
