using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public class MainForm : Form
    {
        private readonly TextBox textBox = new TextBox();
        private readonly View.Cube cube;
        private readonly Controller.CubeMove cubeMove;

        public MainForm()
        {
            cube = new View.Cube(this);
            cubeMove = new Controller.CubeMove(cube);

            TextBox();

            base.Width = 300;
            base.Height = 300;
            base.BackColor = Color.Gray;
        }

        private void TextBox()
        {
            this.textBox.Location = new Point(10, 200);
            this.textBox.KeyDown += delegate(object sender, KeyEventArgs key) 
            { 
                cubeMove.Run(key.KeyCode, textBox.Text); 
            };
            base.Controls.Add(this.textBox);
        }
    }
}
