using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2ActionFlora : MonoBehaviour
{
    public GameObject Player2;
    private Animator Anim;
    private AudioSource MyPlayer;
    private AnimatorStateInfo Player1Layer0;
    public AudioClip Punch;
    public AudioClip Kick;
    public AudioClip Slash;
    public Transform ShootingPoint;
    public GameObject FireballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        MyPlayer = GetComponent<AudioSource>();
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
                if (Input.GetButtonDown("Fire1P2"))
                {
                    Anim.SetTrigger("A");
                }

                if (Input.GetButtonDown("Fire2P2"))
                {
                    Anim.SetTrigger("B");
                }
                if (Input.GetButtonDown("Fire3P2"))
                {
                    Anim.SetTrigger("C");
                }
                if (Input.GetButtonDown("SpecialP2"))
                {
                    Anim.SetTrigger("S");
                }
                if (Input.GetButtonDown("BlockP2"))
                {
                    Anim.SetBool("Blocking", true);
                }
            }

            //Crouching Attacks & Crouching Block
            if (Player1Layer0.IsTag("Crouching"))
            {
                if (Input.GetButtonDown("Fire1P2"))
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
                if (Input.GetButtonDown("BlockP2"))
                {
                    Anim.SetBool("Blocking", true);
                }
            }

            //Jumping Attacks & Jumping Block
            if (Player1Layer0.IsTag("Jumping"))
            {
                if (Input.GetButtonDown("Fire1P2"))
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
                if (Input.GetButtonUp("BlockP2"))
                {
                    Anim.SetBool("Blocking", false);
                }
            }
        }
    }

    public void Fireball()
    {
        Instantiate(FireballPrefab, ShootingPoint.position, ShootingPoint.rotation);
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
}
