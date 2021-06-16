using System.Drawing;

namespace Model
{
    public class Field
    {
        public readonly int x;
        public readonly int y;
        public Color color;
        public readonly F F;

        public Field(int x, int y, Color color, F F)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.F = F;
        }
    }
}
