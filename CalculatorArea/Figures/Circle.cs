namespace CalculatorArea.Figures
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : IFigure
    {
        /// <summary>
        /// Радиус не должен быть отрицательным
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Круг с радиусом 1
        /// </summary>
        public Circle()
        {
            Radius = 1;
        }

        /// <summary>
        /// Круг с заданным радиусом
        /// </summary>
        /// <param name="radius">Радиус</param>
        /// <exception cref="ArgumentException"></exception>
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Radius can not be negative");
            }

            Radius = radius;
        }
        
        /// <summary>
        /// Вычисляет площадь круга
        /// </summary>
        /// <returns>Площадь круга</returns>
        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        /// <summary>
        /// Возможно ли вычислить площадь круга
        /// </summary>
        /// <param name="result">Переменная для записи результата</param>
        /// <param name="parameters">Массив аргументов</param>
        /// <returns>Если количество аргументов равно 1 и удалось вычислить площадь - true, иначе false</returns>
        public bool TryCalculateArea(out double result, params double[] parameters)
        {
            result = default;
            if (parameters.Length != 1)
            {
                return false;
            }

            try
            {
                var circle = new Circle(parameters[0]);
                result = circle.CalculateArea();
            }

            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
