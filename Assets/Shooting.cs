using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform rightFirePoint, leftFirePoint, centralFirePoint; 

	public enum FireMode
	{
		Single,
		Double,
		Fireball,
		Laser
	}
	public FireMode currentFireMode = FireMode.Single;
	public GameObject bulletPrefab;

	public float bulletForce = 20f;
	public bool poweredUp = false;
	public float powerUpTimer;
	
	private bool isFiring = false;

	[SerializeField]
	protected CooldownTimer fireDelayTimer;

    private void Awake()
    {
		fireDelayTimer = gameObject.AddComponent<CooldownTimer>();
    }

    void FixedUpdate()
    {
		if (isFiring)
		{
			if (!fireDelayTimer.CooldownComplete) return;
			fireDelayTimer.StartCooldown();

			if (poweredUp)
            {
				powerUpTimer -= Time.deltaTime;

				if (powerUpTimer <= 0)
				{
					currentFireMode = FireMode.Single;
					powerUpTimer = 0;
					poweredUp = false;
				}
			}

			

			switch (currentFireMode)
			{
				case FireMode.Single:
					GameObject bullet = Instantiate(bulletPrefab, centralFirePoint.position, centralFirePoint.rotation);
					Rigidbody2D centralRb = bullet.GetComponent<Rigidbody2D>();
					centralRb.AddForce(centralFirePoint.up * bulletForce, ForceMode2D.Impulse);
					break; 
				case FireMode.Double:
					GameObject rightBullet = Instantiate(bulletPrefab, rightFirePoint.position, rightFirePoint.rotation);
					Rigidbody2D rightRb = rightBullet.GetComponent<Rigidbody2D>();
					rightRb.AddForce(rightFirePoint.up * bulletForce, ForceMode2D.Impulse);

					GameObject leftBullet = Instantiate(bulletPrefab, leftFirePoint.position, leftFirePoint.rotation);
					Rigidbody2D leftRb = leftBullet.GetComponent<Rigidbody2D>();
					leftRb.AddForce(leftFirePoint.up * bulletForce, ForceMode2D.Impulse);
					break;
				case FireMode.Fireball:
					break;
				case FireMode.Laser:
					break;
			}
		}
	}

    void OnFire()
	{
		isFiring = !isFiring;
	}
}