using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class Face
    {
        public Field[,] fields = new Field[3,3];

        public Face(Form mainForm, int xPos, int yPos, Color initialColor)
        {
            int cnt = 0;
            for (int x=0; x<3; x++)
                for (int y=0; y<3; y++)
                {

                    // if (x == 1 || x == 2)
                    //     initialColor = Color.Gray; 

                    fields[x,y] = new Field(xPos + y * 17, yPos + x * 17, initialColor, ++cnt);
                    mainForm.Controls.Add(fields[x,y]);
                }
        }
    }
}