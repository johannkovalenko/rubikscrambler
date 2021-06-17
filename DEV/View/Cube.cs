using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace View
{
    public class Cube
    {
        private Dictionary<F, Face> faces = new Dictionary<F, Face>();

        public Cube(Form mainForm, int len)
        {
            faces[F.BOTTOM] =   new Face(mainForm, len * 4, len * 8, Color.White, len);
            faces[F.FRONT] =    new Face(mainForm, len * 4, len * 4, Color.Blue, len);
            faces[F.RIGHT] =    new Face(mainForm, len * 8, len * 4, Color.Red, len);
            faces[F.LEFT] =     new Face(mainForm, len * 0, len * 4, Color.Orange, len);
            faces[F.BACK] =     new Face(mainForm, len * 12, len * 4, Color.Green, len);
            faces[F.TOP] =      new Face(mainForm, len * 4, len * 0, Color.Yellow, len);
        }

        public void Update(Model.Field field)
        {
            faces[field.F].fields[field.x, field.y].BackColor = field.color;
        }
    }
}
