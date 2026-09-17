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
    // public LayerMask groundLayer;

    // Détection du sol
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck1;
    [SerializeField] private Transform groundCheck2;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;

    // paramètre de dash 
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    // paramètre de son de marche
    private AudioManager audioManager;
    private float footstepTimer = 0f;
    public float footstepInterval = 0.5f; // Intervalle entre les sons de pas

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animation = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (isDashing) // Permet de désactiver les autres mouvements pendant le dash
        {
            footstepTimer = 0f; 
            return;
        }
        inputX = Input.GetAxisRaw("Horizontal");
       

            // bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);

            // GROUND CHECK 1 
            bool isGround1 = Physics2D.OverlapCircle(groundCheck1.position, groundCheckRadius, groundLayer);

        // GROUND CHECK 2
        bool isGround2 = Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, groundLayer);

        bool isGrounded = isGround1 || isGround2;

        // bruit de pas 
        if (inputX != 0 && isGrounded)
        {
            footstepTimer -= Time.deltaTime;

            if ( footstepTimer <=0f)
            {
                audioManager.PlayWalkSound();
                footstepTimer = footstepInterval;
            }
        }

        else
        {
              footstepTimer = 0f; 
        }

        // Saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        else
        {
            Animation.SetBool(Jump, false);
        }


        if (!isGrounded)
        {
            Animation.SetBool(Jump, true);
            Animation.SetBool(Run, false);
            Animation.SetBool(Idle, false);
        }

        // Attaque
        if ( Input.GetButton("Fire1"))
        {
            Animation.SetTrigger(attaque);
        }

        //input =  new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // input.Normalize();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) // permet au joueur d'effectuer un dash en appuyant sur une touche
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

        if (inputX > 0f) //Permet d'orienter le sprite face au mouvement et de lancer les animations de course et d'idle
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

    // Affichage du GroundCheck
    private void OnDrawGizmosSelected()
    {
        if (groundCheck1 != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck1.position, groundCheckRadius);
        }

        if (groundCheck2 != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck2.position, groundCheckRadius);
        }

    }

    


}


