using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveSystem : MonoBehaviour
{
    Player playerScript;

    private void Awake()
    {
        playerScript = FindObjectOfType<Player>();
    }
    public void SaveGame()
    {
        Vector2 playerPos = playerScript.GetPosition();
    }

    public void LoadGame()
    {

    }

}
