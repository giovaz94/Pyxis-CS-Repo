namespace Antonioni.Controller.Command
{
    public interface ICommand<TTarget>
    {
        void Execute(TTarget target);
    }
}