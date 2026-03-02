using UnityEngine;

public class CharaController : MonoBehaviour
{
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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        //input =  new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // input.Normalize();
    }

     void FixedUpdate()
     {
        var v = rb.linearVelocity;
        v.x = inputX * moveSpeed;
        rb.linearVelocity = v;

        //rb.linearVelocity = input * moveSpeed;
    }



}


