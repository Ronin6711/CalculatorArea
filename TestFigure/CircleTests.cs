using CalculatorArea;
using CalculatorArea.Figures;

namespace TestFigure
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void CalculateArea_MustReturnRightValue()
        {
            // Arrange
            var radius = 3;
            var circle = new Circle(radius);
            var expectedResult = Math.PI * Math.Pow(radius, 2);

            // Act
            var actualAreaValue = circle.CalculateArea();

            //Assert
            Assert.AreEqual(expectedResult, actualAreaValue);
        }

        [Test]
        public void TryCalculateArea_MustReturnTrue_IfArgsCountOne()
        {
            // Arrange
            var args = new double[] { 3 };
            double actualAreaValue;
            var circle = new Circle();
            var expectedResult = Math.PI * Math.Pow(args[0], 2);

            // Act
            var result = circle.TryCalculateArea(out actualAreaValue, args);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedResult, actualAreaValue);
        }

        [Test]
        public void TryCalculateArea_MustReturnFalse_IfArgsCountNotEqualsOne()
        {
            // Arrange
            var args = new double[] { 3, 5, 6 };
            double actualAreaValue;
            var circle = new Circle();
            double expectedResult = default;

            // Act
            var result = circle.TryCalculateArea(out actualAreaValue, args);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(expectedResult, actualAreaValue);
        }

        [Test]
        public void ConstructorCircle_MustSetRightRadius()
        {
            // Arrange
            var radius = 3;

            // Act
            var circle = new Circle(radius);

            //Assert
            Assert.AreEqual(radius, circle.Radius);
        }

        [Test]
        public void ConstructorCircle_ArgumentException_IfNegativeRadius()
        {
            // Arrange
            var radius = -1;

            // Act

            //Assert
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }
    }
}
