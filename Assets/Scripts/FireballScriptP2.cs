using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScriptP2 : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody2D rb;
    public Collider2D Col;
    private AnimatorStateInfo Player1Layer0;
    public float DamageAmt = 0.1f;
    public bool EmitFX = false;
    public ParticleSystem Particles;
    public string ParticleType = "P1HeadHit";
    private GameObject ChosenParticles;
    public GameObject ImpactEffect;

    // Start is called before the first frame update
    void Start()
    {
        ChosenParticles = GameObject.Find(ParticleType);
        Particles = ChosenParticles.gameObject.GetComponent<ParticleSystem>();
        rb.velocity = transform.right * speed;
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
            if (SaveScript.Player1Timer < 1.0f)
            {
                SaveScript.Player1Timer += 1.0f;
            }

            Instantiate(ImpactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

}
