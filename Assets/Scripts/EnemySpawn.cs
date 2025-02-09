using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnSpeed = 1f;
    public GameObject enemyPrefab;
    public Vector2 spawnMin = new Vector2(-5, -5);
    public Vector2 spawnMax = new Vector2(5, 5);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f / spawnSpeed);
    }

    // Update is called once per frame

    void SpawnEnemy() {
        float randomX = Random.Range(spawnMin.x, spawnMax.x);
        float randomY = Random.Range(spawnMin.y, spawnMax.y);
        Instantiate(enemyPrefab, new Vector2(randomX, randomY), Quaternion.identity);
    }
    void Update()
    {
        
    }
}
