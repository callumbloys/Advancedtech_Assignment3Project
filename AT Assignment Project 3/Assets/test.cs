using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private TerrainData[,] worldTerrains = new TerrainData[1, 1];//new TerrainData[16,16];

    [SerializeField] private List<TerrainData> chunksList = new List<TerrainData>();

    private GameObject tGameObject;

    void Start()
    {
        foreach (var terData in chunksList)
        {
            var tData = Resources.Load<TerrainData>("Terrain/" + terData.name);
            tGameObject = Terrain.CreateTerrainGameObject(tData);
        }

        for (int x = 0; x < worldTerrains.GetLength(0); x++)
        {
            for (int y = 0; y < worldTerrains.GetLength(1); y++)
            {
                worldTerrains[x, y] = Resources.Load<TerrainData>("Terrain/" + chunksList[10].name );

                print(worldTerrains[x, y]);

                tGameObject = Terrain.CreateTerrainGameObject(worldTerrains[x, y]);
            }
        }
    }
}
