using System.Collections;
using UnityEngine;

public class P2MovementFlora : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 15f;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;
    public GameObject Player1;
    public GameObject Player2;
    private Vector2 P2Position;
    private bool FacingLeft = false;
    private bool FacingRight = true;
    private AudioSource MyPlayer;
    public AudioClip LightHit;
    public AudioClip HeavyHit;
    public Collider2D CapsuleCollider1;
    public Collider2D CapsuleCollider2;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public float KnockBackForceLight = 1.0f;
    public float KnockBackForceUp = 1.0f;
    public float KnockBackForceHeavy = 2.0f;

    private AudioSource CharacterVoice;
    public AudioClip EntranceQuote;
    public AudioClip LightReact;
    public AudioClip HeavyReact;
    public AudioClip JumpGrunt;
    public AudioClip KOQuote1;
    public AudioClip KOQuote2;
    public AudioClip KOQuote3;
    public AudioClip VictoryQuote1;
    public AudioClip VictoryQuote2;
    public AudioClip VictoryQuote3;
    private int HitReaction = 0;
    private int LoseReaction = 1;
    private int WinReaction = 1;

    // Start is called before the first frame update
    void Start()
    {
        Player1.transform.Rotate(0, -180, 0);
        FacingLeft = false;
        FacingRight = true;
        Player2 = GameObject.Find("P1");
        Anim = GetComponentInChildren<Animator>();
        MyPlayer = GetComponentInChildren<AudioSource>();
        CharacterVoice = GetComponentInChildren<AudioSource>();
        if (SaveScript.RoundCounter == 1)
        {
            StartCoroutine(EntranceDialogue());
        }
        StartCoroutine(TurnBackAround());
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.TimeOut == true)
        {
            Anim.SetBool("Forward", false);
            Anim.SetBool("Backward", false);
        }
        if (SaveScript.TimeOut == false)
        {
            //Check if K.O'd or if Won
            if (SaveScript.Player2Health <= 0)
            {
                Anim.SetTrigger("KO");
                DefeatQuote();
                Player1.GetComponent<P2ActionFlora>().enabled = false;
                StartCoroutine(KO());
            }
            if (SaveScript.Player1Health <= 0)
            {
                StartCoroutine(VictoryAnimation());
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
            horizontal = Input.GetAxisRaw("HorizontalP2");

            if (Player1Layer0.IsTag("Standing"))
            {
                if (Input.GetButtonDown("JumpP2") && IsGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                    Anim.SetTrigger("Jump");
                    Anim.SetBool("Grounded", false);
                }
            }
            if (Player1Layer0.IsTag("Jumping"))
            {
                if (IsGrounded())
                {
                    Anim.SetBool("Grounded", true);
                }
            }

            //Disable RigidBody2D and Collider2D when Blocking
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
    }

    //Walking Forwards, Backward and Crouching Animations
    private void FixedUpdate()
    {
        if (SaveScript.TimeOut == false)
        {
            if (Player1Layer0.IsTag("Standing"))
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                if (Input.GetAxis("HorizontalP2") > 0)
                {
                    Anim.SetBool("Forward", true);
                }

                if (Input.GetAxis("HorizontalP2") < 0)
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
                CapsuleCollider1.enabled = false;
            }
            if (Input.GetAxis("VerticalP2") == 0)
            {
                Anim.SetBool("Crouch", false);
                CapsuleCollider1.enabled = true;
            }
        }
    }

    //Ground Check
    private bool IsGrounded()
    {
        Anim.SetBool("Grounded", true);
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Damage Animation plays when Collider2D Trigger enters & Knockback
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((Player1Layer0.IsTag("Standing")) || (Player1Layer0.IsTag("StandingAttack")))
        {
            if (other.gameObject.CompareTag("MidLight"))
            {
                Anim.SetTrigger("LightDamageStanding");
                Knockback();
                LightHitSound();
                LightHitReaction();
            }
            if (other.gameObject.CompareTag("MidHeavy"))
            {
                Anim.SetTrigger("HeavyDamageStanding");
                Knockback();
                HeavyHitSound();
                HeavyHitReaction();
            }
        }

        if ((Player1Layer0.IsTag("Jumping")) || (Player1Layer0.IsTag("JumpingAttack")))
        {
            if (other.gameObject.CompareTag("MidLight"))
            {
                Anim.SetTrigger("LightDamageJumping");
                Knockback();
                LightHitSound();
                LightHitReaction();
            }
            if (other.gameObject.CompareTag("MidHeavy"))
            {
                Anim.SetTrigger("HeavyDamageJumping");
                Knockback();
                HeavyHitSound();
                HeavyHitReaction();
            }
        }

        if ((Player1Layer0.IsTag("Crouching")) || (Player1Layer0.IsTag("CrouchingAttack")))
        {
            if (other.gameObject.CompareTag("MidLight"))
            {
                Anim.SetTrigger("LightDamageCrouching");
                Knockback();
                LightHitSound();
                LightHitReaction();
            }
            if (other.gameObject.CompareTag("MidHeavy"))
            {
                Anim.SetTrigger("HeavyDamageCrouching");
                Knockback();
                HeavyHitSound();
                HeavyHitReaction();
            }
        }
    }

    //Knockback Function
    private void Knockback()
    {
        Vector2 KnockBackDirection = new Vector2(transform.position.x - Player2.transform.position.x, 0);
        rb.velocity = new Vector2(KnockBackDirection.x, KnockBackForceUp) * KnockBackForceHeavy;
    }

    //Audio
    public void LightHitSound()
    {
        MyPlayer.clip = LightHit;
        MyPlayer.Play();
    }

    public void HeavyHitSound()
    {
        MyPlayer.clip = HeavyHit;
        MyPlayer.Play();
    }

    public void JumpingGrunt()
    {
        CharacterVoice.clip = JumpGrunt;
        CharacterVoice.Play();
    }

    public void LightHitReaction()
    {
        HitReaction = Random.Range(0, 1);

        if (HitReaction == 1)
        {
            CharacterVoice.clip = LightReact;
            CharacterVoice.Play();
        }
    }

    public void HeavyHitReaction()
    {
        HitReaction = Random.Range(0, 1);

        if (HitReaction == 1)
        {
            CharacterVoice.clip = HeavyReact;
            CharacterVoice.Play();
        }
    }

    public void DefeatQuote()
    {
        LoseReaction = Random.Range(1, 4);

        if (LoseReaction == 1)
        {
            CharacterVoice.clip = KOQuote1;
            CharacterVoice.Play();
        }
        if (LoseReaction == 2)
        {
            CharacterVoice.clip = KOQuote2;
            CharacterVoice.Play();
        }
        if (LoseReaction == 3)
        {
            CharacterVoice.clip = KOQuote3;
            CharacterVoice.Play();
        }
    }

    public void VictoryQuote()
    {
        WinReaction = Random.Range(1, 4);

        if (WinReaction == 1)
        {
            CharacterVoice.clip = VictoryQuote1;
            CharacterVoice.Play();
        }
        if (WinReaction == 2)
        {
            CharacterVoice.clip = VictoryQuote2;
            CharacterVoice.Play();
        }
        if (WinReaction == 3)
        {
            CharacterVoice.clip = VictoryQuote3;
            CharacterVoice.Play();
        }
    }

    //Change Character Direction
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

    //Disable Script when KO'd
    IEnumerator KO()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<P2MovementFlora>().enabled = false;
    }

    //Turning Around at round start
    IEnumerator TurnBackAround()
    {
        if (SaveScript.RoundCounter == 1)
        {
            yield return new WaitForSeconds(6.6f);
            Player1.transform.Rotate(0, 180, 0);
        }
        else if (SaveScript.RoundCounter > 1)
        {
            yield return new WaitForSeconds(1.0f);
            Player1.transform.Rotate(0, 180, 0);
        }
    }

    //Offsetting Entrance Dialogue
    IEnumerator EntranceDialogue()
    {
        yield return new WaitForSeconds(2.0f);
        Anim.SetTrigger("Entrance");
        CharacterVoice.clip = EntranceQuote;
        CharacterVoice.Play();
    }

    //Victory Animation
    IEnumerator VictoryAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Anim.SetTrigger("Win");
        VictoryQuote();
        Player1.GetComponent<P2ActionFlora>().enabled = false;
        this.GetComponent<P2MovementFlora>().enabled = false;
    }
}