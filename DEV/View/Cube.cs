using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class Cube
    {
        private Face[] faces = new Face[6];

        public Cube(Form mainForm)
        {
            faces[0] = new Face(mainForm, "bottom", 50, 100, Color.White);
            faces[1] = new Face(mainForm, "front", 50, 50, Color.Blue);
            faces[2] = new Face(mainForm, "right", 100, 50, Color.Red);
            faces[3] = new Face(mainForm, "left", 0, 50, Color.Orange);
            faces[4] = new Face(mainForm, "back", 150, 50, Color.Green);
            faces[5] = new Face(mainForm, "top", 50, 0, Color.Yellow);
        }
    }
}
