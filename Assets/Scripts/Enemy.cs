using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    [SerializeField] private int life = 100;
    [SerializeField] private float damame = 5.0f;
    [SerializeField] private float rangeSight = 5.0f;
    [SerializeField] private int actualState = 0;
    

    [SerializeField] private Collider2D forwardObj;

    [SerializeField] private GameObject player;


    public int speed;

    public Animator anim;   //su animator

    [SerializeField] private Collider2D collider; //su collider

    [SerializeField] private LayerMask ground;  //el layer del suelo para poder moverse

    [SerializeField] private LayerMask wall; //el layer de las paredes para poder rebotar

    [SerializeField] private LayerMask playerMask;

    private bool canMove;

    [SerializeField] private float distance;
    [SerializeField] private float distMin;
    [SerializeField] private Vector3 distToPlayer;

    private RaycastHit2D hit;


    [SerializeField] private Transform lineOfSight;

    // Start is called before the first frame update
    void Start()
    {
        rangeSight = rangeSight * -1;
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

    private bool CanSeePlayer(float _distance)
    {        
        bool val = false;        
        float castDist = _distance;
        Vector2 endPos = lineOfSight.position + Vector3.right * _distance;        
        hit = Physics2D.Linecast(lineOfSight.position, endPos, 1 << LayerMask.NameToLayer("Player"));
        Debug.DrawLine(lineOfSight.position, endPos, Color.red);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;               
            }
            else
            {
                val = false;
            }
        }    
        return val;
    }
    private void States()
    {     
        if (CanSeePlayer(rangeSight))
        {
            //PersuitState();
        }
        else
        {
            PatrolState();
        }
        /*
        switch (actualState)
        {
            case 0:
                PatrolState();

                break;
            case 1:
                //PersuitState(hit.rigidbody.gameObject);
                break;
        }
        */
    }
    private void PatrolState()
    {

        //cuando la escala es negativa (< 0) entonces va hacia la derecha, si es positiva (> 0) va hacia la izquierda
        

        if (forwardObj.IsTouchingLayers(wall))
        {
            InvertScale();
        }        
        else if (forwardObj.IsTouchingLayers(ground))
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
        rangeSight = rangeSight * -1;
    }

    private void PersuitState()
    {

        distance = Vector2.Distance(this.transform.position, player.transform.position);
        if(distance > distMin)
        {
            Debug.Log("persuiting player");
            distToPlayer = player.transform.position - this.transform.position;
            distToPlayer = distToPlayer.normalized;
            this.transform.position += distToPlayer * speed * Time.deltaTime;
        }
        else
        {
            Debug.Log("attacking player");
        }

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
