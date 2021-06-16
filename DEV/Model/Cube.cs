using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Model
{
    public class Cube
    {
        private readonly Dictionary<FaceName, Face> faces = new Dictionary<FaceName, Face>();

        public Cube()
        {
            faces[FaceName.BOTTOM] = new Face(Color.White, FaceName.BOTTOM);
            faces[FaceName.FRONT] = new Face(Color.Blue, FaceName.FRONT);
            faces[FaceName.RIGHT] = new Face(Color.Red, FaceName.RIGHT);
            faces[FaceName.LEFT] = new Face(Color.Orange, FaceName.LEFT);
            faces[FaceName.BACK] = new Face(Color.Green, FaceName.BACK);
            faces[FaceName.TOP] = new Face(Color.Yellow, FaceName.TOP);
        }

        public List<Field> Run(Direction direction, Mode mode)
        {
            var output = new List<Field>();
            Face face1, face2, face3, face4;
            switch (direction)
            {
                case Direction.R:
                    switch (mode)
                    {
                        case Mode.Standard:
                            face1 = faces[FaceName.FRONT];
                            face2 = faces[FaceName.BOTTOM];
                            face3 = faces[FaceName.BACK];
                            face4 = faces[FaceName.TOP];
                            Move(output, face1.fields[0,2], face2.fields[0,2], face3.fields[2,0], face4.fields[0,2]);
                            Move(output, face1.fields[1,2], face2.fields[1,2], face3.fields[1,0], face4.fields[1,2]);
                            Move(output, face1.fields[2,2], face2.fields[2,2], face3.fields[0,0], face4.fields[2,2]);
                            MoveAllFieldsInTurningFace(output, faces[FaceName.RIGHT]);
                            return output;
                        case Mode.Prime:
                            face1 = faces[FaceName.FRONT];
                            face2 = faces[FaceName.TOP];
                            face3 = faces[FaceName.BACK];
                            face4 = faces[FaceName.BOTTOM];
                            Move(output, face1.fields[0,2], face2.fields[0,2], face3.fields[2,0], face4.fields[0,2]);
                            Move(output, face1.fields[1,2], face2.fields[1,2], face3.fields[1,0], face4.fields[1,2]);
                            Move(output, face1.fields[2,2], face2.fields[2,2], face3.fields[0,0], face4.fields[2,2]);
                            MoveAllFieldsInTurningFaceCounter(output, faces[FaceName.RIGHT]);
                            return output;
                    }
                    break;
                case Direction.U:
                    switch (mode)
                    {
                        case Mode.Standard:
                            face1 = faces[FaceName.FRONT];
                            face2 = faces[FaceName.RIGHT];
                            face3 = faces[FaceName.BACK];
                            face4 = faces[FaceName.LEFT];
                            Move(output, face1.fields[0,0], face2.fields[0,0], face3.fields[0,0], face4.fields[0,0]);
                            Move(output, face1.fields[0,1], face2.fields[0,1], face3.fields[0,1], face4.fields[0,1]);
                            Move(output, face1.fields[0,2], face2.fields[0,2], face3.fields[0,2], face4.fields[0,2]);
                            MoveAllFieldsInTurningFace(output, faces[FaceName.TOP]);
                            return output;
                        case Mode.Prime:
                            face1 = faces[FaceName.FRONT];
                            face2 = faces[FaceName.LEFT];
                            face3 = faces[FaceName.BACK];
                            face4 = faces[FaceName.RIGHT];
                            Move(output, face1.fields[0,0], face2.fields[0,0], face3.fields[0,0], face4.fields[0,0]);
                            Move(output, face1.fields[0,1], face2.fields[0,1], face3.fields[0,1], face4.fields[0,1]);
                            Move(output, face1.fields[0,2], face2.fields[0,2], face3.fields[0,2], face4.fields[0,2]);
                            MoveAllFieldsInTurningFaceCounter(output, faces[FaceName.TOP]);
                            return output;
                    }
                    break;
            }

            return null;
        }

        private void MoveAllFieldsInTurningFace(List<Field> output, Face face)
        {
            Color temp = face.fields[0,0].color;
            face.fields[0,0].color = face.fields[2,0].color;
            face.fields[2,0].color = face.fields[2,2].color;
            face.fields[2,2].color = face.fields[0,2].color;
            face.fields[0,2].color = temp;

            temp = face.fields[1,0].color;
            face.fields[1,0].color = face.fields[2,1].color;
            face.fields[2,1].color = face.fields[1,2].color;
            face.fields[1,2].color = face.fields[0,1].color;
            face.fields[0,1].color = temp;

            output.Add(face.fields[0,0]);
            output.Add(face.fields[2,0]);
            output.Add(face.fields[2,2]);
            output.Add(face.fields[0,2]);
            output.Add(face.fields[1,0]);
            output.Add(face.fields[2,1]);
            output.Add(face.fields[1,2]);
            output.Add(face.fields[0,1]);
        }

        private void MoveAllFieldsInTurningFaceCounter(List<Field> output, Face face)
        {
            Color temp = face.fields[0,0].color;
            face.fields[0,0].color = face.fields[0,2].color;
            face.fields[0,2].color = face.fields[2,2].color;
            face.fields[2,2].color = face.fields[2,0].color;
            face.fields[2,0].color = temp;

            temp = face.fields[1,0].color;
            face.fields[1,0].color = face.fields[0,1].color;
            face.fields[0,1].color = face.fields[1,2].color;
            face.fields[1,2].color = face.fields[2,1].color;
            face.fields[2,1].color = temp;

            output.Add(face.fields[0,0]);
            output.Add(face.fields[2,0]);
            output.Add(face.fields[2,2]);
            output.Add(face.fields[0,2]);
            output.Add(face.fields[1,0]);
            output.Add(face.fields[2,1]);
            output.Add(face.fields[1,2]);
            output.Add(face.fields[0,1]);
        }

        private void Move(List<Field> output, Field field1, Field field2, Field field3, Field field4)
        {
            Color temp = field1.color;
            field1.color = field2.color;
            field2.color = field3.color;
            field3.color = field4.color;
            field4.color = temp;

            output.Add(field1);
            output.Add(field2);
            output.Add(field3);
            output.Add(field4);
        }
    }
}
