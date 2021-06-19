using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace Model
{
    public class Cube
    {
        private readonly Dictionary<F, Face> faces = new Dictionary<F, Face>();
        private readonly Helper hlp = new Helper();
        private readonly R_L_M_X rlmx;

        public Cube()
        {
            faces[F.BOTTOM] = new Face(Color.White, F.BOTTOM);
            faces[F.FRONT] = new Face(Color.Blue, F.FRONT);
            faces[F.RIGHT] = new Face(Color.Red, F.RIGHT);
            faces[F.LEFT] = new Face(Color.Orange, F.LEFT);
            faces[F.BACK] = new Face(Color.Green, F.BACK);
            faces[F.TOP] = new Face(Color.Yellow, F.TOP);
        
            rlmx = new R_L_M_X(hlp, faces);
        }

        public List<Field> Run(string direction)
        {
            var output = new List<Field>();

            string cleanedDirection = direction.Replace("2","").Replace("'", "").ToUpper();

            switch (cleanedDirection)
            {
                case ("R"):
                case ("L"):
                case ("M"):
                case ("X"):
                    rlmx.CheckCases(direction, output);
                    break;
            }

            switch (direction)
            {
                case "U":
                    U_D_E_Y_Mover(0, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.TOP]);
                    break;
                case "U2":
                    U_D_E_Y_Mover(0, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    U_D_E_Y_Mover(0, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.TOP]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.TOP]);
                    break;
                case "U'":
                    U_D_E_Y_Mover(0, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.TOP]);
                    break;
                case "D":
                    U_D_E_Y_Mover(2, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.BOTTOM]);
                    break;
                case "D2":
                    U_D_E_Y_Mover(2, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    U_D_E_Y_Mover(2, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.BOTTOM]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.BOTTOM]);
                    break;
                case "D'":
                    U_D_E_Y_Mover(2, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.BOTTOM]);
                    break;
                case "d":
                    U_D_E_Y_Mover(1, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    U_D_E_Y_Mover(2, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.BOTTOM]);
                    break;
                case "d'":
                    U_D_E_Y_Mover(1, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    U_D_E_Y_Mover(2, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.BOTTOM]);
                    break;
                case "Y'":
                    U_D_E_Y_Mover(0, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    U_D_E_Y_Mover(1, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    U_D_E_Y_Mover(2, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.TOP]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.BOTTOM]);

                    break;
                case "Y":
                    U_D_E_Y_Mover(0, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    U_D_E_Y_Mover(1, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    U_D_E_Y_Mover(2, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.TOP]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.BOTTOM]);
                    break;
                case "E":
                    U_D_E_Y_Mover(1, output, faces[F.FRONT], faces[F.LEFT], faces[F.BACK], faces[F.RIGHT]);
                    break;
                case "E'":
                    U_D_E_Y_Mover(1, output, faces[F.FRONT], faces[F.RIGHT], faces[F.BACK], faces[F.LEFT]);
                    break;
                case "F":
                    F_B_Mover(0, -2, 2, 4, 2, output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.FRONT]);
                    break;
                case "F2":
                    F_B_Mover(0, -2, 2, 4, 2, output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    F_B_Mover(0, -2, 2, 4, 2, output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.FRONT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.FRONT]);
                    break;
                case "F'":
                    F_B_Mover(-2, 0, 2, 2, 4, output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.FRONT]);
                    break;
                case "f":
                    F_B_Mover(0, -2, 2, 4, 2, output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    S_Mover(output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.FRONT]);
                    break;
                case "f'":
                    F_B_Mover(-2, 0, 2, 2, 4, output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    S_MoverPrime(output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.FRONT]);
                    break;
                case "Z":
                    F_B_Mover(0, -2, 2, 4, 2, output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    S_Mover(output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.FRONT]);
                    F_B_Mover(0, -2, 0, 0, 2, output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.BACK]);
                    break;
                case "Z'":
                    F_B_Mover(-2, 0, 2, 2, 4, output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    S_MoverPrime(output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.FRONT]);
                    F_B_Mover(-2, 0, 0, 2, 0, output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.BACK]);
                    break;
                case "B":
                    F_B_Mover(-2, 0, 0, 2, 0, output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.BACK]);
                    break;
                case "B2":
                    F_B_Mover(-2, 0, 0, 2, 0, output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    F_B_Mover(-2, 0, 0, 2, 0, output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.BACK]);
                    hlp.MoveAllFieldsInTurningFace(output, faces[F.BACK]);
                    break;
                case "B'":
                    F_B_Mover(0, -2, 0, 0, 2, output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    hlp.MoveAllFieldsInTurningFaceCounter(output, faces[F.BACK]);
                    break;
                case "S":
                    S_Mover(output, faces[F.TOP], faces[F.LEFT], faces[F.BOTTOM], faces[F.RIGHT]);
                    break;
                case "S'": 
                    S_MoverPrime(output, faces[F.TOP], faces[F.RIGHT], faces[F.BOTTOM], faces[F.LEFT]);
                    break;
            }

            return output;
        }

        public Color ColorCheck(F faceName, int x, int y)
        {
            return faces[faceName].fields[x,y].color;
        }

        private void U_D_E_Y_Mover(int x, List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            for (int y=0; y<3; y++)
                hlp.Move(output, face1.fields[x,y], face2.fields[x,y], face3.fields[x,y], face4.fields[x,y]);
        }

        private void F_B_Mover(int g, int h, int j, int l, int n, List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            for (int i=0; i<3; i++)
                hlp.Move(output, face1.fields[j,2-i], face2.fields[Math.Abs(g+i),l-j], face3.fields[2-j,i], face4.fields[Math.Abs(h+i),n-j]);
        }

        private void S_Mover(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            hlp.Move(output, face1.fields[1,0], face2.fields[2,1], face3.fields[1,2], face4.fields[0,1]);
            hlp.Move(output, face1.fields[1,1], face2.fields[1,1], face3.fields[1,1], face4.fields[1,1]);
            hlp.Move(output, face1.fields[1,2], face2.fields[0,1], face3.fields[1,0], face4.fields[2,1]);
        }
        private void S_MoverPrime(List<Field> output, Face face1, Face face2, Face face3, Face face4)
        {
            hlp.Move(output, face1.fields[1,0], face2.fields[0,1], face3.fields[1,2], face4.fields[2,1]);
            hlp.Move(output, face1.fields[1,1], face2.fields[1,1], face3.fields[1,1], face4.fields[1,1]);
            hlp.Move(output, face1.fields[1,2], face2.fields[2,1], face3.fields[1,0], face4.fields[0,1]);
        }
    }
}
