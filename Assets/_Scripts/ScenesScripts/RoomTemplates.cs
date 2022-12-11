using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottonRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject[] createdRooms;

    




    public int GetRoomsActualCount()
    {
        return createdRooms.Length;
    }

    public void RestartLevel()
    {
        for (int i = 0; i < createdRooms.Length; i++)
        {
            Destroy(createdRooms[i].gameObject);
        }
    }

    public void AddCreatedRoom(GameObject newRoom, int i)
    {
       
        createdRooms[i] = newRoom;
        
        
    }



}
