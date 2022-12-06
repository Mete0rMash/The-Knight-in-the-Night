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
        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posX", playerPos.y);
    }

    public void LoadGame()
    {
        Vector2 playerPos = new Vector2(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"));

        playerScript.SetPosition(playerPos);
    }

}
