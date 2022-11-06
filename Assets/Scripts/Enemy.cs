using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction
{
    Up,
    Down,
    Right,
    Left
}


public class Enemy : MonoBehaviour
{

    [SerializeField] private int life = 100;
    [SerializeField] private float damame = 5.0f;
    [SerializeField] private int rangeSight = 5;
    [SerializeField] private int actualState = 0;
    [SerializeField] private SpriteRenderer _spriteRenderer;


    public int speed;

    [SerializeField] private GameObject leftWall;   // para saber donde dar la vuelta y caminar al otro lado (buscar la forma de hacerlo sin necesidad de esto, con el layerMask)

    [SerializeField] private GameObject rightWall;  // para saber donde dar la vuelta y caminar al otro lado (buscar la forma de hacerlo sin necesidad de esto, con el layerMask)

    public Animator anim;   //su animator

    [SerializeField] private Collider2D collider; //su collider

    [SerializeField] private LayerMask ground;  //el layer del suelo para poder moverse
    

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
        }
        else
        {
            canMove = false;
        }
        States();
    }


    private void States()
    {

      
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, rangeSight);
        
        if (hit.rigidbody.tag == "Player")
        {
            actualState = 1;
        }
        else
        {

        }

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
        if (!_spriteRenderer.flipX)
        {
            if (this.transform.position.x > leftWall.transform.position.x)
            {
                if (_spriteRenderer.flipX != false)
                {
                    _spriteRenderer.flipX = false;
                }
                if (GetComponent<Collider2D>().IsTouchingLayers(ground))
                {
                    this.transform.position += Vector3.left * speed * Time.deltaTime;
                }
            }
            else _spriteRenderer.flipX = true;
        }
        else
        {
            
            if (this.transform.position.x < rightWall.transform.position.x)
            {
            
                if (_spriteRenderer.flipX != true)
                {
                    _spriteRenderer.flipX = true;
                }
                if (GetComponent<Collider2D>().IsTouchingLayers(ground))
                {
                    this.transform.position += Vector3.right * speed * Time.deltaTime;
                }
                
            }

            else _spriteRenderer.flipX = false;
        }

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
