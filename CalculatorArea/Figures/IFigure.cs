namespace CalculatorArea.Figures
{
    public interface IFigure
    {
        bool TryCalculateArea(out double result, params double[] parameters);

        double CalculateArea();
    }
}
