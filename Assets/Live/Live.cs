using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
    [SerializeField] private float startingLive;
    public float currentLive { get; private set; }
    private Animator anim;
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

        }
        else
        {

        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Death(1);
        }
    }
}
