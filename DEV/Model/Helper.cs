using System.Collections.Generic;
using System.Drawing;

namespace Model
{
    class Helper
    {
        public void MoveAllFieldsInTurningFace(List<Field> output, Face face)
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

        public void MoveAllFieldsInTurningFaceCounter(List<Field> output, Face face)
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

        public void Move(List<Field> output, Field field1, Field field2, Field field3, Field field4)
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