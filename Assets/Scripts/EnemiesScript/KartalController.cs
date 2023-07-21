using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartalController : MonoBehaviour
{
    public float hareketHizi;

    public Transform solHedef, sagHedef;

    private bool sagTarafta;

    Rigidbody2D rb;

    public SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        solHedef.parent = null;
        sagHedef.parent = null;

        sagTarafta = true;
    }

    private void Update()
    {
        if (sagTarafta)
        {
            rb.velocity = new Vector2(hareketHizi, rb.velocity.y);

            sr.flipX = true;

            if (transform.position.x > sagHedef.position.x)
            {
                sagTarafta = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-hareketHizi, rb.velocity.y);

            sr.flipX = false;

            if (transform.position.x < solHedef.position.x)
            {
                sagTarafta = true;
            }
        }
    }
}
