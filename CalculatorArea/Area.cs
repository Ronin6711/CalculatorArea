using CalculatorArea.Figures;

namespace CalculatorArea
{
    public static class Area
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">Переменная для записи рузельтата</param>
        /// <param name="parameters">Массив передаваемых аргументов</param>
        /// <returns>Если есть фигура, у которой можно вычислить площадь по переданным аргументам -
        /// - true, иначе false</returns>
        public static bool TryCalculateAreaFigure(out double result, params double[] parameters)
        {
            result = default;

            var validFigures = typeof(Area).Assembly.ExportedTypes
                .Where(x => typeof(IFigure).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IFigure>()
                .ToList();

            foreach (var figure in validFigures)
            {
                if (figure.TryCalculateArea(out result, parameters))
                {
                    return true;
                }
            }

            return false;
        }
    }
}