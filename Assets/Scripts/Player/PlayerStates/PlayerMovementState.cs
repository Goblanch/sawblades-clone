using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerState {

    [Header("Related States")]
    public string idleState;

    public override void StateEnter() {
        controller.movement.anim.Play(stateAnim);
    }

    public override void StateExit() {
        
    }

    public override void StateInput() {
        
    }

    public override void StateLateStep() {
        
    }

    public override void StatePhysicsStep() {
        
    }

    public override void StateStep() {
        if(!controller.movement.IsMoving) {
            stateMachine.SetState(idleState);
        }
    }
}
