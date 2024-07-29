using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Goblanch {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private InputReader input;
        [SerializeField] private CharacterMovement movement;

        [SerializeField] private float speed;
        [SerializeField] private float jumpSpeed;

        private bool _isJumping;

        private void Start() {
            input.MoveEvent += movement.HandleMove;

            input.JumpEvent += movement.HandleJump;
            input.JumpCancelledEvent += movement.HandleCancelledJump;

        }
    }
}

