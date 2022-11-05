using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesPropiedades : MonoBehaviour
{
    public ControlaOpciones panelOpciones;
    // Start is called before the first frame update
    void Start()
    {
       // panelOpciones = GameObject.FindGameObjectWithTag("opciones").GetComponent<ControlaOpciones>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrameOpciones()
    {
        panelOpciones.pantallaOpciones.SetActive(true);
    }
}
