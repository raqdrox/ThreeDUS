using UnityEngine;
namespace FrostyPlayerSystem
{
    public interface IInputHandler
    {
        public Vector2 _movementAxis { get; }
        public Vector2 _camAxis { get; }
        public bool _jumpInput { get; }
        public bool _runInput { get; }
        public bool _miscKey1 { get; }
        public bool _miscKey2 { get; }
    }
}