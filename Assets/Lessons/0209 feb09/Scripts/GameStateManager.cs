using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public List<MapState> mapStates;
    public Transform mapParent;
    private EnemySpawner spawner;
    private MapState currentMap;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        foreach(MapState map in mapStates)
        {
            map.InitializeEnemyDictionary();
        }
    }
    public void InitializeMap(int mapID_)
    {
       
        foreach (MapState mapState in mapStates)
        {
            if (mapState.mapData.mapID == mapID_)
            {
                currentMap = mapState;
            }
        }
        BeginEnemySpawn(currentMap);
    }

    [ContextMenu("Try Save")]
    public void SaveMapState()
    {
        if (spawner == null) return;
        List<Enemy> activeEnemies = spawner.activeEnemies;
        foreach(Enemy enemy in activeEnemies)
        {
            currentMap.enemyDictionary[enemy.enemyID].currentHP = enemy.HP;
        }
    }

    public void BeginEnemySpawn(MapState map)
    {
        spawner = mapParent.GetComponentInChildren<EnemySpawner>();
        foreach(EnemyState enemy in map.enemies)
        {
            if(enemy.currentHP > 0) spawner.Spawn(enemy);
        }
    }
}

[Serializable]
public class MapState
{
    public MapSO mapData;

    public List<EnemyState> enemies;
    public Dictionary<int, EnemyState> enemyDictionary;

    public void InitializeEnemyDictionary()
    {
        enemyDictionary
             = new Dictionary<int, EnemyState>();
        foreach(EnemyState enemy in enemies)
        {
            enemyDictionary.Add(enemy.enemyID, enemy);
        }
    }
}

[Serializable]
public class EnemyState
{
    public int enemyID;
    public EnemySO enemyData;
    public int currentHP;
}
