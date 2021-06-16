using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace View
{
    public class Cube
    {
        public Dictionary<FaceName, Face> faces = new Dictionary<FaceName, Face>();

        public Cube(Form mainForm)
        {
            faces[FaceName.BOTTOM] = new Face(mainForm, FaceName.BOTTOM, 50, 100, Color.White);
            faces[FaceName.FRONT] = new Face(mainForm, FaceName.FRONT, 50, 50, Color.Blue);
            faces[FaceName.RIGHT] = new Face(mainForm, FaceName.RIGHT, 100, 50, Color.Red);
            faces[FaceName.LEFT] = new Face(mainForm, FaceName.LEFT, 0, 50, Color.Orange);
            faces[FaceName.BACK] = new Face(mainForm, FaceName.BACK, 150, 50, Color.Green);
            faces[FaceName.TOP] = new Face(mainForm, FaceName.TOP, 50, 0, Color.Yellow);
        }
    }
}
