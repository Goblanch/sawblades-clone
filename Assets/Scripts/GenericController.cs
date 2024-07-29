using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericController : MonoBehaviour
{
    public StateMachineController stateMachine;

    private void Start() {
        OnStart();
    }

    private void Update() {
        OnUpdate();
    }

    private void FixedUpdate() {
        OnFixedUpdate();
    }

    private void LateUpdate() {
        OnLateUpdate();
    }

    public void OnStart() {
        stateMachine.Initialize();
        Debug.Log("State Machine Initialized");
    }

    public void OnUpdate() {
        stateMachine.Step();
    }

    public void OnFixedUpdate() {
        stateMachine.PhysicsStep();
    }

    public void OnLateUpdate() {
        stateMachine.LateStep();
    }
}
