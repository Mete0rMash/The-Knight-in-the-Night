using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private RoomTemplates templates;

    [SerializeField] private string thisLevel;

    [SerializeField] int count = 10;
    //desde aca se inicia el juego, se instancia al player cundo el nivel se creo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(templates.GetRoomsActualCount() >= count)
        {
            GameObject[] spawners =  GameObject.FindGameObjectsWithTag("SpawnPoint");
            for (int i = 0; i < spawners.Length; i++)
            {
                Destroy(spawners[i]);
            }

            if (!IsExit())
            {
                SceneManager.LoadScene(thisLevel);
            }
            else
            {
                //playGame;
                //instanciar player
            }



        }

        //poner una condicion temporal, porque si son 4 salas nomas nunca llega al count, hacer un else en el if del count y le mandamos

    }
    private bool IsExit()
    {
        GameObject exit = GameObject.FindGameObjectWithTag("Exit");

        if(exit != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
