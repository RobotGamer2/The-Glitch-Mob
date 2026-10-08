using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [Header("Movement & AI")]
    public float moveSpeed = 4f;
    public float chaseDistance = 7f;
    public float stopDistance = 0.5f; // Prevents the enemy from glitching inside the player

    private Transform playerTarget;

    void Start()
    {
        // Dynamically find the player using their tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTarget = player.transform;
        }
    }

    void Update()
    {
        if (playerTarget == null) return;

        // Calculate distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);

        // Only chase if player is close enough, but not too close
        if (distanceToPlayer < chaseDistance && distanceToPlayer > stopDistance)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                playerTarget.position,
                moveSpeed * Time.deltaTime
            );

            FlipTowardsPlayer();
        }
    }

    void FlipTowardsPlayer()
    {
        // Flip sprite based on whether player is to the left or right
        if (playerTarget.position.x > transform.position.x && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (playerTarget.position.x < transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizes the detection range in the Editor view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}