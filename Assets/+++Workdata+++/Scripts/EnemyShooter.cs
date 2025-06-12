using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;    // Projektil-Prefab (z.B. Schneeball)
    public Transform shootPoint;          // Wo das Projektil startet (z.B. Mund, Mitte, etc.)
    public float shootInterval = 2f;      // Zeit zwischen Schüssen
    public float projectileSpeed = 5f;    // Geschwindigkeit des Projektils

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        InvokeRepeating(nameof(Shoot), 1f, shootInterval);
    }

    void Shoot()
    {
        if (player == null || projectilePrefab == null || shootPoint == null)
            return;

        // Richtung zum Spieler berechnen
        Vector3 direction = (player.position - shootPoint.position).normalized;

        // Projektil erzeugen
        GameObject proj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // Richtung & Geschwindigkeit setzen
        Projectile projScript = proj.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.speed = projectileSpeed;
            projScript.SetDirection(direction);
        }
    }
}