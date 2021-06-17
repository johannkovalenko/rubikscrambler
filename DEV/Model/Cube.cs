using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Model
{
    public class Cube
    {
        private readonly Dictionary<F, Face> faces = new Dictionary<F, Face>();

        public Cube()
        {
            faces[F.BOTTOM] = new Face(Color.White, F.BOTTOM);
            faces[F.FRONT] = new Face(Color.Blue, F.FRONT);
            faces[F.RIGHT] = new Face(Color.Red, F.RIGHT);
            faces[F.LEFT] = new Face(Color.Orange, F.LEFT);
            faces[F.BACK] = new Face(Color.Green, F.BACK);
            faces[F.TOP] = new Face(Color.Yellow, F.TOP);
        }

        public List<Field> Run(string direction)
        {
            var output = new List<Field>();

            switch (direction)
            {
                case "R":
                    R_Mover(output, faces[F.FRONT], faces[F.BOTTOM], faces[F.BACK], faces[F.TOP]);
                    MoveAllFieldsInTurningFace(output, faces[F.RIGHT]);
                    break;
                case "R'":
                    R_Mover(output, faces[F.FRONT], faces[F.TOP], faces[F.BACK], faces[F.BOTTOM]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.RIGHT]);
                    break;
                case "L":
                    L_Mover(output, faces[F.FRONT], faces[F.TOP], faces[F.BACK], faces[F.BOTTOM]);
                    MoveAllFieldsInTurningFace(output, faces[F.LEFT]);
                    break;
                case "L'":
                    L_Mover(output, faces[F.FRONT], faces[F.BOTTOM], faces[F.BACK], faces[F.TOP]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.LEFT]);
                    break;
                case "U":
                    U_Mover(output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    MoveAllFieldsInTurningFace(output, faces[F.TOP]);
                    break;
                case "U'":
                    U_Mover(output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.TOP]);
                    break;
                case "D":
                    D_Mover(output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    MoveAllFieldsInTurningFace(output, faces[F.BOTTOM]);
                    break;
                case "D'":
                    D_Mover(output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.BOTTOM]);
                    break;
                case "F":
                    F_Mover(output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    MoveAllFieldsInTurningFace(output, faces[F.FRONT]);
                    break;
                case "F'":
                    F_MoverPrime(output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.FRONT]);
                    break;
                case "B":
                    B_Mover(output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    MoveAllFieldsInTurningFace(output, faces[F.BACK]);
                    break;
                case "B'":
                    B_MoverPrime(output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.BACK]);
                    break;
            }

            return output;
        }

        public Color ColorCheck(F faceName, int x, int y)
        {
            return faces[faceName].fields[x,y].color;
        }

        private void R_Mover(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            Move(output, face1.fields[0,2], face2.fields[0,2], face3.fields[2,0], face4.fields[0,2]);
            Move(output, face1.fields[1,2], face2.fields[1,2], face3.fields[1,0], face4.fields[1,2]);
            Move(output, face1.fields[2,2], face2.fields[2,2], face3.fields[0,0], face4.fields[2,2]);
        }

        private void L_Mover(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            Move(output, face1.fields[0,0], face2.fields[0,0], face3.fields[2,2], face4.fields[0,0]);
            Move(output, face1.fields[1,0], face2.fields[1,0], face3.fields[1,2], face4.fields[1,0]);
            Move(output, face1.fields[2,0], face2.fields[2,0], face3.fields[0,2], face4.fields[2,0]);
        }

        private void U_Mover(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            Move(output, face1.fields[0,0], face2.fields[0,0], face3.fields[0,0], face4.fields[0,0]);
            Move(output, face1.fields[0,1], face2.fields[0,1], face3.fields[0,1], face4.fields[0,1]);
            Move(output, face1.fields[0,2], face2.fields[0,2], face3.fields[0,2], face4.fields[0,2]);
        }

        private void D_Mover(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            Move(output, face1.fields[2,0], face2.fields[2,0], face3.fields[2,0], face4.fields[2,0]);
            Move(output, face1.fields[2,1], face2.fields[2,1], face3.fields[2,1], face4.fields[2,1]);
            Move(output, face1.fields[2,2], face2.fields[2,2], face3.fields[2,2], face4.fields[2,2]);
        }

        private void F_Mover(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            Move(output, face1.fields[2,2], face2.fields[0,2], face3.fields[0,0], face4.fields[2,0]);
            Move(output, face1.fields[2,1], face2.fields[1,2], face3.fields[0,1], face4.fields[1,0]);
            Move(output, face1.fields[2,0], face2.fields[2,2], face3.fields[0,2], face4.fields[0,0]);
        }

        private void F_MoverPrime(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            Move(output, face1.fields[2,2], face2.fields[2,0], face3.fields[0,0], face4.fields[0,2]);
            Move(output, face1.fields[2,1], face2.fields[1,0], face3.fields[0,1], face4.fields[1,2]);
            Move(output, face1.fields[2,0], face2.fields[0,0], face3.fields[0,2], face4.fields[2,2]);
        }

        private void B_Mover(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            Move(output, face1.fields[0,2], face2.fields[2,2], face3.fields[2,0], face4.fields[0,0]);
            Move(output, face1.fields[0,1], face2.fields[1,2], face3.fields[2,1], face4.fields[1,0]);
            Move(output, face1.fields[0,0], face2.fields[0,2], face3.fields[2,2], face4.fields[2,0]);
        }

        private void B_MoverPrime(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            Move(output, face1.fields[0,2], face2.fields[0,0], face3.fields[2,0], face4.fields[2,2]);
            Move(output, face1.fields[0,1], face2.fields[1,0], face3.fields[2,1], face4.fields[1,2]);
            Move(output, face1.fields[0,0], face2.fields[2,0], face3.fields[2,2], face4.fields[0,2]);
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
