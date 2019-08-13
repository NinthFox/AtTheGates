using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public LayerMask ground;

    public void MovePlayer(InputAction.CallbackContext context){
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
            Debug.Log("Hit");
            Player.Instance.agent.destination = hit.point;
        }
    }
}
