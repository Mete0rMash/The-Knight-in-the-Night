using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MenuMusic");
        //GameObject[] JuegoMusic = GameObject.FindGameObjectsWithTag("JuegoMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        //if (JuegoMusic.Length > 1)
       //{
            //Destroy(this.gameObject);
        //}
        
    }
}
