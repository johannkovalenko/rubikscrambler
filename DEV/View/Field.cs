using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class Field : Label
    {
        private int x;
        private int y;

        public Field(int xPos, int yPos, int x, int y, Color initialColor)
        {
            this.x = x;
            this.y = y;
            base.BackColor = initialColor;
            base.Size = new Size(15, 15);
            base.Location = new Point(xPos, yPos);
        }
    }
}
