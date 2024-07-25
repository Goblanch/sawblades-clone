using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Goblanch {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private InputReader input;

        [SerializeField] private float speed;
        [SerializeField] private float jumpSpeed;

        private float _moveDirection;

        private bool _isJumping;

        private void Start() {
            input.MoveEvent += HandleMove;

            input.JumpEvent += HandleJump;
            input.JumpCancelledEvent += HandleCancelledJump;
        }

        private void Update() {
            Move();
            Jump();
        }

        private void HandleMove(float moveAxis) {
            _moveDirection = moveAxis;
        }

        private void HandleJump() {
            _isJumping = true;
        }

        private void HandleCancelledJump() {
            _isJumping = false;
        }

        private void Move() {
            // TODO. JUST DEBUG PURPOSES
            if(_moveDirection   != 0) {
                Debug.Log("Me muevo");
            } 
        }

        private void Jump() {
            if(_isJumping) {
                Debug.Log("Estoy saltando");
            }
        }
    }
}

