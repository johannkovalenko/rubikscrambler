using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class Face
    {
        public Field[,] fields = new Field[3,3];

        public Face(Form mainForm, string name, int xPos, int yPos, Color initialColor)
        {
            for (int x=0; x<3; x++)
                for (int y=0; y<3; y++)
                {
                    fields[x,y] = new Field(xPos + x * 17, yPos + y * 17, x, y, initialColor);
                    mainForm.Controls.Add(fields[x,y]);
                }
        }
    }
}