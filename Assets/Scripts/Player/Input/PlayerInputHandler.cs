using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawRollDirectionInput { get; private set; }
    public int RollDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrabInput { get; private set; }
    public bool RollInput { get; private set; }
    public bool RollInputStop { get; private set; }

    public bool[] AttackInputs { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;
    private float rollInputStartTime;

    #region Pause Menu Variables
    [SerializeField] private GameObject pantallaPausa;

    [SerializeField]
    private MenuData menuData;
    #endregion

    private void Start()
    {
        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckRollInputHoldTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (!menuData.juegoEnPausa)
        {
            RawMovementInput = context.ReadValue<Vector2>();

            NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.y);
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

    public void OnRollInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RollInput = true;
            RollInputStop = false;
            rollInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            RollInputStop = true;
        }
    }

    public void OnRollDirectionInput(InputAction.CallbackContext context)
    {
        RawRollDirectionInput = context.ReadValue<Vector2>();

        RollDirectionInput = (int)(RawRollDirectionInput * Vector2.right).normalized.x;
    }

    public void UseJumpInput() => JumpInput = false;

    public void UseRollInput() => RollInput = false;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    private void CheckRollInputHoldTime()
    {
        if (Time.time >= rollInputStartTime + inputHoldTime)
        {
            RollInput = false;
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

public enum CombatInputs
{
    primary,
    secondary
}
