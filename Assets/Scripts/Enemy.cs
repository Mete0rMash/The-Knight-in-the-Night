using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    [SerializeField] private int life = 100;
    [SerializeField] private float damame = 5.0f;
    [SerializeField] private int rangeSight = 5;
    [SerializeField] private int actualState = 0;
    

    [SerializeField] private Collider2D forwarObj;


    public int speed;

    public Animator anim;   //su animator

    [SerializeField] private Collider2D collider; //su collider

    [SerializeField] private LayerMask ground;  //el layer del suelo para poder moverse

    [SerializeField] private LayerMask wall; //el layer de las paredes para poder rebotar

    private bool canMove;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Collider2D>().IsTouchingLayers(ground))
        {
            canMove = true;
            States();
        }
        else
        {
            canMove = false;
        }
        
    }


    private void States()
    {

      
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, rangeSight);
        
        /*
        if (hit.rigidbody.tag == "Player")
        {
            actualState = 1;
        }
        else
        {

        }*/

        switch (actualState)
        {
            case 0:
                PatrolState();

                break;
            case 1:
                PersuitState(hit.rigidbody.gameObject);

                break;
        }
        
    }

    private void PatrolState()
    {

        //cuando la escala es negativa (< 0) entonces va hacia la derecha, si es positiva (> 0) va hacia la izquierda
        

        if (forwarObj.IsTouchingLayers(wall))
        {
            InvertScale();
        }        
        else if (forwarObj.IsTouchingLayers(ground))
        {
            if (this.transform.localScale.x > 0)
            {
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else if (this.transform.localScale.x < 0)
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }
        } else InvertScale();
        

        
        




    }


    private void InvertScale()
    {
        transform.localScale = new Vector3(transform.localScale.x * - 1, transform.localScale.y, transform.localScale.z);
    }

    private void PersuitState(GameObject player)
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
