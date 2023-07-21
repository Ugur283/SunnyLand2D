using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image Kalp1_Img, Kalp2_Img, Kalp3_Img;

    [SerializeField]

    Sprite doluKalp,yarýmKalp, bosKalp;

    

    [SerializeField]

    TMP_Text mucevherTxt;


    playerHealthController playerHealthController;
    LevelManager levelManager;


    public GameObject fadeScreen;


    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<playerHealthController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }

    public void SaglikDurumunuGüncelle()
    {
        switch (playerHealthController.gecerliSaglik)
        {
            case 6:
                Kalp1_Img.sprite = doluKalp;
                Kalp2_Img.sprite = doluKalp;
                Kalp3_Img.sprite = doluKalp;
                break;

            case 5:
                Kalp1_Img.sprite = doluKalp;
                Kalp2_Img.sprite = doluKalp;
                Kalp3_Img.sprite = yarýmKalp;
                break;

            case 4:
                Kalp1_Img.sprite = doluKalp;
                Kalp2_Img.sprite = doluKalp;
                Kalp3_Img.sprite = bosKalp;
                break;



            case 3:
                Kalp1_Img.sprite = doluKalp;
                Kalp2_Img.sprite = yarýmKalp;
                Kalp3_Img.sprite = bosKalp;
                break;

            case 2:
                Kalp1_Img.sprite = doluKalp;
                Kalp2_Img.sprite = bosKalp;
                Kalp3_Img.sprite = bosKalp;
                break;

            case 1:
                Kalp1_Img.sprite = yarýmKalp;
                Kalp2_Img.sprite = bosKalp;
                Kalp3_Img.sprite = bosKalp;
                break;

            case 0:
                Kalp1_Img.sprite = bosKalp;
                Kalp2_Img.sprite = bosKalp;
                Kalp3_Img.sprite = bosKalp;
                break;
        }
    }

    public void mucevherSayisiniGuncelle()
    {
        mucevherTxt.text = levelManager.toplananMucevherSayisi.ToString();
    }

    public void FadeEkraniAc()
    {
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
    }

    

}
