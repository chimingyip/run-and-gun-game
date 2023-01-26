using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint1, firePoint2, firePoint3, firePoint4;
    public float bulletForce = 20f;
    private float cooldownTimer;
    [SerializeField] private float cooldown = 5;

    public GameObject bulletPrefab;
    public enum FireMode
    {
        DefaultRotate
    }
    public FireMode currentFireMode = FireMode.DefaultRotate;

    public float rotationSpeed; 

    void FixedUpdate()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        switch (currentFireMode)
        {
            case FireMode.DefaultRotate:
                GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
                GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
                GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
                GameObject bullet4 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);

                Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
                Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
                Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();

                rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
                rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
                rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
                rb4.AddForce(firePoint4.up * bulletForce, ForceMode2D.Impulse);
                break;
        }
    }
}
