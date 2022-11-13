using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PasarCreditos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("EsperaFinal", 58f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu_Principal");
        }
    }

    public void EsperaFinal()
    {
        SceneManager.LoadScene("Menu_Principal");
    }
}
