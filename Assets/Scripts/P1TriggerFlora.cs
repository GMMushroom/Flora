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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            SaveScript.Player2Health -= DamageAmt;
            Anim.SetBool("Hits", true);
            if (SaveScript.Player2Timer < 1.0f)
            {
                SaveScript.Player2Timer += 1.0f;
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
