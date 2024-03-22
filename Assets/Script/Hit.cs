using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Live p1;
    public LiveP2 p2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            collision.gameObject.GetComponent<Live>().Hurt();
        }
        if (collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<LiveP2>().Hurt();
        }
    }
}
