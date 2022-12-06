using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openSide;

    //1 necesitamos un prefab con una puerta abajo
    //2 necesitamos un prefab con una puerta arriba
    //3 necesitamos un prefab con una puerta a la izquierda
    //4 necesitamos un prefab con una puerta a la derecha



    [SerializeField] private RoomTemplates templates;

    private int rand;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.2f);
    }
    void Spawn()
    {
        if (spawned == false)
        {
            if (openSide == 1)
            {
                //necesitamos un prefab con una puerta abajo
                rand = Random.Range(0, templates.bottonRooms.Length);
                Instantiate(templates.bottonRooms[rand], transform.position, templates.bottonRooms[rand].transform.rotation);
            }
            else if (openSide == 2)
            {
                //necesitamos un prefab con una puerta arriba
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openSide == 3)
            {
                //necesitamos un prefab con una puerta a la izquierda
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openSide == 4)
            {
                //necesitamos un prefab con una puerta a la derecha
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            Destroy(this.gameObject);            
        }
    }

}
