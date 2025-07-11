using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject simpleEnemyPrefab;             // Das Prefab für den Gegner, der gespawnt wird
    public GameObject mediumEnemyPrefab;             // Das Prefab für den mittleren Gegner, der gespawnt wird
    public GameObject hardEnemyPrefab;               // Das Prefab für den schweren Gegner, der gespawnt wird
    public Transform[] spawnPoints;          // Die möglichen Spawnpunkte (per Inspector zuweisen)
    public float spawnInterval = 3f;           // Zeitabstand zwischen Spawns

    [Header("Spawn-Limit")]
    public int maxEnemies = 3;                 // Maximale Anzahl gleichzeitig existierender Gegner
    public int spawnedEnemies = 0;
    [SerializeField] EnemyBehavior behavior;
    [SerializeField] Pause_Manager pause;

    [Header("Wellen-Einstellungen")]
    public int simpleEnemiesPerWave = 0;
    public int mediumEnemiesPerWave = 0;
    public int hardEnemiesPerWave = 0;




    void Start()
    {
        InvokeRepeating(nameof(SpawnWaveEnemy), 3f, spawnInterval);
    }
    void SpawnWaveEnemy()
    {
        StartCoroutine(SpawnSimpleEnemies(simpleEnemiesPerWave));
        StartCoroutine(SpawnMediumEnemies(mediumEnemiesPerWave));
        StartCoroutine(SpawnHardEnemies(hardEnemiesPerWave));
    }

    // Hilfsmethode zum Spawnen einer bestimmten Anzahl eines Gegnertyps
    public IEnumerator SpawnSimpleEnemies(int count)
    {
        yield return new WaitForSeconds(0);
        for (int i = 0; i < count; i++)
        {
            if (spawnedEnemies < maxEnemies && spawnPoints.Length != 0)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnLocation = spawnPoints[randomIndex];

                Instantiate(simpleEnemyPrefab, spawnLocation.position, Quaternion.identity);
                spawnedEnemies++;
            }
            
        }
    }

    public IEnumerator SpawnMediumEnemies(int count)
    {
        yield return new WaitForSeconds(4);
        for (int i = 0; i < count; i++)
        {
            if (spawnedEnemies < maxEnemies && spawnPoints.Length != 0)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnLocation = spawnPoints[randomIndex];

                Instantiate(mediumEnemyPrefab, spawnLocation.position, Quaternion.identity);
                spawnedEnemies++;
            }
        }
    }
    public IEnumerator SpawnHardEnemies(int count)
    {
        yield return new WaitForSeconds(7);
        for (int i = 0; i < count; i++)
        {
            if (spawnedEnemies < maxEnemies && spawnPoints.Length != 0)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnLocation = spawnPoints[randomIndex];

                Instantiate(hardEnemyPrefab, spawnLocation.position, Quaternion.identity);
                spawnedEnemies++;
            }
        }
    }
}