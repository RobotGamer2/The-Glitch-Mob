using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerState currentState;

    public PlayerIdleState idleState;
    public PlayerJumpState jumpState;
    public PlayerMoveState moveState;
    
    [Header("Components")]
    public Rigidbody2D rb;
    public PlayerInput playerInput;
    public Animator anim;


    [Header("Movement Variables")]
    public float walkSpeed;
    public float runSpeed = 8;
    public float jumpForce;
    public float jumpCutMultiplier = .5f;
    public float normalGravity;
    public float fallGravity;
    public float jumpGravity;

    public int facingDirection = 1;

    //inputs
    public Vector2 moveInput;
    public bool runPressed;
    public bool jumpPressed;
    public bool jumpReleased;


    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isGrounded;


    private void Awake()
    {
        idleState = new PlayerIdleState(this);
        jumpState = new PlayerJumpState(this);
        moveState = new PlayerMoveState(this);
    }


    private void Start()
    {
        rb.gravityScale = normalGravity;

        ChangeState(idleState);
    }

    void Update()
    {
        currentState.Update();

        Flip();
        HandleAnimations();
    }

    void FixedUpdate()
    {
        currentState.FixedUpdate();
        
        CheckGrounded();

    }


    public void ChangeState(PlayerState newState)
    {
        if(currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }    



    public void ApplyVariableGravity()
    {
        if (rb.linearVelocity.y < -0.1f)     //faling
        {
            rb.gravityScale = fallGravity;
        }
        else if (rb.linearVelocity.y > 0.1f)     //rising
        {
            rb.gravityScale = jumpGravity;
        }
        else
        {
            rb.gravityScale = normalGravity;
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }


    void HandleAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);

        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    } 


    void Flip()
    {
        if (moveInput.x > 0.1f)
        {
            facingDirection = 1;
        }
        else if (moveInput.x < -0.1f)
        {
            facingDirection = -1;
        }

        transform.localScale = new Vector3(facingDirection, 1 , 1);
    }
    

    public void OnMove (InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }


    public void OnRun (InputValue value)
    {
        runPressed = value.isPressed;
    }



    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            jumpPressed = true;
            jumpReleased = false;
        }
        else //buton is released
        {
            jumpReleased = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }



}
