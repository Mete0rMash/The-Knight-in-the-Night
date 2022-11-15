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

    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float distMin;
    [SerializeField] private Vector3 distToPlayerV3;
    bool canDetectPlayer = false;


    private RaycastHit2D hit;


    [SerializeField] private Transform lineOfSight;

    // Start is called before the first frame update
    void Start()
    {
        rangeSight = rangeSight * -1;
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
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

    private bool CanSeePlayer()
    {
        bool val = false;
        float castDist = rangeSight;
        Vector2 endPos = lineOfSight.position + Vector3.right * rangeSight;

        hit = Physics2D.Linecast(lineOfSight.position, endPos, 1 << LayerMask.NameToLayer("Wall"));
        if (hit.collider != null && !canDetectPlayer)
        {            
            distanceToPlayer = Vector2.Distance(this.transform.position, player.transform.position);
            float distToColl = Vector2.Distance(this.transform.position, hit.collider.transform.position);

            if (rangeSight < 0) //me fijo si el rango de vision es positivo, porque cambia depende hacia donde mire. si mira hacia la izquierda, es positivo, si mira hacia la derecha es negativo
            {
                
                if (distanceToPlayer > distToColl)
                {
                    //el player esta atras de un objeto, no lo puede ver
                    
                    canDetectPlayer = false;
                }
                else
                {
                    //podria ver al player
                    
                    canDetectPlayer = true;
                }
            }
            else if (rangeSight > 0)
            {               
                
                if (distanceToPlayer > distToColl)
                {                    
                    //el player esta atras de un objeto, no lo puede ver
                    canDetectPlayer = false;
                }
                else
                {
                    //podria ver al player
                    canDetectPlayer = true;
                }                
            }            
        }
        else
        {

            hit = Physics2D.Linecast(lineOfSight.position, endPos, 1 << LayerMask.NameToLayer("Player"));

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
                Debug.DrawLine(lineOfSight.position, hit.point, Color.red);
            }
            else
            {
                Debug.DrawLine(lineOfSight.position, endPos, Color.blue);
                canDetectPlayer = false;
            }
        }
        return val;
    }

    private void States()
    {     
        if (CanSeePlayer())
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

        distanceToPlayer = Vector2.Distance(this.transform.position, player.transform.position);
        if(distanceToPlayer > distMin)
        {
            Debug.Log("persuiting player");
            distToPlayerV3 = player.transform.position - this.transform.position;
            distToPlayerV3 = distToPlayerV3.normalized;
            this.transform.position += distToPlayerV3 * speed * Time.deltaTime;
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
