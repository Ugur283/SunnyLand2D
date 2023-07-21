using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEziciController : MonoBehaviour
{

    playerController PlayerController;
    TankController tankController;


    private void Awake()
    {
        PlayerController = Object.FindObjectOfType<playerController>();
        tankController = Object.FindObjectOfType<TankController>();
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& PlayerController.transform.position.y>transform.position.y)
        {
            PlayerController.ZiplaZiplaFNC();

            tankController.DarbeAlFNC();

            gameObject.SetActive(false);
        }
    }
}
