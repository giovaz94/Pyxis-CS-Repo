namespace Antonioni.Controller.Command
{
    public interface ICommand<TTarget>
    {
        /// <summary>
        /// Executes the command action in the target.
        /// </summary>
        /// <param name="target">
        /// The target where the action should be executed.
        /// </param>
        void Execute(TTarget target);
    }
}