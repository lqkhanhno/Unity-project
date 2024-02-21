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

    // Start is called before the first frame update
    void Start()
    {
        speed = 7f;
        jumpower = 6;
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
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
            anmi.SetBool("Run", true);
        }
        else
        {
            anmi.SetBool("Run", false);
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
    private void Jump()
    {
        rgb.velocity = new Vector3(rgb.velocity.x, speed);
        anmi.SetTrigger("Jump");
        if (grounded)
        {
            canDoubleJump = true; // Khi nh?y t? m?t ??t, cho phép double jump
        }
        else
        {
            canDoubleJump = false; // N?u không ? tr?ng thái m?t ??t, không th? double jump
        }
        grounded = false;
    }
    private void DoubleJump()
    {
        rgb.velocity = new Vector3(rgb.velocity.x, speed);
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
