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
        public MainForm()
        {
            var cube = new View.Cube(this);
            var cubeMove = new Controller.CubeMove(cube);
            var buttonR = new R_Button();

            buttonR.Click += delegate(object sender, EventArgs e) { cubeMove.Run(Direction.R, Mode.Standard); };
            base.Controls.Add(buttonR);
            base.Width = 300;
            base.Height = 300;
            base.BackColor = Color.Gray;
        }

    }
}
