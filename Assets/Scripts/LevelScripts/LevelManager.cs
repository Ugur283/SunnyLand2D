using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    playerController PlayerController;
    UIController uiController;

    public string sahneAdi;


    private void Awake()
    {
        
        instance = this;
        uiController = GameObject.FindObjectOfType<UIController>();
        PlayerController = GameObject.FindObjectOfType<playerController>();
    }

    public int toplananMucevherSayisi;

   


    public void SahneyiBitir()
    {
        StartCoroutine(SahneyiBitirRoutine());
        StartCoroutine(OlumSahnesi());
    }

    IEnumerator SahneyiBitirRoutine()
    {
        yield return new WaitForSeconds(.1f);
        PlayerController.hareketEtsinmi = false;

        yield return new WaitForSeconds(1f);
        uiController.FadeEkraniAc();

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sahneAdi);
    }

    IEnumerator OlumSahnesi()
    {
        yield return new WaitForSeconds(1f);
        uiController.FadeEkraniAc();
    }

    public void SonrakiBolumeGec(string bolumAdi)
    {
        // Bir sonraki bölüme geçiþ iþlemleri
        SceneManager.LoadScene(bolumAdi);
    }
}
