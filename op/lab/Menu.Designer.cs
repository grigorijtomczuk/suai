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
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { labMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(483, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// labMenuItem
			// 
			labMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lab1MenuItem, lab2MenuItem, lab3MenuItem, lab4MenuItem });
			labMenuItem.Name = "labMenuItem";
			labMenuItem.Size = new Size(34, 20);
			labMenuItem.Text = "ЛР";
			// 
			// lab1MenuItem
			// 
			lab1MenuItem.Name = "lab1MenuItem";
			lab1MenuItem.Size = new Size(180, 22);
			lab1MenuItem.Text = "ЛР1";
			lab1MenuItem.Click += Lab1MenuItem_Click;
			// 
			// lab2MenuItem
			// 
			lab2MenuItem.Name = "lab2MenuItem";
			lab2MenuItem.Size = new Size(180, 22);
			lab2MenuItem.Text = "ЛР2";
			lab2MenuItem.Click += Lab2MenuItem_Click;
			// 
			// lab3MenuItem
			// 
			lab3MenuItem.Name = "lab3MenuItem";
			lab3MenuItem.Size = new Size(180, 22);
			lab3MenuItem.Text = "ЛР3";
			lab3MenuItem.Click += Lab3MenuItem_Click;
			// 
			// lab4MenuItem
			// 
			lab4MenuItem.Name = "lab4MenuItem";
			lab4MenuItem.Size = new Size(180, 22);
			lab4MenuItem.Text = "ЛР4";
			lab4MenuItem.Click += Lab4MenuItem_Click;
			// 
			// Menu
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(483, 279);
			Controls.Add(menuStrip1);
			IsMdiContainer = true;
			MainMenuStrip = menuStrip1;
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
	}
}