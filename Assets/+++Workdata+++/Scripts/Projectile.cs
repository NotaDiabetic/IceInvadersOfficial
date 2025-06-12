using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;     // Geschwindigkeit des Projektills
    public float lifetime = 5f;      // Lebensdauer
    public float damage = 1f;   // Wie viel Schaden es dem spiler macht

    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }

    // Beispielhafte Kollision mit Spieler
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Beispiel: Spieler-Script hat eine "TakeDamage(float dmg)" Methode
            other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }*/
}