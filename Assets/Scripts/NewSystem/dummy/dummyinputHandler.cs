using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyinputHandler : MonoBehaviour, FrostyPlayerSystem.IInputHandler
{
    public Vector2 _movementAxis => Vector2.zero;

    public Vector2 _camAxis => Vector2.zero;

    public bool _jumpInput => false;

    public bool _runInput => false;

    public bool _miscKey1 => false;

    public bool _miscKey2 => false;
}
