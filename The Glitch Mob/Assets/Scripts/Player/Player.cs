using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerInput playerInput;

    public float speed;
    public int facingDirection = 1;

    public Vector2 moveInput;

    void FixedUpdate()
    {
        float targetSpeed = moveInput.x * speed;
        rb.linearVelocity = new Vector2(targetSpeed, rb.linearVelocity.y);
    }

    private void Update()
    {
        Flip();
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

}
