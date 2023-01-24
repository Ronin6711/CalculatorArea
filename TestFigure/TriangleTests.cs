using CalculatorArea.Figures;

namespace TestFigure
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void CalculateArea_MustReturnRightValue()
        {
            // Arrange
            var sideA = 3;
            var sideB = 5;
            var sideC = 6;
            var triangle = new Triangle(sideA, sideB, sideC);
            var p = (sideA + sideB + sideC) / 2;
            double expectedResult = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));

            // Act
            var actualAreaValue = triangle.CalculateArea();

            //Assert
            Assert.AreEqual(expectedResult, actualAreaValue);
        }

        [Test]
        public void TryCalculateArea_MustReturnTrue_IfArgsCountThree()
        {
            // Arrange
            var args = new double[] { 3, 5, 6 };
            double actualAreaValue;
            var triangle = new Triangle();
            var p = (args[0] + args[1] + args[2]) / 2;
            double expectedResult = Math.Sqrt(p * (p - args[0]) * (p - args[1]) * (p - args[2]));

            // Act
            var result = triangle.TryCalculateArea(out actualAreaValue, args);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedResult, actualAreaValue);
        }

        [Test]
        public void TryCalculateArea_MustReturnFalse_IfArgsCountNotEqualsThree()
        {
            // Arrange
            var args = new double[] { 3, 5, 6, 5 };
            double actualAreaValue;
            var triangle = new Triangle();
            double expectedResult = default;

            // Act
            var result = triangle.TryCalculateArea(out actualAreaValue, args);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(expectedResult, actualAreaValue);
        }

        [Test]
        public void TriangleIsRight_MustReturnTrue_IfTriangleRight()
        {
            // Arrange
            var sideA = 3;
            var sideB = 4;
            var sideC = 5;
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var result = triangle.TriangleIsRight();

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TriangleIsRight_MustReturnFalse_IfTriangleNotRight()
        {
            // Arrange
            var sideA = 2;
            var sideB = 4;
            var sideC = 5;
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var result = triangle.TriangleIsRight();

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ConstructorTriangle_MustSetRightSide()
        {
            // Arrange
            var sideA = 3;
            var sideB = 5;
            var sideC = 6;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            //Assert
            Assert.AreEqual(sideA, triangle.SideA);
            Assert.AreEqual(sideB, triangle.SideB);
            Assert.AreEqual(sideC, triangle.SideC);
        }

        [Test]
        public void ConstructorTriangle_ArgumentException_IfNegativeSide()
        {
            // Arrange
            var sideA = -3;
            var sideB = -5;
            var sideC = 6;

            // Act

            //Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Test]
        public void ConstructorTriangle_ArgumentException_ImpossibleTriangle()
        {
            // Arrange
            var sideA = 2;
            var sideB = 1;
            var sideC = 6;

            // Act

            //Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }
    }
}
