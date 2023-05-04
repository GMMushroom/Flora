using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ActionFlora : MonoBehaviour
{
    public GameObject Player1;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;
    public static bool Hits = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Listens to Animator
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

        //Animation for Attacks
        if (Player1Layer0.IsTag("Standing"))
        if (Input.GetButtonDown("Fire1"))
        {
            Anim.SetTrigger("A");
            Hits = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Anim.SetTrigger("B");
            Hits = false;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Anim.SetTrigger("C");
            Hits = false;
        }
    }
}