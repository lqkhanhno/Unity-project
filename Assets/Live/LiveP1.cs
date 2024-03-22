using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Live : MonoBehaviour
{
    [SerializeField] private float startingLive;
    public float currentLive { get; private set; }
    private Animator anim;
    public GameObject respawnPoint;
    public static event Action player1Dead;
    private void Awake()
    {
        currentLive = startingLive;
        anim = GetComponent<Animator>();
    }
    public void Death(float death)
    {
        currentLive--;
        if (currentLive > 0)
        {
            transform.position = respawnPoint.transform.position;
        }
        else
        {
            player1Dead?.Invoke();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            Death(1);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            anim.SetTrigger("Damage");
        }

    }
    public void Hurt()
    {
        anim.SetTrigger("Damage");
        Debug.Log("p1");
    }
}
