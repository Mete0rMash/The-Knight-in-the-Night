using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotatoBag : MonoBehaviour
{

    [SerializeField] private Text damageIndicator;

    [SerializeField] private GameObject gameText;
     
    public void GetDamage(int damage)
    {       
        gameText.GetComponent<TextMesh>().text = damage.ToString();
    }
}
