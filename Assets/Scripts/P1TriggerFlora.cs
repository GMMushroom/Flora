using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1TriggerFlora : MonoBehaviour
{
    public Collider2D Col;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;
    public float DamageAmt = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Listens to Animator
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

        //Enabling Colliders
        if (P1ActionFlora.Hits == false)
        {
            Col.enabled = true;
            Anim.SetTrigger("Connects");
        }
        else
        {
            Col.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            P1ActionFlora.Hits = true;
            SaveScript.Player2Health -= DamageAmt;
        }
    }
}
