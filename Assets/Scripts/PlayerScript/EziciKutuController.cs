using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EziciKutuController : MonoBehaviour
{

    [SerializeField]
    GameObject yokOlmaEfekti;


    playerController PlayerController;


    public float kirazCikmaSansi;

    public GameObject kirazObje;

    private void Awake()
    {
        PlayerController = Object.FindObjectOfType<playerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Kurbaga"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(yokOlmaEfekti, transform.position, transform.rotation);

            PlayerController.ZiplaZiplaFNC();

            float cikmaAraligi= Random.Range(0f, 100f);


            SesController.instance.SesEfektiCikar(0);

            if (cikmaAraligi <= kirazCikmaSansi)
            {
                Instantiate(kirazObje, other.transform.position, other.transform.rotation);
            }
        }else if (other.CompareTag("Kartal"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(yokOlmaEfekti, transform.position, transform.rotation);

            PlayerController.ZiplaZiplaFNC();

            float cikmaAraligi = Random.Range(0f, 100f);


            SesController.instance.SesEfektiCikar(0);
        }
    }
}
