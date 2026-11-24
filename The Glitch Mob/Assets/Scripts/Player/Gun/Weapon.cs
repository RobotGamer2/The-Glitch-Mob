using System.Reflection.Metadata;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    private Vector2 aimDirection = Vector2.right;
    public float shootCooldown = .5f;
    private float shootTimer;

    
    void Update()
    {
        shootTimer -= Time.deltaTime;

        HandleAiming();

        if (Input.GetButtonDown("Fire1") && shootTimer <= 0)
        {
            Shoot();
        }
    }
      
    private void HandleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical !=0)
        {
            aimDirection = new Vector2(horizontal, vertical).normalized;
        }
    }


    public void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.direction = aimDirection;
        shootTimer = shootCooldown;
    }
}
