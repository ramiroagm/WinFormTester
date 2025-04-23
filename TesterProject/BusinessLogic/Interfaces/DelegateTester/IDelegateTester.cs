namespace TesterProject.BusinessLogic.Interfaces.DelegateTester
{
    public interface IDelegateTester
    {
        delegate int OperacionMatematica(int a, int b);
        int Suma(int a, int b);
        int Resta(int a, int b);
    }
}
