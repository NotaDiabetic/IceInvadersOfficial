using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 1f;               // Wie schnell sich der Gegner bewegt
    private Transform player;                  // Referenz zum Spieler-Objekt

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Richtung vom Gegner zum Spieler berechnen
            Vector3 direction = (player.position - transform.position).normalized;

            // Gegner in Richtung Spieler bewegen
            transform.position += direction * (moveSpeed * Time.deltaTime);
        }


    }

}