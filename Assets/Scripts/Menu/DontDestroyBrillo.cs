using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBrillo : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BrilloMenu");
        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
