using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed;
    public Transform ori; 
    float horiInput;
    float vertInput;
    Vector3 moveDir;
    Rigidbody rb;

    public float groundDrag;
    //ground check
    public float playerHeight;
    public LayerMask whatIsGround;
    bool isGrounded; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        playerInput();
        if (isGrounded)
        {
            rb.linearDamping=groundDrag;
            Debug.Log("Draggin");
        }
        else
        {
            rb.linearDamping = 0;

        }

    }
    void FixedUpdate()
    {
        movePlayer();

    }

    void playerInput()
    {
        horiInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
    }
    void movePlayer()
    {
        moveDir= ori.forward*vertInput + ori.right*horiInput;
        transform.position += moveDir * speed;
    }
    
}
