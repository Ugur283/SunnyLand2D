using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiController : MonoBehaviour
{
    public float mermiHizi;

    playerHealthController PlayerHealthController;

    private void Awake()
    {
        PlayerHealthController = Object.FindObjectOfType<playerHealthController>();
    }


    private void Update()
    {
        transform.position += new Vector3(-mermiHizi *transform.localScale.x* Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController.HasarAl();
        }

        Destroy(gameObject);
    }
}
