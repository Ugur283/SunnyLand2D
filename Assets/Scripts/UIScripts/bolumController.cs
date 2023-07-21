using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolumController : MonoBehaviour
{
    public string sahneAdi;
    public string sahneAdi2,menuSahne;

    public void bolum1()
    {
        SceneManager.LoadScene(sahneAdi);
    }

    public void bolum2()
    {
        SceneManager.LoadScene(sahneAdi2);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(menuSahne);
    }

}
