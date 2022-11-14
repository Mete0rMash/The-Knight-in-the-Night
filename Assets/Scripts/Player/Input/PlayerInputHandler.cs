using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrabInput { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;

    #region Pause Menu Variables
    [SerializeField] private GameObject pantallaPausa;

    [SerializeField]
    private MenuData menuData;
    #endregion

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (!menuData.juegoEnPausa)
        {
            RawMovementInput = context.ReadValue<Vector2>();

            if (Mathf.Abs(RawMovementInput.x) > 0.5f)
            {
                NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
            }
            else
            {
                NormInputX = 0;
            }

            if (Mathf.Abs(RawMovementInput.y) > 0.5f)
            {
                NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
            }
            else
            {
                NormInputY = 0;
            }
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (!menuData.juegoEnPausa)
        {
            if (context.started)
            {
                JumpInput = true;
                JumpInputStop = false;
                jumpInputStartTime = Time.time;
            }

            if (context.canceled)
            {
                JumpInputStop = true;
            }
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (!menuData.juegoEnPausa)
        {
            if (context.started)
            {
                GrabInput = true;
            }
            if (context.canceled)
            {
                GrabInput = false;
            }
        }
    }

    public void UseJumpInput() => JumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }


    #region Pause Menu Input
    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (menuData.juegoEnPausa)
            {
                Reanudando();
            }
            else
            {
                Pausado();
            }
        }
    }

    public void Pausado()
    {
        menuData.juegoEnPausa = true;
        Time.timeScale = 0f;
        pantallaPausa.SetActive(true);

    }

    public void Reanudando()
    {
        menuData.juegoEnPausa = false;
        Time.timeScale = 1f;
        pantallaPausa.SetActive(false);
    }

    public void CerrarJuego() // por si queremos agregar opción de cerrar juego.
    {
        Debug.Log("Se cierra el juego");
        Application.Quit();
    }

    public void MenuOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu_Principal");
    }
    #endregion
}
