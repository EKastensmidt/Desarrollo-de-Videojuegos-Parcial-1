using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner, IEvent
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> enemySpawnPoints;
    [SerializeField] private int maxEnemyCount = 4;
    [SerializeField] private int id;

    public int Priority => 1;

    private void OnEnable()
    {
        GameEvents.instance.onSpawnEnemies += SpawnEnemies;
    }
    private void OnDisable()
    {
        GameEvents.instance.onSpawnEnemies -= SpawnEnemies;
    }

    private void SpawnEnemies(int id)
    {
        if (id != this.id || enemyPrefabs == null || enemySpawnPoints == null)
            return;
        
        for (int i = 0; i < maxEnemyCount; i++)
        {
            int enemyType = Random.Range(0, enemyPrefabs.Count);
            GameObject e = GameObject.Instantiate(enemyPrefabs[enemyType]);
            e.transform.position = enemySpawnPoints[i].transform.position;
        }
    }
}
