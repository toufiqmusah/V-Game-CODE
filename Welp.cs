using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Welp : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public Joystick joystick;

    private float dirx = 0f;
    public bool facingRight = true;
    [SerializeField] private float jumpforce = 24f;
    [SerializeField] private float movespeed = 3f;

    [SerializeField] private Transform feet;
    public LayerMask Ground;
    private bool IsGrounded;

    private string currentState;

    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private AudioSource walksound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(feet.position, 0.5f, Ground);
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        //dirx = CrossPlatformInputManager.GetAxisRaw("Horizontal");

       //dirx = joystick.Horizontal*movespeed;

       /*if(joystick.Horizontal > .5f)
        {
            dirx = 0.048f*movespeed;
        }

        else if(joystick.Horizontal < -.5f)
        {
            dirx =-movespeed*0.048f;
        }
        */
        rb.velocity = new Vector2(dirx * movespeed, rb.velocity.y);
        
        //dirx = Input.GetAxisRaw("Horizontal");


       if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpsound.Play();
        }

      
       if (CrossPlatformInputManager.GetButtonDown("Jump") && IsGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpsound.Play();
        }
        
        if (dirx > 0f)
        {
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            sprite.flipX = true;
        }



        if (IsGrounded)
        {
            if (dirx != 0f )
            {
                ChangeAnimationState("V Walk");
            }

            else if (dirx == 0f)
            {
                ChangeAnimationState("V Idle");
            }
        }
        if (rb.velocity.y > .1f && !IsGrounded)
        {
            ChangeAnimationState("V Jump");
        }

       else if(rb.velocity.y < -.1f && !IsGrounded)
        {
            ChangeAnimationState("V Fall");
        }

    }
    
 /*   void actualJump()
    {
     if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            Jump();
            jumpsound.Play();
        }
    }*/



    void ChangeAnimationState(string newState)
    {
        //Stop same animation frrom interrupting itself
        if (currentState == newState) return;

        //Play animation
        anim.Play(newState);

        //Reassign state
        currentState = newState;
    }

    public void Jump()
    {
       // GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpforce);
         if (IsGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpforce);
            //Jump();
            jumpsound.Play();
        }
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            Jump();
            jumpsound.Play();
        }
    }

    //public bool IsGrounded()
  //  {
   //     Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, Ground);

     //   if (groundCheck.gameObject != null)
        //{
      //      return true;
    //    }

       // return false;
   // }
}

