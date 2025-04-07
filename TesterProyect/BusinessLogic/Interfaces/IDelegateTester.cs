namespace TesterProject.BusinessLogic.Interfaces
{
    public interface IDelegateTester
    {
        delegate int OperacionMatematica(int a, int b);
        int Suma(int a, int b);
        int Resta(int a, int b);
    }
}
