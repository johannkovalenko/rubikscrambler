using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace View
{
    public class MainForm : Form
    {
        private readonly TextBox textBox = new TextBox();
        private readonly View.Cube cube;
        private readonly Controller.CubeMove cubeMove;
        private readonly Button rButton = new Button();

        public MainForm()
        {
            cube = new View.Cube(this, 90);
            cubeMove = new Controller.CubeMove(cube);

            TextBox();
            RButton();

            base.Width = 1300;
            base.Height = 1000;
            base.BackColor = Color.Gray;
        }

        private void TextBox()
        {
            this.textBox.Location = new Point(10, 10);
            this.textBox.Width = 300;
            this.textBox.KeyDown += delegate(object sender, KeyEventArgs key) 
            { 
                if (key.KeyCode == Keys.Space)
                    cubeMove.Run(textBox.Text); 
            };
            base.Controls.Add(this.textBox);
        }

        private void RButton()
        {
            rButton.Text = "R";
            rButton.Size = new Size(50,50);
            rButton.Location = new Point (50, 50);
            
            rButton.MouseDown += delegate(object sender, MouseEventArgs e) 
            { 
                if (e.Button == MouseButtons.Left)
                    cubeMove.Run("R"); 
                else if (e.Button == MouseButtons.Right)
                    cubeMove.Run("R'"); 
                else if (e.Button == MouseButtons.Middle)
                    cubeMove.Run("R2");
            };

            base.Controls.Add(rButton);
        }

    }
}
