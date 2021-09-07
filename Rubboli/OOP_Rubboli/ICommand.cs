namespace OOP_Rubboli
{
    public interface ICommand<T>
    {
        void Execute(T target);
    }
}