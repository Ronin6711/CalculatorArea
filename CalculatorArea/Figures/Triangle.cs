namespace CalculatorArea.Figures
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : IFigure
    {
        /// <summary>
        /// Стороны треугольника
        /// </summary>
        public double SideA { get; set; }

        public double SideB { get; set; }

        public double SideC { get; set; }

        /// <summary>
        /// Треугольник со сторонами 1
        /// </summary>
        public Triangle()
        {
            SideA = 1;
            SideB = 1;
            SideC = 1;
        }

        /// <summary>
        /// Треугольник с заданными сторонами
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Side can not be negative");
            }

            if (sideA + sideB < sideC || sideA + sideC < sideB || sideB + sideC < sideA)
            {
                throw new ArgumentException("Impossible triangle");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public double CalculateArea()
        {
            var p = (SideA + SideB + SideC) / 2;

            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC)); 
        }

        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным
        /// </summary>
        /// <returns>Если треугольник прямоугольный - true, иначе false</returns>
        public bool TriangleIsRight()
        {
            if ((SideA * SideA + SideB * SideB - SideC * SideC) == 0 ||
                (SideA * SideA + SideC * SideC - SideB * SideB) == 0 ||
                (SideC * SideC + SideB * SideB - SideA * SideA) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Возможно ли вычислить площадь треугольника
        /// </summary>
        /// <param name="result">Переменная для записи результата</param>
        /// <param name="parameters">Массив аргументов</param>
        /// <returns>Если количество аргументов равно 3 и удалось вычислить площадь - true, иначе false</returns>
        public bool TryCalculateArea(out double result, params double[] parameters)
        {
            result = default;
            if (parameters.Length != 3)
            {
                return false;
            }

            try
            {
                var triangle = new Triangle(parameters[0], parameters[1], parameters[2]);
                result = triangle.CalculateArea();
            }

            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
