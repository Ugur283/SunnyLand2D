using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MainMenuController : MonoBehaviour
{
    public string sahneAdi;
    public string bolumSahne;
   

    public GameObject resimObje;
    public GameObject baslaBtn, cikisBtn, bolumBtn; 


    public GameObject fadeScreen;


    private void Start()
    {
        StartCoroutine(SiraylaAcRoutine());
    }


    IEnumerator SiraylaAcRoutine()
    {
        yield return new WaitForSeconds(.1f);


        resimObje.GetComponent<CanvasGroup>().DOFade(1, 0.5f);


        yield return new WaitForSeconds(.4f);

        baslaBtn.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        baslaBtn.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);


        yield return new WaitForSeconds(.4f);

        bolumBtn.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        bolumBtn.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(.4f);

        cikisBtn.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        cikisBtn.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);


    }

    


    public void OyunaBasla()
    {
        StartCoroutine(OyunuAcRoutine());
    }

    public void BolumlerSekmesi()
    {
        SceneManager.LoadScene(bolumSahne);
    }



    public void OyundanCikis()
    {
        Application.Quit();
    }


    IEnumerator OyunuAcRoutine()
    {
        yield return new WaitForSeconds(.1f);
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 1f);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sahneAdi);
    }


    
}
