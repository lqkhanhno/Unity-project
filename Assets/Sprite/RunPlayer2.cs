using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayer2 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgb;
    public int jumpower;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        jumpower = 9;
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rgb.AddForce(Vector2.up * jumpower, ForceMode2D.Impulse);
        }
    }
}
