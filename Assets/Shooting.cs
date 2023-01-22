using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform rightFirePoint;
	public Transform leftFirePoint;
	public GameObject bulletPrefab; 
	
	public float bulletForce = 20f;
	
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
			GameObject rightBullet = Instantiate(bulletPrefab, rightFirePoint.position, rightFirePoint.rotation);
			Rigidbody2D rightRb = rightBullet.GetComponent<Rigidbody2D>();
			rightRb.AddForce(rightFirePoint.up * bulletForce, ForceMode2D.Impulse);

			GameObject leftBullet = Instantiate(bulletPrefab, leftFirePoint.position, leftFirePoint.rotation);
			Rigidbody2D leftRb = leftBullet.GetComponent<Rigidbody2D>();
			leftRb.AddForce(leftFirePoint.up * bulletForce, ForceMode2D.Impulse);
		}
	}

    void OnFire()
	{
		isFiring = !isFiring;
	}
}