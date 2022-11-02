using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 movementInput;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        Debug.Log(movementInput);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Se apreto el boton de salto");
        }

        if (context.performed)
        {
            Debug.Log("Se esta manteniendo apretado el boton de salto");
        }

        if (context.canceled)
        {
            Debug.Log("Se solto el boton de salto");
        }
    }
}
