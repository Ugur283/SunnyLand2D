using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneController : MonoBehaviour
{
    public string sonrakiBolumAdi; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.instance.SahneyiBitir();
            // Bir sonraki bölüme geçiþ
            LevelManager.instance.SonrakiBolumeGec(sonrakiBolumAdi);
        }
    }

}

