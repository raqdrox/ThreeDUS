using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhysicsHandler : MonoBehaviour
{
    public int _groundLayer = 7;
    public int _envLayer = 8;
    public int _playerLayer =  9;
    public int _bodyLayer = 10;
    public int _ghostLayer = 11;

    //private int _ghostIgnoreMask => _envLayerMask | _playerLayerMask | _bodyLayerMask;
    //private int _aliveIgnoreMask => _ghostLayerMask | _bodyLayerMask;

    private void Awake()
    {
        Physics.IgnoreLayerCollision(_playerLayer, _ghostLayer);
        Physics.IgnoreLayerCollision(_playerLayer, _bodyLayer);
        Physics.IgnoreLayerCollision(_ghostLayer, _envLayer);
        Physics.IgnoreLayerCollision(_ghostLayer, _bodyLayer);
    }
}
