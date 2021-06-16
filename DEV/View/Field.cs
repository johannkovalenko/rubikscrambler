using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class Field : Label
    {
        public Field(int xPos, int yPos, Color initialColor, int cnt)
        {
            base.BackColor = initialColor;
            base.Size = new Size(15, 15);
            base.Location = new Point(xPos, yPos);
            //base.Text = "" + cnt;
        }
    }
}
