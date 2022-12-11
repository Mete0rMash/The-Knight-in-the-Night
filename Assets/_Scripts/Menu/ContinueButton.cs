using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    private int escenaParaContinuar;

    public void ContinuarJuego() //Public void para continuar juego
    {
        escenaParaContinuar = PlayerPrefs.GetInt("EscenaGuardada");

        if (escenaParaContinuar != 0)
        {
            SceneManager.LoadScene(escenaParaContinuar);
        }
        else
            return;
    }
}
