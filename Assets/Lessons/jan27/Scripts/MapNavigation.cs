using System;
using System.Collections.Generic;
using UnityEngine;

public class MapNavigation : MonoBehaviour
{
    [SerializeField] private MapLibrary mapLibrary;
    [SerializeField] private Transform player;
    [SerializeField] private Transform mapParent;

    private Dictionary<int, MapData> mapDictionary = new Dictionary<int, MapData>();
    public static MapNavigation Instance;
    public event Action<PlayerAnimationState> OnEnterMap;
    public GameObject currentMap;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitializeMapLibrary();
    }

    public void InitializeMapLibrary()
    {
        foreach(MapSO map in mapLibrary.mapLibrary)
        {
            mapDictionary.Add(map.mapID, new MapData(map));
        }
    }

    public void GoToMap(int mapID, int entryPointID)
    {
        Destroy(currentMap);
        currentMap = Instantiate(mapDictionary[mapID].prefab, mapParent);

        Grid g = currentMap.GetComponent<Grid>();

        Vector3 newPosition = g.GetCellCenterWorld(mapDictionary[mapID].entryPoints[entryPointID].cell);
        player.position = newPosition;
    }
}

public class MapData {
    public GameObject prefab;
    public int mapID;
    public string mapName;
    public Dictionary<int, MapEntryPoint> entryPoints = new Dictionary<int, MapEntryPoint>();

    public MapData(MapSO config)
    {
        this.prefab = config.prefab;
        this.mapID = config.mapID;
        this.mapName = config.mapName;

        foreach(MapEntryPoint entryPoint in config.entryPoints)
        {
            entryPoints.Add(entryPoint.entryPointID, entryPoint);
        }
    }
}
