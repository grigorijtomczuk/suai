﻿namespace lab
{
	public partial class Menu : Form
	{
		Form? currentForm;

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

			this.Width = form.Width;
			this.Height = form.Height + 24;

			if (currentForm != null) currentForm.Close();
			currentForm = form;

			form.Show();
			form.WindowState = FormWindowState.Maximized;

			labMenuItem.Text = form.Text;
		}

		private void Lab1MenuItem_Click(object sender, EventArgs e)
		{
			Lab1 form = new Lab1();
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
			Lab4 form = new Lab4();
			ShowForm(form);
		}

		private void lab5MenuItem_Click(object sender, EventArgs e)
		{
			Lab5 form = new Lab5();
			ShowForm(form);
		}

		private void lab6MenuItem_Click(object sender, EventArgs e)
		{
			//Lab6 form = new Lab6();
			//ShowForm(form);
		}
	}
}
