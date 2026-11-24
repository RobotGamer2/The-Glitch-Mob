using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public Rigidbody2D rb;
    public float lifeSpan = 2;

    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        RotateBullet();
        Destroy(gameObject, lifeSpan);
    }

    private void RotateBullet()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }  

}
