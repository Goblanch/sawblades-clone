using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEditor.VersionControl;

namespace Goblanch {
    [CreateAssetMenu(menuName = "InputReader")]
    public class InputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.IUIActions {

        private GameInput _gameInput;

        private void OnEnable() {
            if(_gameInput == null ) {
                _gameInput = new GameInput();

                _gameInput.Gameplay.SetCallbacks( this );
                _gameInput.UI.SetCallbacks( this );

                SetGameplay();
            }
        }

        public void SetGameplay() {
            _gameInput.Gameplay.Enable();
            _gameInput.UI.Disable();
        }

        public void SetUI() {
            _gameInput.Gameplay.Disable();
            _gameInput.UI.Enable();
        }

        public event Action<float> MoveEvent;

        public event Action JumpEvent;
        public event Action JumpCancelledEvent;

        public event Action PauseEvent;
        public event Action ResumeEvent;

        
        public void OnMove(InputAction.CallbackContext context) {
            //Debug.Log(message: $"Phase: {context.phase}, Value: {context.ReadValue<float>()}");
            MoveEvent?.Invoke(context.ReadValue<float>());
        }

        public void OnJump(InputAction.CallbackContext context) {
            if(context.phase == InputActionPhase.Performed) {
                JumpEvent?.Invoke();
            }
            if(context.phase == InputActionPhase.Canceled) {
                JumpCancelledEvent?.Invoke();
            }
        }

        public void OnPause(InputAction.CallbackContext context) {
            if(context.phase == InputActionPhase.Performed) {
                PauseEvent?.Invoke();
                SetUI();
            }
        }

        public void OnResume(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Performed) {
                ResumeEvent?.Invoke();
                SetGameplay();
            }
        }
    }
}


