using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace Controller
{
    public class CubeMove
    {
        private View.Cube viewCube;
        public CubeMove(View.Cube viewCube)
        {
            this.viewCube = viewCube;
        }
        private Model.Cube cube = new Model.Cube();

        private Direction direction;
        private Mode mode;

        public void Run(Keys keyCode, string textInTextBox)
        {
            if (!SetDirectionAndMode(keyCode, textInTextBox))
                return;

            List<Model.Field> fields = cube.Run(direction, mode);

            foreach(Model.Field field in fields)
                viewCube.Update(field);
                
        }

        private bool SetDirectionAndMode(Keys keyCode, string textInTextBox)
        {
            if (keyCode == Keys.Space)
            {
                var split = textInTextBox.Split(' ');

                switch (split[split.Length - 1])
                {
                    case "R":
                        direction = Direction.R;
                        mode = Mode.Standard;
                        return true;
                    case "R'":
                        direction = Direction.R;
                        mode = Mode.Prime;
                        return true;
                    case "U":
                        direction = Direction.U;
                        mode = Mode.Standard;
                        return true;    
                    case "U'":
                        direction = Direction.U;
                        mode = Mode.Prime;
                        return true;                  
                }
            }

            return false;
        }
    }
}
