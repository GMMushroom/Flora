using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2ActionFloraAI : MonoBehaviour
{
    public GameObject Player2;
    private Animator Anim;
    private AudioSource MyPlayer;
    private AnimatorStateInfo Player1Layer0;
    public AudioClip Punch;
    public AudioClip Kick;
    public AudioClip Slash;

    private int AttackNumber = 1;
    private bool Attacking = true;
    public float AttackRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        AttackRate = AttackRate * SaveScript.Difficulty;
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
                if (Attacking == true)
                {
                    Attacking = false;
                    if (AttackNumber == 1)
                    {
                        Anim.SetTrigger("A");
                        StartCoroutine(SetAttackRate());
                    }

                    if (AttackNumber == 2)
                    {
                        Anim.SetTrigger("B");
                        StartCoroutine(SetAttackRate());
                    }
                    if (AttackNumber == 3)
                    {
                        Anim.SetTrigger("C");
                        StartCoroutine(SetAttackRate());
                    }
                }
            }

            //Crouching Attacks & Crouching Block
            if (Player1Layer0.IsTag("Crouching"))
            {
                Anim.SetTrigger("A");
                Anim.SetBool("Crouch", false);
            }

            //Jumping Attacks & Jumping Block
            if (Player1Layer0.IsTag("Jumping"))
            {
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

    public void RandomAttack()
    {
        AttackNumber = Random.Range(1, 4);
        StartCoroutine(SetAttackRate());
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

    IEnumerator SetAttackRate()
    {
        yield return new WaitForSeconds(AttackRate);
        Attacking = true;
    }
}
