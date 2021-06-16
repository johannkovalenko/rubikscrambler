using System.Collections.Generic;

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

        public void Run(Direction direction, Mode mode)
        {
            List<Model.Field> fields = cube.Run(direction, mode);

            foreach(var field in fields)
            {
                viewCube.faces[field.faceName].fields[field.x, field.y].BackColor = field.color;
            }
        }
    }
}
