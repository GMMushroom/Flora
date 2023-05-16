using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class P2MovementFlora : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 30f;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;
    public GameObject Player1;
    public GameObject Player2;
    private Vector2 P2Position;
    private bool FacingLeftP2 = true;
    private bool FacingRightP2 = false;

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
        horizontal = Input.GetAxisRaw("HorizontalP2");

        if (Player1Layer0.IsTag("Standing"))
            if (Input.GetButtonDown("JumpP2") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Anim.SetTrigger("Jump");
        }
    }

    //Walking Forwards & Backward
    private void FixedUpdate()
    {
        if (Player1Layer0.IsTag("Standing"))
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (Input.GetAxis("HorizontalP2") < 0)
            {
                Anim.SetBool("Forward", true);
            }

            if (Input.GetAxis("HorizontalP2") > 0)
            {
                Anim.SetBool("Backward", true);
            }
            if (Input.GetAxis("HorizontalP2") == 0)
            {
                Anim.SetBool("Forward", false);
                Anim.SetBool("Backward", false);
            }
        }

        if (Input.GetAxis("VerticalP2") < 0)
        {
            Anim.SetBool("Crouch", true);
        }
        if (Input.GetAxis("VerticalP2") == 0)
        {
            Anim.SetBool("Crouch", false);
        }
    }

    //Ground Check
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Damage Animation
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MidLight"))
        {
            Anim.SetTrigger("LightDamage");
        }
    }

    IEnumerator FaceRight()
    {
        if (FacingLeftP2 == true)
        {
            FacingLeftP2 = false;
            FacingRightP2 = true;
            yield return new WaitForSeconds(0.15f);
            Player1.transform.Rotate(0, -180, 0);
        }
    }

    IEnumerator FaceLeft()
    {
        if (FacingRightP2 == true)
        {
            FacingRightP2 = false;
            FacingLeftP2 = true;
            yield return new WaitForSeconds(0.15f);
            Player1.transform.Rotate(0, 180, 0);
        }
    }
}