using System.Drawing;

namespace Model
{
    public class Field
    {
        public readonly int x;
        public readonly int y;
        public Color color;
        public readonly FaceName faceName;

        public Field(int x, int y, Color color, FaceName faceName)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.faceName = faceName;
        }
    }
}
