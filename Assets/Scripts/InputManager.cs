using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace ATG.Input {
    public class InputManager : MonoBehaviour
    {

        public LayerMask ground;
        private InputActionAsset playerActions;
        private InputAction moveAction;
        private InputAction focusAction;
        private InputAction openWheelAction;

        private ButtonControl buttonControl;
        private RaycastHit hit;

        public void Start(){
            playerActions = GetComponent<PlayerInput>().actions;
            moveAction = playerActions.FindAction("Move");
            buttonControl = (ButtonControl)moveAction.controls[0];
            playerActions.Enable();
            ground = LayerMask.GetMask("Ground");
        }

        public void MovePlayer(){
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit, ground)) {
                Player.Instance.moving.Move(hit.point);
            }
        }

        public void Update(){
            if (buttonControl.wasPressedThisFrame || buttonControl.isPressed){
                MovePlayer();
            }
        }

        public void TriggerFocus(InputAction.CallbackContext action){
            if (action.performed == true){
                Focus.TriggerFocus();
            }
        }

        public void Fire1(){
            
        }
    }
}
