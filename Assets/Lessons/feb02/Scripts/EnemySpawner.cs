using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<EnemySO> spawnPool = new List<EnemySO>();

    [ContextMenu("Spawn Enemy")]
    public void Spawn()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        EnemySO enemyToSpawn = spawnPool[Random.Range(0, spawnPool.Count)];
        GameObject tmp = Instantiate(enemyToSpawn.prefab, spawnPoint.position, Quaternion.identity);
        Enemy e = tmp.GetComponent<Enemy>();
        e.HP = enemyToSpawn.HP;
        e.DEF = enemyToSpawn.DEF; 
        e.ATK = enemyToSpawn.ATK;
    }
}
