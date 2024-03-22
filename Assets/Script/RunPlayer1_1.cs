using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayer1_1 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgb;
    public int jumpower;
    private Animator anmi;
    private bool grounded;
    private bool canDoubleJump;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {

        rgb = GetComponent<Rigidbody2D>();
        anmi = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
            anmi.SetBool("Run", true);
            if (Input.GetKey(KeyCode.J))
            {
                RunAttack();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
            anmi.SetBool("Run", true);
            if (Input.GetKey(KeyCode.J))
            {
                RunAttack();
            }
        }
        else
        {
            anmi.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.J))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.W) && canDoubleJump)
        {
            DoubleJump();
        }
        anmi.SetBool("Grounded", grounded);
    }
    private void Attack()
    {
        anmi.SetTrigger("Attack");
        Vector2 pointA = attackPoint.position;
        Vector2 pointB = pointA + new Vector2(attackRange, 0f);
        Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(pointA, pointB, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
        }
    }
    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void RunAttack()
    {
        anmi.SetTrigger("RunAttack");
    }
    private void Jump()
    {
        rgb.velocity = new Vector3(rgb.velocity.x, jumpower);
        anmi.SetTrigger("Jump");
        if (grounded)
        {
            canDoubleJump = true; 
        }
        else
        {
            canDoubleJump = false; 
        }
        grounded = false;
    }
    private void DoubleJump()
    {
        rgb.velocity = new Vector3(rgb.velocity.x, jumpower);
        anmi.SetTrigger("DoubleJump");
        canDoubleJump = false;
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Titlemap")
        {
            grounded = true;
        }
    }
}
