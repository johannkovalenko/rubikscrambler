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
            base.Width = 300;
            base.Height = 300;
            base.BackColor = Color.Gray;
            var cube = new View.Cube(this);
        }

    }
}
