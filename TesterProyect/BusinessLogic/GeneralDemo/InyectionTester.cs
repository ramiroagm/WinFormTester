using TesterProyect.BusinessLogic.Interfaces;

namespace TesterProyect.BusinessLogic.GeneralDemo
{
    public class InyectionTester : IInyectionTester
    {
        public string DevuelveStringTrim(string miString)
        {
            string result = string.IsNullOrEmpty(miString) ? "" : miString.Trim();
            return "Result string: " + result;
        }

        public int DevuelveSuma(int sumA, int sumB)
        {
            return sumA + sumB;
        }
    }
}
