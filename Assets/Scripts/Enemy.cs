using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int life = 100;
    [SerializeField] private float damame = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GetDamage(float _damage)
    {
        life = life - (int)_damage;

        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
