using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private RoomTemplates templates;

    [SerializeField] private string thisLevel;

    [SerializeField] int count = 10;
    public int minRooms;

    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject player;

    bool spawned = false;
    public float time = 0;
    //desde aca se inicia el juego, se instancia al player cundo el nivel se creo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;

        if(templates.GetRoomsActualCount() >= count || time > 6)
        {

            GameObject[] spawners =  GameObject.FindGameObjectsWithTag("SpawnPoint");
            for (int i = 0; i < spawners.Length; i++)
            {
                Destroy(spawners[i]);
            }

            if (!IsExit() && templates.GetRoomsActualCount() < minRooms)
            {
                SceneManager.LoadScene(thisLevel);
            }
            else
            {
                //playGame;
                //instanciar player
                if (!spawned)
                {
                    Instantiate(player, playerPos.position, Quaternion.identity);
                    spawned = true;

                }

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
