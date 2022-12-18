namespace TicTacToe.Factories
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}
