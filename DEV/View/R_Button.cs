using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class R_Button : Button
    {
        public R_Button()
        {
            base.Size = new Size(30, 30);
            base.Location = new Point(10, 200);
            base.Text = "R"; 
        }
    }
}
