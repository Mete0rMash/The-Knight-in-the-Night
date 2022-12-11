using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroyBrillo : MonoBehaviour
{
    private static DontDestroyBrillo instance;
    //[SerializeField] private GameObject pantallaBrillo;
    //public Image Panel;
    //public GameObject brilloPanel;

    /*private void Start()
    {
        brilloPanel = FindObjectOfType<DontDestroyBrillo>().gameObject;
        
    }*/ //borrar

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
        }

    }

    /*private void Update()
    {
        pantallaBrillo.SetActive(true);//comentar, no creo que ande
    }*/
}
