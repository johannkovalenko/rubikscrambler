using System.Drawing;
using System.Collections.Generic;

namespace Model
{
    public class Cube
    {
        private Face[] faces = new Face[6];

        public Cube()
        {
            faces[0] = new Face(Color.White, FaceName.BOTTOM);
            faces[1] = new Face(Color.Blue, FaceName.FRONT);
            faces[2] = new Face(Color.Red, FaceName.RIGHT);
            faces[3] = new Face(Color.Orange, FaceName.LEFT);
            faces[4] = new Face(Color.Green, FaceName.BACK);
            faces[5] = new Face(Color.Yellow, FaceName.TOP);
        }

        public List<Field> Run(Direction direction, Mode mode)
        {
            switch (direction)
            {
                case Direction.R:
                    switch (mode)
                    {
                        case Mode.Standard:
                        return Do_R_Standard();
                    }
                    break;
            }

            return null;
        }

        private List<Field> Do_R_Standard()
        {
            var output = new List<Field>();

            Field blueRightTop = faces[1].fields[2,2];
            Field yellowRightTop = faces[5].fields[2,2];
            Field greenLeftBottom = faces[4].fields[0,0];
            Field whiteRightTop = faces[0].fields[2,2];

            Color temp = blueRightTop.color;
            blueRightTop.color = whiteRightTop.color;
            whiteRightTop.color = greenLeftBottom.color;
            greenLeftBottom.color = yellowRightTop.color;
            yellowRightTop.color = temp;

            output.Add(blueRightTop);
            output.Add(yellowRightTop);
            output.Add(greenLeftBottom);
            output.Add(whiteRightTop);

            return output;
        }
    }
}
