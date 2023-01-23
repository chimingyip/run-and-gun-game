using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float explosionDestroyTime;

    //void onCollisionEnter2D(Collision2D collision)
    //{
    //    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //    Destroy(effect, 5f);
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effect, explosionDestroyTime);
        Destroy(gameObject);
    }
}
