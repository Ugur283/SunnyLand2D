using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayinController : MonoBehaviour
{

    public GameObject patlamaEfekti;

    playerHealthController PlayerHealthController;

    private void Awake()
    {
        PlayerHealthController = Object.FindObjectOfType<playerHealthController>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PatlamaFNC();

            PlayerHealthController.HasarAl();
        }
    }


    public void PatlamaFNC()
    {
        Destroy(this.gameObject);

        Instantiate(patlamaEfekti, transform.position, transform.rotation);
    }


}
