using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace View
{
    public class Cube
    {
        private Dictionary<FaceName, Face> faces = new Dictionary<FaceName, Face>();

        public Cube(Form mainForm)
        {
            faces[FaceName.BOTTOM] = new Face(mainForm, 55, 110, Color.White);
            faces[FaceName.FRONT] = new Face(mainForm, 55, 55, Color.Blue);
            faces[FaceName.RIGHT] = new Face(mainForm, 110, 55, Color.Red);
            faces[FaceName.LEFT] = new Face(mainForm, 0, 55, Color.Orange);
            faces[FaceName.BACK] = new Face(mainForm, 165, 55, Color.Green);
            faces[FaceName.TOP] = new Face(mainForm, 55, 0, Color.Yellow);
        }

        public void Update(Model.Field field)
        {
            faces[field.faceName].fields[field.x, field.y].BackColor = field.color;
        }
    }
}
