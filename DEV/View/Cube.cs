using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace View
{
    public class Cube
    {
        private Dictionary<F, Face> faces = new Dictionary<F, Face>();

        public Cube(Form mainForm)
        {
            faces[F.BOTTOM] = new Face(mainForm, 55, 110, Color.White);
            faces[F.FRONT] = new Face(mainForm, 55, 55, Color.Blue);
            faces[F.RIGHT] = new Face(mainForm, 110, 55, Color.Red);
            faces[F.LEFT] = new Face(mainForm, 0, 55, Color.Orange);
            faces[F.BACK] = new Face(mainForm, 165, 55, Color.Green);
            faces[F.TOP] = new Face(mainForm, 55, 0, Color.Yellow);
        }

        public void Update(Model.Field field)
        {
            faces[field.F].fields[field.x, field.y].BackColor = field.color;
        }
    }
}
