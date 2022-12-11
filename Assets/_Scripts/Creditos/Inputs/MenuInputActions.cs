using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuInputActions : MonoBehaviour
{
    #region Pause Menu Variables
    //[SerializeField] private GameObject pantallaPausa;

    [SerializeField]
    private MenuData menuData;
    #endregion


 

    public void SkipCredits(InputAction.CallbackContext context)
    {
        if (menuData.creditos)
        {
            SceneManager.LoadScene("Menu_Principal");
        }
    }
}
