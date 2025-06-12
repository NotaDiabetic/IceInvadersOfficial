using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject enemyPrefab;             // Das Prefab für den Gegner, der gespawnt wird
    public Transform[] spawnPoints;            // Die möglichen Spawnpunkte (per Inspector zuweisen)
    public float spawnInterval = 3f;           // Zeitabstand zwischen Spawns

    [Header("Spawn-Limit")]
    public int maxEnemies = 3;                 // Maximale Anzahl gleichzeitig existierender Gegner
    private int currentEnemies = 0;            // Aktuelle Anzahl der gespawnten Gegner

    void Start()
    {
        // Startet den wiederholten aufruf der SpawnEnemy Methode
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Wenn maximale gegneranzahl erreicht -> kein neuer Gegner
        if (currentEnemies >= maxEnemies)
            return;

        // Zufälligen Spawnpunkt auswählen
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnLocation = spawnPoints[randomIndex];

        // Gegner erzeugen (instanziieren)
        Instantiate(enemyPrefab, spawnLocation.position, Quaternion.identity);

        // Zähler erhöhen
        currentEnemies++;
    }

    // Diese Methode kann vom Gegner aufgerufen werden, wenn er zerstört wird
    public void ReduceEnemyCount()
    {
        currentEnemies--;
        // Sicherheitshalber: Nie negativ werden
        currentEnemies = Mathf.Max(currentEnemies, 0);
    }
}