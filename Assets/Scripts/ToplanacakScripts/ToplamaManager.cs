using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaManager : MonoBehaviour
{

    [SerializeField]
    bool mucevhermi, kirazmý;

    [SerializeField]
    GameObject toplamaEfekti;

    bool toplandimi;

    LevelManager levelManager;
    UIController uiController;
    playerHealthController PlayerHealthController;



    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uiController = Object.FindObjectOfType<UIController>();
        PlayerHealthController = Object.FindObjectOfType<playerHealthController>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !toplandimi)
        {
            if (mucevhermi)
            {
                levelManager.toplananMucevherSayisi++;

                toplandimi = true;

                Destroy(gameObject);

                uiController.mucevherSayisiniGuncelle();

                Instantiate(toplamaEfekti, transform.position, transform.rotation);
                SesController.instance.SesEfektiCikar(7);
            }
            if (kirazmý)
            {
                if (PlayerHealthController.gecerliSaglik != PlayerHealthController.maxSaglik)
                {
                    toplandimi = true;
                    Destroy(gameObject);
                    PlayerHealthController.CaniArttirFNC();
                    Instantiate(toplamaEfekti, transform.position, transform.rotation);
                    SesController.instance.SesEfektiCikar(4);
                }
            }
            
        }
    }
}
