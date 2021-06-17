using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

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
                    R_L_M_Mover(2, output, faces[F.FRONT], faces[F.BOTTOM], faces[F.BACK], faces[F.TOP]);
                    MoveAllFieldsInTurningFace(output, faces[F.RIGHT]);
                    break;
                case "R'":
                    R_L_M_Mover(2, output, faces[F.FRONT], faces[F.TOP], faces[F.BACK], faces[F.BOTTOM]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.RIGHT]);
                    break;
                case "L":
                    R_L_M_Mover(0, output, faces[F.FRONT], faces[F.TOP], faces[F.BACK], faces[F.BOTTOM]);
                    MoveAllFieldsInTurningFace(output, faces[F.LEFT]);
                    break;
                case "L'":
                    R_L_M_Mover(0, output, faces[F.FRONT], faces[F.BOTTOM], faces[F.BACK], faces[F.TOP]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.LEFT]);
                    break;
                case "U":
                    U_D_Mover(0, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    MoveAllFieldsInTurningFace(output, faces[F.TOP]);
                    break;
                case "U'":
                    U_D_Mover(0, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.TOP]);
                    break;
                case "D":
                    U_D_Mover(2, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    MoveAllFieldsInTurningFace(output, faces[F.BOTTOM]);
                    break;
                case "D'":
                    U_D_Mover(2, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.BOTTOM]);
                    break;
                case "F":
                    F_B_Mover(0, -2, 2, 4, 2, output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    MoveAllFieldsInTurningFace(output, faces[F.FRONT]);
                    break;
                case "F'":
                    F_B_Mover(-2, 0, 2, 2, 4, output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.FRONT]);
                    break;
                case "B":
                    F_B_Mover(-2, 0, 0, 2, 0, output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    MoveAllFieldsInTurningFace(output, faces[F.BACK]);
                    break;
                case "B'":
                    F_B_Mover(0, -2, 0, 0, 2, output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    MoveAllFieldsInTurningFaceCounter(output, faces[F.BACK]);
                    break;
                case "M":
                    R_L_M_Mover(1, output, faces[F.FRONT], faces[F.BOTTOM], faces[F.BACK], faces[F.TOP]);
                    break;
                case "M'":
                    R_L_M_Mover(1, output, faces[F.FRONT], faces[F.TOP], faces[F.BACK], faces[F.BOTTOM]);
                    break;
            }

            return output;
        }

        public Color ColorCheck(F faceName, int x, int y)
        {
            return faces[faceName].fields[x,y].color;
        }

        private void R_L_M_Mover(int y, List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            for (int x=0; x<3; x++)
                Move(output, face1.fields[x,y], face2.fields[x,y], face3.fields[2-x,2-y], face4.fields[x,y]);
        }

        private void U_D_Mover(int x, List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            for (int y=0; y<3; y++)
                Move(output, face1.fields[x,y], face2.fields[x,y], face3.fields[x,y], face4.fields[x,y]);
        }

        private void F_B_Mover(int g, int h, int j, int l, int n, List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            for (int i=0; i<3; i++)
                Move(output, face1.fields[j,2-i], face2.fields[Math.Abs(g+i),l-j], face3.fields[2-j,i], face4.fields[Math.Abs(h+i),n-j]);
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
