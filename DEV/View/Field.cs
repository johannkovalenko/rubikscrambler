using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class Field : Label
    {
        private int x;
        private int y;
        private FaceName faceName;

        public Field(int xPos, int yPos, int x, int y, FaceName faceName, Color initialColor)
        {
            this.x = x;
            this.y = y;
            this.faceName = faceName;
            base.BackColor = initialColor;
            base.Size = new Size(15, 15);
            base.Location = new Point(xPos, yPos);
        }
    }
}
