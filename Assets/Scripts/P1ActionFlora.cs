using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ActionFlora : MonoBehaviour
{
    public GameObject Player1;
    private Animator Anim;
    private AudioSource RayAudio;
    private AnimatorStateInfo Player1Layer0;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        RayAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
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
            if (Input.GetButtonDown("Block"))
            {
                Anim.SetBool("Blocking", true);
            }
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
            if (Input.GetButtonUp("Block"))
            {
                Anim.SetBool("Blocking", false);
            }
        }
    }
}
