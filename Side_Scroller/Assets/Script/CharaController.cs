using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharaController : MonoBehaviour
{
    [Header("Animation")]
    private Animator Animation;
    private string Idle = "Idle";
    private string Run = "Course";
    private string Jump = "Saut";
    private string dash = "Dash";
    private string attaque = "Attaque";

    [Header("Move variables")]
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] float acceleration = 20f;

    [Header("Gravity/Jump")]
    [SerializeField] float gravity = -10f;
    [SerializeField] float jumpForce = 1.5f;

    Rigidbody2D rb;
    //Vector2 input;
    float inputX;
    public LayerMask groundLayer;

    // paramètre de dash 
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        inputX = Input.GetAxisRaw("Horizontal");

        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        else
        {
            Animation.SetBool(Jump, false);
        }

        if(!isGrounded || !isGrounded && inputX > 0)
        {
            Animation.SetBool(Jump, true);
            Animation.SetBool(Run, false);
            Animation.SetBool(Idle, false);
        }
        //input =  new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // input.Normalize();

        if (Input.GetKeyDown(KeyCode.LeftShift)&& canDash) // permet au joueur d'effectuer un dash en appuyant sur une touche
        {
            StartCoroutine(Dash());
        }

        

    }

     void FixedUpdate()
     {

        if (isDashing && inputX>0 || isDashing && inputX<0)
        {
            Animation.SetBool(dash, true);
            return;
        }
        
        var v = rb.linearVelocity;
        v.x = inputX * moveSpeed;
        rb.linearVelocity = v;

        //rb.linearVelocity = input * moveSpeed;

        if (inputX > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Animation.SetBool(Run, true);
            Animation.SetBool(Idle, false);
        }
        else if (inputX < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Animation.SetBool(Run, true);
            Animation.SetBool(Idle, false);
        }
        else
        {
            Animation.SetBool(Idle, true);
            Animation.SetBool(Run, false);
        }


       
    }

    private IEnumerator Dash() // Permet au joueur d'effectuer un dash 
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        canDash = false;
        isDashing = true;
        Animation.SetBool(dash, true);
        Animation.SetBool(Run, false);
        Animation.SetBool(Jump, false);
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(inputX * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        Animation.SetBool(dash, false);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

       
       
    }


   
}


