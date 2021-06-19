using System.Collections.Generic;

namespace Model
{
    class R_L_M_X
    {
        private Helper hlp;
        private Dictionary<F, Face> facesMap;
        private Face[] facesUp;
        private Face[] facesDown;

        public R_L_M_X(Helper hlp, Dictionary<F, Face> facesMap)
        {
            this.hlp = hlp;
            this.facesMap = facesMap;

            facesUp     = new Face[] { facesMap[F.FRONT], facesMap[F.BOTTOM], facesMap[F.BACK], facesMap[F.TOP] };
            facesDown   = new Face[] { facesMap[F.FRONT], facesMap[F.TOP], facesMap[F.BACK], facesMap[F.BOTTOM] };
        }

        private void R_Move(List<Field> output)
        {
            Move(2, output, facesUp);         
            hlp.MoveAllFieldsInTurningFace(output, facesMap[F.RIGHT]);
        }

        private void R_Prime_Move(List<Field> output)
        {
            Move(2, output, facesDown);
            hlp.MoveAllFieldsInTurningFaceCounter(output, facesMap[F.RIGHT]);
        }

        private void L_Move(List<Field> output)
        {
            Move(0, output, facesDown);
            hlp.MoveAllFieldsInTurningFace(output, facesMap[F.LEFT]);
        }

        private void L_Prime_Move(List<Field> output)
        {
            Move(0, output, facesUp);
            hlp.MoveAllFieldsInTurningFaceCounter(output, facesMap[F.LEFT]);
        }

        private void M_Move(List<Field> output)
        {
            Move(1, output, facesDown);
        }

        private void M_Prime_Move(List<Field> output)
        {
            Move(1, output, facesUp);
        }

        private void Move(int y, List<Field> output, Face[] faces)
        {
            for (int x=0; x<3; x++)
                hlp.Move(output, faces[0].fields[x,y], faces[1].fields[x,y], faces[2].fields[2-x,2-y], faces[3].fields[x,y]);
        }

        public void CheckCases(string direction, List<Field> output)
        {
            switch (direction)
            {
                case "R":
                    R_Move(output);
                    return;
                case "R'":
                    R_Prime_Move(output);
                    return;
                case "R2":
                    R_Move(output);
                    R_Move(output);
                    return;
                case "r":
                    M_Prime_Move(output);
                    R_Move(output);
                    return;
                case "r2":
                    M_Prime_Move(output);
                    M_Prime_Move(output);
                    R_Move(output);
                    R_Move(output);
                    return;
                case "r'":
                    M_Move(output);
                    R_Prime_Move(output);
                    return;
                case "L":
                    L_Move(output);
                    return;
                case "L'":
                    L_Prime_Move(output);
                    return;
                case "L2":
                    L_Move(output);
                    L_Move(output);
                    return;
                case "l":
                    M_Move(output);
                    L_Move(output);
                    return;
                case "l2":
                    M_Move(output);
                    M_Move(output);
                    L_Move(output);
                    L_Move(output);
                    return;
                case "l'":
                    M_Prime_Move(output);
                    L_Prime_Move(output);
                    return;
                case "X":
                    M_Prime_Move(output);
                    R_Move(output);
                    L_Prime_Move(output);                    
                    return;
                case "X'":
                    M_Move(output);
                    R_Prime_Move(output);
                    L_Move(output); 
                    return;
                case "M2":
                    M_Move(output);
                    M_Move(output);
                    return;
                case "M":
                    M_Move(output);
                    return;
                case "M'":
                    M_Prime_Move(output);
                    return; 
            }
        }
    }
}