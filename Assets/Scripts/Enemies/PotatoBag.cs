using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotatoBag : MonoBehaviour
{

    [SerializeField] private TextMeshPro damageIndicator;

    [SerializeField] private GameObject gameText;

    [SerializeField] private float time;

    [SerializeField] private int _damage;

    bool runingTime = false;


    private bool runTime()
    {
        time += Time.deltaTime;
        if(time > 3)
        {
            runingTime = false;
            time = 0;
            return false;
            
        }
        runingTime = true;
        return true;        
    }


    private void Update()
    {
        /*
        if (runingTime)
        {
            if (runTime())
            {
                damageIndicator.text = _damage.ToString();
            }
            else
            {
                damageIndicator.text = "";
            }
        }
        */
        if (runTime())
        {
            damageIndicator.text = _damage.ToString();
        }
        else
        {
            damageIndicator.text = "";
        }

    }


    public void GetDamage(int damage)
    {        
        damageIndicator.text = damage.ToString();
        _damage = damage;
        runingTime = true;
    }
}
