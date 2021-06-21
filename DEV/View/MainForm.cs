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
        
        public MainForm()
        {
            cube = new View.Cube(this, 90);
            cubeMove = new Controller.CubeMove(cube);

            FormSettings();
            TextBox();
            BuildButtons();

        }

        private void FormSettings()
        {
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

        private void BuildButtons()
        {
            new DirectionButton("R",  50,  50, cubeMove, this);
            new DirectionButton("U", 100,  50, cubeMove, this);
            new DirectionButton("F", 150,  50, cubeMove, this);
            new DirectionButton("L",  50, 100, cubeMove, this);
            new DirectionButton("D", 100, 100, cubeMove, this);
            new DirectionButton("B", 150, 100, cubeMove, this);
            new DirectionButton("M",  50, 150, cubeMove, this);
            new DirectionButton("S", 100, 150, cubeMove, this);
            new DirectionButton("E", 150, 150, cubeMove, this);
            new DirectionButton("X",  50, 200, cubeMove, this);
            new DirectionButton("Y", 100, 200, cubeMove, this);
            new DirectionButton("Z", 150, 200, cubeMove, this);
        }
    }
}
