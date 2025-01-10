using TesterProyect.Interfaces;

namespace TesterProyect
{
    public class InyectionTester : IInyectionTester
    {
        public string? DevuelveStringTrim(string miString)
        {
            return "Result string: " + miString?.Trim();
        }

        public int DevuelveSuma(int sumA, int sumB)
        {
            return sumA + sumB;
        }
    }
}
