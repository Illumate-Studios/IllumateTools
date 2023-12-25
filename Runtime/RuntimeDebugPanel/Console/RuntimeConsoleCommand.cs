namespace Illumate.RuntimeDebugPanel
{
    public abstract class RuntimeConsoleCommand
    {
        public virtual string Command => GetType().Name;
        public abstract string Description { get; }

        public abstract string Execute(string[] parameters);
    }
}
