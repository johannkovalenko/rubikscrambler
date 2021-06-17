using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class Field : Label
    {
        public Field(int xPos, int yPos, Color initialColor, int len)
        {
            base.BackColor = initialColor;
            base.Size = new Size(len, len);
            base.Location = new Point(xPos, yPos);
            base.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
