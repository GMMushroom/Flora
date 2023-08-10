using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ActionFlora : MonoBehaviour
{
    public GameObject Player1;
    private Animator Anim;
    private GameObject Player2;
    private Animator Anim2;
    private Rigidbody2D rb;
    private AudioSource MyPlayer;
    private AnimatorStateInfo Player1Layer0;
    public AudioClip Punch;
    public AudioClip Kick;
    public AudioClip Slash;
    public AudioClip Gunshot;
    public Transform ShootingPoint;
    public Transform AirShootingPoint;
    public GameObject FireballPrefab;
    //public GameObject BulletEffect;
    public LineRenderer lineRenderer;

    public float KnockBackForceUp = 1.0f;
    public float KnockBackForceHeavy = 2.0f;

    public bool EmitFX = false;
    private ParticleSystem Particles;
    private string ParticleType = "P2BodyHit";
    private GameObject ChosenParticles;

    private AudioSource CharacterVoice;
    public AudioClip LightGrunt;
    public AudioClip HeavyGrunt;
    private int RayFireball = 1;
    public AudioClip RaySlash1;
    public AudioClip RaySlash2;
    public AudioClip GilfordFire;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        MyPlayer = GetComponentInParent<AudioSource>();
        CharacterVoice = GetComponent<AudioSource>();
        Player2 = GameObject.Find("P2");
        Anim2 = Player2.GetComponent<Animator>();
        rb = Player2.GetComponentInParent<Rigidbody2D>();
        ChosenParticles = GameObject.Find(ParticleType);
        Particles = ChosenParticles.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.TimeOut == false)
        {
            //Listens to Animator
            Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

            //Animation for Attacks
            //Standing Attacks & Standing Block
            if (Player1Layer0.IsTag("Standing"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Anim.SetTrigger("A");
                }

                if (Input.GetButtonDown("Fire2"))
                {
                    Anim.SetTrigger("B");
                }
                if (Input.GetButtonDown("Fire3"))
                {
                    Anim.SetTrigger("C");
                }
                if (Input.GetButtonDown("Special"))
                {
                    Anim.SetTrigger("S");
                }
                if (Input.GetButtonDown("Block"))
                {
                    Anim.SetBool("Blocking", true);
                }
            }

            //Crouching Attacks & Crouching Block
            if (Player1Layer0.IsTag("Crouching"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Anim.SetTrigger("A");
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    Anim.SetTrigger("B");
                }
                if (Input.GetButtonDown("Fire3"))
                {
                    Anim.SetTrigger("C");
                }
                if (Input.GetButtonDown("Block"))
                {
                    Anim.SetBool("Blocking", true);
                }
            }

            //Jumping Attacks & Jumping Block
            if (Player1Layer0.IsTag("Jumping"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Anim.SetTrigger("A");
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    Anim.SetTrigger("B");
                }
                if (Input.GetButtonDown("Fire3"))
                {
                    Anim.SetTrigger("C");
                }
                if (Input.GetButtonDown("Special"))
                {
                    Anim.SetTrigger("S");
                }
                if (Input.GetButtonDown("Block"))
                {
                    Anim.SetBool("Blocking", true);
                }
            }

            //Going out of Blocking
            if (Player1Layer0.IsTag("Blocking"))
            {
                if (Input.GetButtonUp("Block"))
                {
                    Anim.SetBool("Blocking", false);
                }
            }
        }
    }

    public void Fireball()
    {
        Instantiate(FireballPrefab, ShootingPoint.position, ShootingPoint.rotation);

        RayFireball = Random.Range(1, 2);
        if (RayFireball == 1)
        {
            CharacterVoice.clip = RaySlash1;
            CharacterVoice.Play();
        }
        if (RayFireball == 2)
        {
            CharacterVoice.clip = RaySlash2;
            CharacterVoice.Play();
        }
    }

    public void AirFireball()
    {
        Instantiate(FireballPrefab, AirShootingPoint.position, AirShootingPoint.rotation);

        RayFireball = Random.Range(1, 3);
        if (RayFireball == 1)
        {
            CharacterVoice.clip = RaySlash1;
            CharacterVoice.Play();
        }
        if (RayFireball == 2)
        {
            CharacterVoice.clip = RaySlash2;
            CharacterVoice.Play();
        }
    }

    public void Bullet()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(ShootingPoint.position, ShootingPoint.right);
        CharacterVoice.clip = GilfordFire;
        CharacterVoice.Play();

        if (hitInfo)
        {
            if (hitInfo.transform.CompareTag("Player2"))
            {
                Anim2.SetTrigger("LightDamageJumping");
                if (EmitFX == true)
                {
                    Particles.Play();
                }
                Knockback();
                SaveScript.Player2Health -= 0.1f;
                if (SaveScript.Player2Timer < 1.0f)
                {
                    SaveScript.Player2Timer += 1.0f;
                }
            }

            //Instantiate(BulletEffect, transform.position, Quaternion.identity);

            lineRenderer.SetPosition(0, ShootingPoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, ShootingPoint.position);
            lineRenderer.SetPosition(1, ShootingPoint.position + ShootingPoint.right * 100);
        }

        lineRenderer.enabled = true;
        StartCoroutine(DisableLine());
    }

    public void PunchSound()
    {
        MyPlayer.clip = Punch;
        MyPlayer.Play();
    }

    public void KickSound()
    {
        MyPlayer.clip = Kick;
        MyPlayer.Play();
    }

    public void SlashSound()
    {
        MyPlayer.clip = Slash;
        MyPlayer.Play();
    }

    public void GunshotSound()
    {
        MyPlayer.clip = Gunshot;
        MyPlayer.Play();
    }
    private void Knockback()
    {
        Vector2 KnockBackDirection = new Vector2(transform.position.x - Player2.transform.position.x, 0);
        rb.velocity = new Vector2(KnockBackDirection.x, KnockBackForceUp) * -KnockBackForceHeavy;
    }

    IEnumerator DisableLine()
    {
        yield return new WaitForSeconds(0.02f);
        lineRenderer.enabled = false;
    }
}
