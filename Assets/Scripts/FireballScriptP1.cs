using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScriptP1 : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody2D rb;
    public Collider2D Col;
    private AnimatorStateInfo Player1Layer0;
    public float DamageAmt = 0.1f;
    public bool EmitFX = false;
    public ParticleSystem Particles;
    public string ParticleType = "P2HeadHit";
    private GameObject ChosenParticles;

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
        if (other.gameObject.CompareTag("Player2"))
        {
            if (EmitFX == true)
            {
                Particles.Play();
            }
            SaveScript.Player2Health -= DamageAmt;
            if (SaveScript.Player2Timer < 1.0f)
            {
                SaveScript.Player2Timer += 1.0f;
            }
        }
    }

}
