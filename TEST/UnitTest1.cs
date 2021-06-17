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

        // private Dictionary<string, Direction> directionMap = new Dictionary<int, Direction> 
        // {
        //     { "R",  Direction.R },
        //     { "U",  Direction.U },
        //     { "F",  Direction.F },
        //     { "L",  Direction.L },
        //     { "D",  Direction.D },
        //     { "B",  Direction.B }
        // };

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
            cube.Run(Direction.R, Mode.Standard);
            cube.Run(Direction.U, Mode.Standard);
            cube.Run(Direction.R, Mode.Prime);
            cube.Run(Direction.U, Mode.Prime);

            Assert.AreEqual(Color.White, cube.ColorCheck(F.FRONT, 0, 2));
            Assert.AreEqual(Color.Yellow, cube.ColorCheck(F.RIGHT, 2, 0));
        }
    }
}
