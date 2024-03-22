using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleShotgun : MonoBehaviour
{
    public float Scalesqd;
    public float minScale, maxScale;

    Vector2 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        scale = new Vector2(Mathf.Clamp(scale.x += Scalesqd * Time.deltaTime, minScale, maxScale), scale.y);
        scale = new Vector2(scale.x, Mathf.Clamp(scale.y += Scalesqd * Time.deltaTime, minScale, maxScale));

        transform.localScale = scale;
    }
}
