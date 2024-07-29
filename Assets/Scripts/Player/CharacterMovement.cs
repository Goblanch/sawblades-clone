using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Goblanch {
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour {

        [Header("Movement config")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float jumpHoldTime = .5f;
        [Header("Physics Config")]
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private Vector2 groundCheckOffset;
        [SerializeField] private Vector2 groundCheckSize;

        private Rigidbody2D rb;
        [HideInInspector] public Animator anim;
        private float _moveDirection;
        private bool _isJumping;
        private bool _canJump = true;
        private bool _isMoving;
        [SerializeField] private bool _isGrounded;
        private float _currentJumpHoldTime = 0;

        public bool IsMoving { get { return _isMoving; } }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + (Vector3)groundCheckOffset, groundCheckSize);
        }

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update() {
            GroundCheck();
            Move();
            Jump();
        }

        public void HandleMove(float moveAxis) {
            _moveDirection = moveAxis;

            if(moveAxis != 0) {
                anim.SetBool("Walking", true);
                _isMoving = true;
            } else {
                anim.SetBool("Walking", false);
                _isMoving = false;
            }
        }

        private void Move() {
            rb.velocity = new Vector2(_moveDirection * moveSpeed,rb.velocity.y);
            CheckScale();
        }

        private void CheckScale() {
            if (_moveDirection > 0) {
                FlipCharacterScale(1f);
            } else if (_moveDirection < 0) {
                FlipCharacterScale(-1f);
            }
        }

        public void FlipCharacterScale(float newScale) {
            transform.localScale = new Vector3(newScale, 1, 1);
        }


        public void HandleJump() {
            _isJumping = true;
        }

        private void Jump() {
            if(_isJumping && _canJump) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                JumpHoldTimer();
            }
        }

        private void JumpHoldTimer() {
            _currentJumpHoldTime += Time.deltaTime;
            if(_currentJumpHoldTime >= jumpHoldTime) {
                _isJumping = false;
                _canJump = false;
            }
        }

        public void HandleCancelledJump() {
            _isJumping = false;
            _canJump = false;
            //rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        private void GroundCheck() {
            Collider2D collision = Physics2D.OverlapBox(transform.position + (Vector3)groundCheckOffset, groundCheckSize, 0, groundMask);

            if(collision != null) {
                _isGrounded = true;
                _currentJumpHoldTime = 0;
                _canJump = true;
                rb.velocity = new Vector2(rb.velocity.x, 0);
            } else {
                _isGrounded = false;
                rb.velocity += new Vector2(0, gravity);
            }
        }
    }
}


