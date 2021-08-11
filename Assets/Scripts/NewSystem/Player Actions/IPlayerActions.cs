namespace FrostyPlayerSystem
{
    public interface IPlayerActions
    {
        public string _taskName { get; }
        public bool hasStartedAction { get; }
        public void StartAction();
        public void Perform();
        public void EndAction();
    }
}