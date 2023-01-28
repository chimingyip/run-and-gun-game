using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float explosionDestroyTime;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Damage enemy = collision.GetComponent<Damage>();

        if (enemy)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(effect, explosionDestroyTime);
        Destroy(gameObject);
    }
}
