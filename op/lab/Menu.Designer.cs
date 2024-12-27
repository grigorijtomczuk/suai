namespace lab
{
	partial class Menu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menuStrip1 = new MenuStrip();
			labMenuItem = new ToolStripMenuItem();
			lab1MenuItem = new ToolStripMenuItem();
			lab2MenuItem = new ToolStripMenuItem();
			lab3MenuItem = new ToolStripMenuItem();
			lab4MenuItem = new ToolStripMenuItem();
			lab5MenuItem = new ToolStripMenuItem();
			lab6MenuItem = new ToolStripMenuItem();
			lab7MenuItem = new ToolStripMenuItem();
			lab8MenuItem = new ToolStripMenuItem();
			lab9MenuItem = new ToolStripMenuItem();
			courseworkMenuItem = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(24, 24);
			menuStrip1.Items.AddRange(new ToolStripItem[] { labMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(9, 3, 0, 3);
			menuStrip1.Size = new Size(690, 35);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// labMenuItem
			// 
			labMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lab1MenuItem, lab2MenuItem, lab3MenuItem, lab4MenuItem, lab5MenuItem, lab6MenuItem, lab7MenuItem, lab8MenuItem, lab9MenuItem, courseworkMenuItem });
			labMenuItem.Name = "labMenuItem";
			labMenuItem.Size = new Size(85, 29);
			labMenuItem.Text = "Форма";
			// 
			// lab1MenuItem
			// 
			lab1MenuItem.Name = "lab1MenuItem";
			lab1MenuItem.Size = new Size(270, 34);
			lab1MenuItem.Text = "ЛР1";
			lab1MenuItem.Click += Lab1MenuItem_Click;
			// 
			// lab2MenuItem
			// 
			lab2MenuItem.Name = "lab2MenuItem";
			lab2MenuItem.Size = new Size(270, 34);
			lab2MenuItem.Text = "ЛР2";
			lab2MenuItem.Click += Lab2MenuItem_Click;
			// 
			// lab3MenuItem
			// 
			lab3MenuItem.Name = "lab3MenuItem";
			lab3MenuItem.Size = new Size(270, 34);
			lab3MenuItem.Text = "ЛР3";
			lab3MenuItem.Click += Lab3MenuItem_Click;
			// 
			// lab4MenuItem
			// 
			lab4MenuItem.Name = "lab4MenuItem";
			lab4MenuItem.Size = new Size(270, 34);
			lab4MenuItem.Text = "ЛР4";
			lab4MenuItem.Click += Lab4MenuItem_Click;
			// 
			// lab5MenuItem
			// 
			lab5MenuItem.Name = "lab5MenuItem";
			lab5MenuItem.Size = new Size(270, 34);
			lab5MenuItem.Text = "ЛР5";
			lab5MenuItem.Click += lab5MenuItem_Click;
			// 
			// lab6MenuItem
			// 
			lab6MenuItem.Name = "lab6MenuItem";
			lab6MenuItem.Size = new Size(270, 34);
			lab6MenuItem.Text = "ЛР6";
			lab6MenuItem.Click += lab6MenuItem_Click;
			// 
			// lab7MenuItem
			// 
			lab7MenuItem.Name = "lab7MenuItem";
			lab7MenuItem.Size = new Size(270, 34);
			lab7MenuItem.Text = "ЛР7";
			lab7MenuItem.Click += lab7MenuItem_Click;
			// 
			// lab8MenuItem
			// 
			lab8MenuItem.Name = "lab8MenuItem";
			lab8MenuItem.Size = new Size(270, 34);
			lab8MenuItem.Text = "ЛР8";
			lab8MenuItem.Click += lab8MenuItem_Click;
			// 
			// lab9MenuItem
			// 
			lab9MenuItem.Name = "lab9MenuItem";
			lab9MenuItem.Size = new Size(270, 34);
			lab9MenuItem.Text = "ЛР9";
			lab9MenuItem.Click += lab9MenuItem_Click;
			// 
			// courseworkMenuItem
			// 
			courseworkMenuItem.Name = "courseworkMenuItem";
			courseworkMenuItem.Size = new Size(270, 34);
			courseworkMenuItem.Text = "КР";
			courseworkMenuItem.Click += courseworkMenuItem_Click;
			// 
			// Menu
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(690, 465);
			Controls.Add(menuStrip1);
			IsMdiContainer = true;
			MainMenuStrip = menuStrip1;
			Margin = new Padding(4, 5, 4, 5);
			Name = "Menu";
			Text = "Menu";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem labMenuItem;
		private ToolStripMenuItem lab1MenuItem;
		private ToolStripMenuItem lab2MenuItem;
		private ToolStripMenuItem lab3MenuItem;
		private ToolStripMenuItem lab4MenuItem;
		private ToolStripMenuItem lab5MenuItem;
		private ToolStripMenuItem lab6MenuItem;
		private ToolStripMenuItem lab7MenuItem;
		private ToolStripMenuItem lab8MenuItem;
		private ToolStripMenuItem lab9MenuItem;
		private ToolStripMenuItem courseworkMenuItem;
	}
}