using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;

    [Header("Detection Settings")]
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private float rayDistance = 1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isMovingRight = true;

    private void Awake()
    {
        // Get the Rigidbody2D component attached to the enemy
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move the enemy horizontally while retaining its current falling/gravity speed
        float horizontalVelocity = isMovingRight ? moveSpeed : -moveSpeed;
        rb.linearVelocity = new Vector2(horizontalVelocity, rb.linearVelocity.y);

        // Check if the enemy needs to turn around
        if (ShouldTurnAround())
        {
            Flip();
        }
    }

    private bool ShouldTurnAround()
    {
        if (detectionPoint == null) return false;

        // 1. Wall Detection: Cast a ray horizontally in the direction of movement
        Vector2 wallDirection = isMovingRight ? Vector2.right : Vector2.left;
        RaycastHit2D wallCheck = Physics2D.Raycast(detectionPoint.position, wallDirection, rayDistance, groundLayer);

        // 2. Ledge Detection: Cast a ray straight down from the front edge
        RaycastHit2D ledgeCheck = Physics2D.Raycast(detectionPoint.position, Vector2.down, rayDistance, groundLayer);

        // Turn around if we hit a wall OR if there is no ground ahead (ledge)
        return wallCheck.collider != null || ledgeCheck.collider == null;
    }

    private void Flip()
    {
        // Switch the direction state
        isMovingRight = !isMovingRight;

        // Flip the sprite by multiplying the X scale by -1
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    // Visualizes the detection rays inside the Unity Editor Scene view
    private void OnDrawGizmosSelected()
    {
        if (detectionPoint == null) return;

        Gizmos.color = Color.red;
        // Draw the downward ledge check ray
        Gizmos.DrawLine(detectionPoint.position, detectionPoint.position + Vector3.down * rayDistance);

        // Draw the forward wall check ray
        Vector3 wallDirection = isMovingRight ? Vector3.right : Vector3.left;
        Gizmos.DrawLine(detectionPoint.position, detectionPoint.position + wallDirection * rayDistance);
    }
}