using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesEntreEscenas : MonoBehaviour
{
    private void Awake()
    {
        var noDestruyasEntreEscenas = FindObjectsOfType<OpcionesEntreEscenas>();
        if (noDestruyasEntreEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }                                 // que no hayan cosas duplicadas de opciones

        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
