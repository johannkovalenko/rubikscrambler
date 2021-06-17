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

        public void Run(string textInTextBox)
        {
            var split = textInTextBox.Split(' ');
            var lastEntry = split[split.Length - 1];

            List<Model.Field> fields = cube.Run(lastEntry);

            foreach(Model.Field field in fields)
                viewCube.Update(field);
                
        }
    }
}
