using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Goblanch {
    public class PlayerController : GenericController {
        [SerializeField] private InputReader input;
        public CharacterMovement movement;
        public Animator anim;

        [SerializeField] private float speed;
        [SerializeField] private float jumpSpeed;

        private bool _isJumping;

        private void Awake() {
            anim = GetComponent<Animator>();
        }

        private void Start() {

            base.OnStart();

            input.MoveEvent += movement.HandleMove;

            input.JumpEvent += movement.HandleJump;
            input.JumpCancelledEvent += movement.HandleCancelledJump;

        }
    }
}

