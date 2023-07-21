using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public enum tankDurumlarý {atesEtme,darbeAlma,hareketEtme,sonaErdi };
    public tankDurumlarý gecerliDurum;

    [SerializeField]
    Transform tankObje;
    public Animator anim;


    [Header("Hareket")]
    public float hareketHizi;
    public Transform solHedef, sagHedef;
    bool younuSagmý;
    public GameObject mayinObje;
    public Transform mayinMerkezNoktasi;
    public float mayinBirakmaSuresi;
    float mayinBirakmaSayac;



    [Header("AteþEtme")]
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiAtmaSayac;


    [Header("Darbe")]
    public float darbeSuresi;
    float darbeSayaci;

    [Header("CanDurumu")]
    public int canDurumu = 5;
    public GameObject tankPatlamaEfekti;
    bool yenildimi;
    public float mermiSuresiArtir, mayinBýrakmaSuresiArtir;



    public GameObject tankEziciKutu;


    private void Start()
    {
        gecerliDurum = tankDurumlarý.atesEtme;
    }

    private void Update()
    {
        switch (gecerliDurum)
        {
            case tankDurumlarý.atesEtme:
                //ates edildiðinde olacak durumlar

                mermiAtmaSayac -= Time.deltaTime;

                if (mermiAtmaSayac <= 0)
                {
                    mermiAtmaSayac = mermiAtmaSuresi;

                   var yeniMermi= Instantiate(mermi, mermiMerkezi.position, mermiMerkezi.rotation);
                    yeniMermi.transform.localScale = tankObje.localScale;
                }


                break;

            case tankDurumlarý.darbeAlma:
                //tank darbe aldýðýnda olusacak durumlar.
                if (darbeSayaci > 0)
                {
                    darbeSayaci -= Time.deltaTime;

                    if (darbeSayaci <= 0)
                    {
                        gecerliDurum = tankDurumlarý.hareketEtme;
                        mayinBirakmaSayac = 0;

                        if (yenildimi)
                        {
                            tankObje.gameObject.SetActive(false);
                            Instantiate(tankPatlamaEfekti, transform.position, transform.rotation);

                            gecerliDurum = tankDurumlarý.sonaErdi;
                        }
                    }
                }


                break;

            case tankDurumlarý.hareketEtme:
                //tank hareket ettiðinde olusacak durumlar.


                if (younuSagmý)
                {
                    tankObje.position += new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x > sagHedef.position.x)
                    {
                        tankObje.localScale = new Vector3(1, 1, 1);
                        younuSagmý = false;

                        HareketiDurdurFNC();
                    }
                }
                else
                {
                    tankObje.position -= new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x < solHedef.position.x)
                    {
                        tankObje.localScale = new Vector3(-1, 1, 1);

                        younuSagmý = true;

                        HareketiDurdurFNC();
                    }
                }

                mayinBirakmaSayac -= Time.deltaTime;
                if (mayinBirakmaSayac <= 0)
                {
                    mayinBirakmaSayac = mayinBirakmaSuresi;

                    Instantiate(mayinObje, mayinMerkezNoktasi.position, mayinMerkezNoktasi.rotation);
                }


                    break;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            DarbeAlFNC();
        }
    }

    public void DarbeAlFNC()
    {
        

        gecerliDurum = tankDurumlarý.darbeAlma;
        darbeSayaci = darbeSuresi;

        anim.SetTrigger("Vur");


        MayinController[] mayinlar = FindObjectsOfType<MayinController>();

        if (mayinlar.Length > 0)
        {
            foreach (MayinController bulunanMayin in mayinlar)
            {
                bulunanMayin.PatlamaFNC();
            }
        }

        canDurumu--;

        if (canDurumu <= 0)
        {
            yenildimi = true;
        }
        else
        {
            mermiAtmaSuresi /= mermiSuresiArtir;
            mayinBirakmaSuresi /= mayinBýrakmaSuresiArtir;
        }
    }


    void HareketiDurdurFNC()
    {
        tankEziciKutu.SetActive(true);

        gecerliDurum = tankDurumlarý.atesEtme;
        mermiAtmaSayac = mermiAtmaSuresi;

        anim.SetTrigger("HareketiDurdur");
    }
}
