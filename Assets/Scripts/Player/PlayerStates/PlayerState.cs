using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goblanch;

public abstract class PlayerState : StateBase {

    public PlayerController controller;
    public string stateAnim;

    public abstract override void StateEnter();

    public abstract override void StateExit();

    public abstract override void StateInput();

    public abstract override void StateLateStep();

    public abstract override void StatePhysicsStep();

    public abstract override void StateStep();
}
