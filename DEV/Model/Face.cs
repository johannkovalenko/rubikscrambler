using System.Drawing;

namespace Model
{
    public class Face
    {
        public Field[,] fields = new Field[3,3];

        public Face(Color color, FaceName faceName)
        {
            for (int x=0; x<3; x++)
                for (int y=0; y<3; y++)
                    fields[x,y] = new Field(x, y, color, faceName);
        }
    }
}