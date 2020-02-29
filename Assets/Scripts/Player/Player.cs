using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Player : SingletonBehaviour<Player>
{
    public PlayerMovementController movementController;
    public PlayerArrowController arrowController;
    public PlayerThrowableController throwableController;

    protected override void Awake()
    {
        base.Awake();

        movementController = GetComponent<PlayerMovementController>();
        arrowController = GetComponent<PlayerArrowController>();
        throwableController = GetComponent<PlayerThrowableController>();
    }
}
