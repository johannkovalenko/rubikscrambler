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

        //private Model.Cube cube = new Model.Cube();

        [TestMethod]
        [DataRow(F.FRONT, 2, 2, 37, DisplayName="FRONT 3 3 BLUE")]
        [DataRow(F.BACK, 1, 2, 79, DisplayName="FRONT 2 3 GREEN")]
        public void Check_Inital_Solved_Position(F face, int x, int y, int expectedColor)
        {
            Model.Cube cube = new Model.Cube();
            Assert.AreEqual(colorMap[expectedColor], cube.ColorCheck(face, x, y));
        }

        [TestMethod]
        public void Check_R_U_RPrime_UPrime_Move()
        {
            Model.Cube cube = new Model.Cube();

            cube.Run("R");
            cube.Run("U");
            cube.Run("R'");
            cube.Run("U'");

            Assert.AreEqual(Color.White, cube.ColorCheck(F.FRONT, 0, 2));
            Assert.AreEqual(Color.Yellow, cube.ColorCheck(F.RIGHT, 2, 0));
        }

        [TestMethod]
        public void Perform_A_PermOnInitialCube()
        {
            Model.Cube cube = new Model.Cube();

            string[] moves = {"R'", "F", "R'", "B2", "R", "F'", "R'", "B2", "R2"};

            foreach (var move in moves)
                cube.Run(move);

            Assert.AreEqual(Color.Green, cube.ColorCheck(F.RIGHT, 0, 0));
            Assert.AreEqual(Color.Green, cube.ColorCheck(F.RIGHT, 0, 2));
            Assert.AreEqual(Color.Red, cube.ColorCheck(F.FRONT, 0, 2));
            Assert.AreEqual(Color.Blue, cube.ColorCheck(F.BACK, 0, 2));             
        }

        [TestMethod]
        public void PerformRandomSequenceOnInitialCube()
        {
            Model.Cube cube = new Model.Cube();

            string[] moves = {"L", "R", "B2", "D'", "B'", "R", "F2", "L'", "U'", "F'", "D2", "F", "B'", "D'", "U2", "R", "L'", "D2", "L", "U"};

            foreach (var move in moves)
                cube.Run(move);

            Assert.AreEqual(Color.Red,      cube.ColorCheck(F.RIGHT, 0, 0));
            Assert.AreEqual(Color.Green,    cube.ColorCheck(F.RIGHT, 0, 1));
            Assert.AreEqual(Color.Blue,      cube.ColorCheck(F.FRONT, 0, 2));
            Assert.AreEqual(Color.White,     cube.ColorCheck(F.FRONT, 1, 0));
            Assert.AreEqual(Color.Orange,    cube.ColorCheck(F.LEFT, 1, 2));
            Assert.AreEqual(Color.Yellow,    cube.ColorCheck(F.LEFT, 2, 0));
            Assert.AreEqual(Color.Blue,      cube.ColorCheck(F.BACK, 2, 1));
            Assert.AreEqual(Color.Red,     cube.ColorCheck(F.BACK, 2, 2));
            Assert.AreEqual(Color.Green,    cube.ColorCheck(F.TOP, 2, 0));
            Assert.AreEqual(Color.Yellow,    cube.ColorCheck(F.TOP, 1, 2));
            Assert.AreEqual(Color.Green,      cube.ColorCheck(F.BOTTOM, 0, 1));
            Assert.AreEqual(Color.White,     cube.ColorCheck(F.BOTTOM, 1, 2));                   
        }

        [TestMethod]
        public void Perform_S_And_SPrime()
        {
            Model.Cube cube = new Model.Cube();

            string[] moves = {"S", "R", "U", "R'", "U'", "S'", "R", "U", "R'", "U'"};

            foreach (var move in moves)
                cube.Run(move);

            Assert.AreEqual(Color.Red,      cube.ColorCheck(F.TOP, 1, 0));
            Assert.AreEqual(Color.Green,    cube.ColorCheck(F.RIGHT, 0, 1));
            Assert.AreEqual(Color.Blue,     cube.ColorCheck(F.TOP, 2, 2));
            Assert.AreEqual(Color.White,    cube.ColorCheck(F.FRONT, 2, 2));
            Assert.AreEqual(Color.Orange,   cube.ColorCheck(F.LEFT, 0, 2));
            Assert.AreEqual(Color.Yellow,   cube.ColorCheck(F.TOP, 0, 1));
        }
    }
}
