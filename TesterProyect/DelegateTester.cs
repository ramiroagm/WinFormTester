using System.Data;
using TesterProyect.Interfaces;

namespace TesterProyect
{
    public class DelegateTester : IDelegateTester
    {
        public delegate int OperacionMatematica(int a, int b);

        public int Suma(int a, int b)
        {
            return a + b;
        }

        public int Resta(int a, int b)
        {
            return a - b;
        }
    }
}