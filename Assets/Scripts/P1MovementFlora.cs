using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class P1MovementFlora : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 30f;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;
    public GameObject Player1;
    public GameObject Player2;
    private Vector2 P2Position;
    private bool FacingLeft = false;
    private bool FacingRight = true;
    public Collider2D CapsuleCollider1;
    public Collider2D CapsuleCollider2;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if K.O'd or if Won
        if (SaveScript.Player1Health <= 0)
        {
            Anim.SetTrigger("KO");
            Player1.GetComponent<P1ActionFlora>().enabled = false;
            StartCoroutine(KO());
        }
        if (SaveScript.Player2Health <= 0)
        {
            Anim.SetTrigger("Win");
            Player1.GetComponent<P1ActionFlora>().enabled = false;
            this.GetComponent<P1MovementFlora>().enabled = false;
        }

        //Listens to Animator
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

        //Get the opponent's position
        P2Position = Player2.transform.position;

        //Facing Left or Right of the Opponent
        if (P2Position.x > Player1.transform.position.x)
        {
            StartCoroutine(FaceRight());
        }
        if (P2Position.x < Player1.transform.position.x)
        {
            StartCoroutine(FaceLeft());
        }

        //Getting Horizontal Axis & Jumping
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Player1Layer0.IsTag("Standing"))
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                Anim.SetTrigger("Jump");
            }

        //Disable RigidBody2D and Collider2D when Blocking <-- Finnicky right now.
        if (Player1Layer0.IsTag("Blocking"))
        {
            rb.isKinematic = true;
            CapsuleCollider1.enabled = false;
            CapsuleCollider2.enabled = false;
        }
        else
        {
            CapsuleCollider1.enabled = true;
            CapsuleCollider2.enabled = true;
            rb.isKinematic = false;
        }
    }

    //Walking Forwards, Backward and Crouching Animations
    private void FixedUpdate()
    {
        if (Player1Layer0.IsTag("Standing"))
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (Input.GetAxis("Horizontal") > 0)
            {
                Anim.SetBool("Forward", true);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                Anim.SetBool("Backward", true);
            }
            if (Input.GetAxis("Horizontal") == 0)
            {
                Anim.SetBool("Forward", false);
                Anim.SetBool("Backward", false);
            }
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            Anim.SetBool("Crouch", true);
            CapsuleCollider1.enabled = false;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            Anim.SetBool("Crouch", false);
            CapsuleCollider1.enabled = true;
        }
    }

    //Ground Check
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Damage Animation plays when Collider2D Trigger enters
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Player1Layer0.IsTag("Standing"))
        {
            if (other.gameObject.CompareTag("MidLight"))
            {
                Anim.SetTrigger("LightDamage");
            }
            if (other.gameObject.CompareTag("MidHeavy"))
            {
                Anim.SetTrigger("HeavyDamage");
            }
        }
    }

    IEnumerator FaceRight()
    {
        if (FacingLeft == true)
        {
            FacingLeft = false;
            FacingRight = true;
            yield return new WaitForSeconds(0.15f);
            Player1.transform.Rotate(0, 180, 0);
            Anim.SetLayerWeight(1, 0);
        }
    }

    IEnumerator FaceLeft()
    {
        if (FacingRight == true)
        {
            FacingRight = false;
            FacingLeft = true;
            yield return new WaitForSeconds(0.15f);
            Player1.transform.Rotate(0, -180, 0);
            Anim.SetLayerWeight(1, 1);
        }
    }

    IEnumerator KO()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<P1MovementFlora>().enabled = false;
    }
}