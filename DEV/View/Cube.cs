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
            int space = len + len/9; 

            faces[F.BOTTOM] =   new Face(mainForm, space * 3, space * 6, Color.White, len);
            faces[F.FRONT] =    new Face(mainForm, space * 3, space * 3, Color.Blue, len);
            faces[F.RIGHT] =    new Face(mainForm, space * 6, space * 3, Color.Red, len);
            faces[F.LEFT] =     new Face(mainForm, space * 0, space * 3, Color.Orange, len);
            faces[F.BACK] =     new Face(mainForm, space * 9, space * 3, Color.Green, len);
            faces[F.TOP] =      new Face(mainForm, space * 3, space * 0, Color.Yellow, len);
        }

        public void Update(Model.Field field)
        {
            faces[field.F].fields[field.x, field.y].BackColor = field.color;
        }
    }
}
