using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesController : MonoBehaviour
{
    public static SesController instance;

    public AudioSource[] sesEfektleri;


    private void Awake()
    {
        instance = this;
    }


    public void SesEfektiCikar(int hangiSes)
    {
        sesEfektleri[hangiSes].Stop();
        sesEfektleri[hangiSes].pitch = Random.Range(0.8f, 1.3f);

        sesEfektleri[hangiSes].Play();
    }
}
