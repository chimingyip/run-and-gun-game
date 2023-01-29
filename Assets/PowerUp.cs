using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject player;

    private Shooting playerShooting;
    private void Start()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Physics2D.IgnoreCollision(enemyBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        playerShooting = player.GetComponent<Shooting>();
        playerShooting.currentFireMode = Shooting.FireMode.Double;
        playerShooting.poweredUp = true;
        playerShooting.powerUpTimer = 0.3f;
        Destroy(gameObject);
    }
}
