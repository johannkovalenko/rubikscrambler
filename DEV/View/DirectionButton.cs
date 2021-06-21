using System.Windows.Forms;
using System.Drawing;

namespace View
{
    class DirectionButton : Button
    {
        public DirectionButton(string direction, int posX, int posY, Controller.CubeMove cubeMove, Form mainForm)
        {
            base.Text = direction;
            base.Size = new Size(50,50);
            base.Location = new Point (posX, posY);
            
            base.MouseDown += delegate(object sender, MouseEventArgs e) 
            { 
                if (e.Button == MouseButtons.Left)
                    cubeMove.Run(direction); 
                else if (e.Button == MouseButtons.Right)
                    cubeMove.Run(direction + "'"); 
                else if (e.Button == MouseButtons.Middle)
                    cubeMove.Run(direction + "2");
            };

            mainForm.Controls.Add(this);
        }
    }
}