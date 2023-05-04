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
            StartCoroutine(FaceLeft());
        }
        if (P2Position.x < Player1.transform.position.x)
        {
            StartCoroutine(FaceRight());
        }

        //Getting Horizontal Axis & Jumping
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Anim.SetTrigger("Jump");
        }
    }

    //Walking Forwards, Backward and Crouching
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (Player1Layer0.IsTag("Standing"))
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

        if (Input.GetAxis("Vertical") < 0)
        {
            Anim.SetBool("Crouch", true);
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            Anim.SetBool("Crouch", false);
        }
    }

    //Ground Check and Crouching
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    IEnumerator FaceLeft()
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

    IEnumerator FaceRight()
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
}