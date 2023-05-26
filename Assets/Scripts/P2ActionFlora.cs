using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2ActionFlora : MonoBehaviour
{
    public GameObject Player2;
    private Animator Anim;
    private AudioSource RayAudio;
    private AnimatorStateInfo Player1Layer0;
    public static bool Hits = false;

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
        if (Player1Layer0.IsTag("Standing"))
        {
            if (Input.GetButtonDown("Fire1P2"))
            {
                Anim.SetTrigger("A");
                Hits = false;
            }

            if (Input.GetButtonDown("Fire2P2"))
            {
                Anim.SetTrigger("B");
                Hits = false;
            }
            if (Input.GetButtonDown("Fire3P2"))
            {
                Anim.SetTrigger("C");
                Hits = false;
            }
            if (Input.GetButtonDown("BlockP2"))
            {
                Anim.SetBool("Blocking", true);
            }
        }

        if (Player1Layer0.IsTag("Crouching"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Anim.SetTrigger("A");
            }
            if (Input.GetButtonDown("BlockP2"))
            {
                Anim.SetBool("Blocking", true);
            }
        }

        if (Player1Layer0.IsTag("Blocking"))
        {
            if (Input.GetButtonUp("BlockP2"))
            {
                Anim.SetBool("Blocking", false);
            }
        }
    }
}
