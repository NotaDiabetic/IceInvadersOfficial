using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;     // Geschwindigkeit des Projektills
    public float lifetime = 3f;      // Lebensdauer

    private Vector3 direction;

    public bool isSimpleProjectile;
    public bool isMediumProjectile;
    public bool isHardProjectile;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (isSimpleProjectile)
            {
                player.TakeSimpleDamage(); // Schaden zufügen
            }
            else if (isMediumProjectile)
            {
                player.TakeMediumDamage(); // Schaden zufügen
            }
            else if (isHardProjectile)
            {
                player.TakeHardDamage(); // Schaden zufügen
            }

            Destroy(gameObject); // Projektil verschwindet nach Treffer

            if (player.currentHealth <= 0)
            {
                Die();
            }

        }
    }
    private void Die()
    {
        Debug.Log("Spieler ist tot!");
        // TODO: Animation, Tod-Bildschirm, Restart etc.
    }
}