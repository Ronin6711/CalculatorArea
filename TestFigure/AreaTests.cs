using CalculatorArea;

namespace TestFigure
{
    public class AreaTests
    {
        [Test]
        public void TryCalculateAreaFigure_IfArgsCountZero()
        {
            // Arrange
            var args = new double[] { };
            double actualAreaValue;
            double expectedResult = default;

            // Act
            var result = Area.TryCalculateAreaFigure(out actualAreaValue, args);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(expectedResult, actualAreaValue);
        }

        [Test]
        public void TryCalculateAreaFigure_IfArgsCountToMany()
        {
            // Arrange
            var args = new double[] { 2,4,5,6,1,2,3 };
            double actualAreaValue;
            double expectedResult = default;

            // Act
            var result = Area.TryCalculateAreaFigure(out actualAreaValue, args);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(expectedResult, actualAreaValue);
        }

        [Test]
        public void TryCalculateAreaFigure_MustCalculateAreaCircle_IfArgsCountOne()
        {
            // Arrange
            var args = new double[] { 3 };
            double actualAreaValue;
            double expectedResult = Math.PI * Math.Pow(args[0], 2); ;

            // Act
            var result = Area.TryCalculateAreaFigure(out actualAreaValue, args);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedResult, actualAreaValue);
        }

        [Test]
        public void TryCalculateAreaFigure_MustCalculateAreaTriangle_IfArgsCountThree()
        {
            // Arrange
            var args = new double[] { 1, 2, 3};
            double actualAreaValue;
            var p = (args[0] + args[1] + args[2]) / 2;
            double expectedResult = Math.Sqrt(p * (p - args[0]) * (p - args[1]) * (p - args[2]));

            // Act
            var result = Area.TryCalculateAreaFigure(out actualAreaValue, args);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedResult, actualAreaValue);
        }
    }
}