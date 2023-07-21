using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    float hareketHizi;

    [SerializeField]
    float ziplamaGucu;

    bool yerdemi;
    public Transform zeminKontrolNoktasi;
    public LayerMask zeminLayer;
    bool ikiKezZiplayabilirmi;

    public float geriTepmeSuresi, geritepmeGucu;
    float geriTepmeSayacý;
    bool yonSagmi;

    public float ziplaZiplaGucu;

    public bool hareketEtsinmi;


    Rigidbody2D rb;

    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        hareketEtsinmi = true;
    }


    private void Update()
    {
        if (hareketEtsinmi)
        {
            if (geriTepmeSayacý <= 0)
            {
                HareketEttirFNK();
                ZiplaFNK();
                YonuDegistir();
            }
            else
            {
                geriTepmeSayacý -= Time.deltaTime;
                if (yonSagmi)
                {
                    rb.velocity = new Vector2(-geritepmeGucu, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(geritepmeGucu, rb.velocity.y);
                }

            }
            anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
            anim.SetBool("yerdemi", yerdemi);
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        }


       
    }

    void HareketEttirFNK()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * hareketHizi;

        rb.velocity = new Vector2(hiz, rb.velocity.y);
    }


    void ZiplaFNK()
    {
        yerdemi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, .2f, zeminLayer);

        if (yerdemi)
        {
            ikiKezZiplayabilirmi = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (yerdemi)
            {
                rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
                SesController.instance.SesEfektiCikar(3);
            }
            else
            {
                if (ikiKezZiplayabilirmi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
                    ikiKezZiplayabilirmi = false;
                    SesController.instance.SesEfektiCikar(3);
                }
            }

        }


    }
    void YonuDegistir()
    {
        Vector2 geciciScale = transform.localScale;

        if (rb.velocity.x > 0)
        {
            yonSagmi = true;
            geciciScale.x = 1f;
        } else if (rb.velocity.x < 0)
        {
            yonSagmi = false;
            geciciScale.x = -1f;
        }

        transform.localScale = geciciScale;
    }

    public void GeriTepmeFNC()
    {
        geriTepmeSayacý = geriTepmeSuresi;
        rb.velocity = new Vector2(0, rb.velocity.y);

        anim.SetTrigger("hasar");
    }

    public void ZiplaZiplaFNC()
    {
        rb.velocity = new Vector2(rb.velocity.x, ziplaZiplaGucu);
        SesController.instance.SesEfektiCikar(3);
    }
    



}

