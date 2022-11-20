using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotatoBag : MonoBehaviour
{


    [SerializeField] private Text damageIndicator;
     

    // Start is called before the first frame update
    void Start()
    {
        if(damageIndicator == null)
        {
            damageIndicator = FindObjectOfType<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int damage)
    {
        damageIndicator.text = damage.ToString();
    }
}
