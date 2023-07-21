using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthController : MonoBehaviour
{
    public int maxSaglik, gecerliSaglik;

    [SerializeField]
    GameObject yokOlmaEfekti;

    UIController uiController;

    public float yenilmezlikSuresi;
    float yenilmezlikSayaci;


    SpriteRenderer sr;


    playerController PlayerController;
    LevelManager levelManager;


    private void Awake()
    {
        PlayerController = Object.FindObjectOfType<playerController>();
        levelManager = Object.FindObjectOfType<LevelManager>();

        sr = GetComponent<SpriteRenderer>();
        uiController = Object.FindObjectOfType<UIController>();
    }

    private void Start()
    {
        gecerliSaglik = maxSaglik;
    }

    private void Update()
    {
        yenilmezlikSayaci -= Time.deltaTime;

        if (yenilmezlikSayaci <= 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }


    public void HasarAl()
    {
        if (yenilmezlikSayaci <= 0)
        {
            gecerliSaglik--;

            SesController.instance.SesEfektiCikar(1);

            if (gecerliSaglik <= 0)
            {
                gecerliSaglik = 0;
                gameObject.SetActive(false);
                levelManager.SahneyiBitir();
                Instantiate(yokOlmaEfekti, transform.position, transform.rotation);

                
            }
            else
            {
                yenilmezlikSayaci = yenilmezlikSuresi;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

                PlayerController.GeriTepmeFNC();
            }

            uiController.SaglikDurumunuGüncelle();
            
        }

        

    }

    public void CaniArttirFNC()
    {
        gecerliSaglik++;

        if (gecerliSaglik >= maxSaglik)
        {
            gecerliSaglik = maxSaglik;
        }
        uiController.SaglikDurumunuGüncelle();
    }
}
