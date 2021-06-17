using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TEST
{
    [TestClass]
    public class UnitTest1
    {
        private Dictionary<int, Color> colorMap = new Dictionary<int, Color> 
        {
            { 164,  Color.White },
            { 37,   Color.Blue },
            { 141,  Color.Red },
            { 127,  Color.Orange },
            { 79,   Color.Green },
            { 166,  Color.Yellow }
        };

        private Model.Cube cube = new Model.Cube();

        [TestMethod]
        [DataRow(F.FRONT, 2, 2, 37, DisplayName="FRONT 3 3 BLUE")]
        [DataRow(F.BACK, 1, 2, 79, DisplayName="FRONT 2 3 GREEN")]
        public void Check_Inital_Solved_Position(F face, int x, int y, int expectedColor)
        {
            Assert.AreEqual(colorMap[expectedColor], cube.ColorCheck(face, x, y));
        }

        [TestMethod]
        public void Check_R_U_RPrime_UPrime_Move()
        {
            cube.Run("R");
            cube.Run("U");
            cube.Run("R'");
            cube.Run("U'");

            Assert.AreEqual(Color.White, cube.ColorCheck(F.FRONT, 0, 2));
            Assert.AreEqual(Color.Yellow, cube.ColorCheck(F.RIGHT, 2, 0));
        }
    }
}
