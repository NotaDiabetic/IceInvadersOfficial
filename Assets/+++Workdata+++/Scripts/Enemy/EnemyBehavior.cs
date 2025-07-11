using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 1f;               // Wie schnell sich der Gegner bewegt
    private Transform player;                  // Referenz zum Spieler-Objekt
    public float enemyHealth;
    public GameObject MediumDrop;
    public GameObject RareDrop;
    public Transform Enemy;
    [SerializeField] public EnemySpawner spawner;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SimpleSnowball"))
        {
            enemyHealth--;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("MediumSnowball"))
        {
            enemyHealth -= 2;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("HardSnowball"))
        {
            enemyHealth -= 3;
        }
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            float randValue = Random.value;
            spawner.currentEnemies--;
            if (randValue < .45f)
            {
                return;
            }
            else if (randValue < .9f)
            {
                GameObject MD = Instantiate(MediumDrop);
                MD.transform.position = Enemy.position;
            }
            else
            {
                GameObject RD = Instantiate(RareDrop);
                RD.transform.position = Enemy.position;
            }
        }
    }

}