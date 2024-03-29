using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2TriggerFlora : MonoBehaviour
{
    public Collider2D Col;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;
    public float DamageAmt = 0.1f;
    public bool EmitFX = false;
    private ParticleSystem Particles;
    public string ParticleType = "P1HeadHit";
    private GameObject ChosenParticles;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInParent<Animator>();
        ChosenParticles = GameObject.Find(ParticleType);
        Particles = ChosenParticles.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Calculates Damage
        if (other.gameObject.CompareTag("Player1"))
        {
            if (EmitFX == true)
            {
                Particles.Play();
            }
            SaveScript.Player1Health -= DamageAmt;
            Anim.SetBool("Hits", true);
            if (SaveScript.Player1Timer < 1.0f)
            {
                SaveScript.Player1Timer += 1.0f;
            }
            StartCoroutine(CancelWindow());
        }
    }

    IEnumerator CancelWindow()
    {
        yield return new WaitForSeconds(0.5f);
        Anim.SetBool("Hits", false);
    }
}
