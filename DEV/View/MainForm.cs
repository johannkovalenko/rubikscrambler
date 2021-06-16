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
            this.textBox.KeyDown += delegate(object sender, KeyEventArgs key) { Handler(key); };
            base.Controls.Add(this.textBox);
        }

        private void Handler(KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Space)
            {
                var split = textBox.Text.Split(' ');

                switch (split[split.Length - 1])
                {
                    case "R":
                        cubeMove.Run(Direction.R, Mode.Standard);
                        break;
                    case "R'":
                        cubeMove.Run(Direction.R, Mode.Prime);
                        break;
                    case "U":
                        cubeMove.Run(Direction.U, Mode.Standard);
                        break;     
                    case "U'":
                        cubeMove.Run(Direction.U, Mode.Prime);
                        break;                    
                }
            }
        }

    }
}
