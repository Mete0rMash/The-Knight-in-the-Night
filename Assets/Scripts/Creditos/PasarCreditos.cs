using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarCreditos : MonoBehaviour
{
    [SerializeField]
    private MenuData menuData;

    // Start is called before the first frame update
    void Start()
    {
        menuData.creditos = true;
        Invoke("EsperaFinal", 58f);
    }

    public void EsperaFinal()
    {
        SceneManager.LoadScene("Menu_Principal");
    }
}
