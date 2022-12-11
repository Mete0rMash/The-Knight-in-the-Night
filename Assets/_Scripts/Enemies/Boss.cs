using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private int life = 500;
    [SerializeField] private float damame = 8.0f;
    [SerializeField] private GameObject player;
    public int speed;
    [SerializeField] public Animator anim;

    [SerializeField] private Collider2D collider; //su collider
    [SerializeField] private LayerMask ground;

    [SerializeField] private float distMin;
    [SerializeField] private Vector3 distToPlayerV3;
    [SerializeField] private float distanceToPlayer;

    [SerializeField] private bool facingRight;

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
            if (canMove)
            {
                ChasingPlayer();
            }

        }
        else
        {
            canMove = false;
        }
    }


    private void ChasingPlayer()
    {
        distanceToPlayer = Vector2.Distance(this.transform.position, player.transform.position);
        if (distanceToPlayer > distMin)
        {
            distToPlayerV3 = player.transform.position - this.transform.position;
            distToPlayerV3 = distToPlayerV3.normalized;
            this.transform.position += distToPlayerV3 * speed * Time.deltaTime;
            anim.SetBool("isMoving", true);
            anim.SetBool("isCloser", false);
        }
        else
        { 
            //canMove = false;
            Debug.Log("attacking player");
            anim.SetBool("isMoving", false);
            anim.SetBool("isCloser", true);
            //anim.SetTrigger("isAttacking");
            //canMove = true;
        }
        if (this.transform.position.x < player.transform.position.x) //si la posicion del enemigo es mas grande que la posicion del player, entonces el enemigo esta a la derecha del player, si es menor, entonces a la derecha
        {
            if (!facingRight)
            {
                InvertScale();
            }
        }
        else if (this.transform.position.x > player.transform.position.x)
        {
            if (facingRight)
            {
                InvertScale();
            }
        }
    }

    private void InvertScale()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);       
        facingRight = !facingRight;
    }


    public void GetDamage(float _damage)
    {

        //canMove = false;
        life = life - (int)_damage;
        anim.SetTrigger("getHit");

        if (life <= 0)
        {
            anim.SetBool("isDead", true);
            Destroy(this.gameObject);
        }
        //canMove = true;
    }



}
