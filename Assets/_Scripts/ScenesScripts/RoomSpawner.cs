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

    public int count = 1;
    int actualRoom = 0;

    [SerializeField] private RoomTemplates templates;

    private GameObject lastCreatedRoom;

    [SerializeField] Collider2D coll;

    private int rand;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        coll = this.gameObject.GetComponent<BoxCollider2D>();
        Invoke("Spawn", 0.5f);
    }
    void Spawn()
    {
        if (spawned == false)
        {
            if (openSide == 1)
            {
                //necesitamos un prefab con una puerta abajo              
                rand = Random.Range(0, templates.bottonRooms.Length);
                lastCreatedRoom = Instantiate(templates.bottonRooms[rand], transform.position, templates.bottonRooms[rand].transform.rotation);
                
                
            }
            else if (openSide == 2)
            {
                //necesitamos un prefab con una puerta arriba
                rand = Random.Range(0, templates.topRooms.Length);
                lastCreatedRoom = Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openSide == 3)
            {
                //necesitamos un prefab con una puerta a la izquierda
                rand = Random.Range(0, templates.leftRooms.Length);
                lastCreatedRoom = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openSide == 4)
            {
                //necesitamos un prefab con una puerta a la derecha
                rand = Random.Range(0, templates.rightRooms.Length);
                lastCreatedRoom = Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            templates.AddCreatedRoom(lastCreatedRoom, actualRoom);
            actualRoom += 1;

            
            spawned = true;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("SpawnPoint"))
        {
            if (count == 0)
            {
                Destroy(collision.gameObject);
                //Destroy(this.gameObject);
            }
            count = 0;
            
        }
    }

}
