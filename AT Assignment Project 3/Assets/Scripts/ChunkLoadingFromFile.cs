using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ChunkData
{
    public Material chunksMat;
    public TerrainData[] terrainData;
    [HideInInspector] public float chunkPositionX;
    [HideInInspector] public float chunkPositionZ;
    [HideInInspector] public float chunkPositionY;
}

public class ChunkLoadingFromFile : MonoBehaviour
{
    private string saveFile;

    [SerializeField] private ChunkData chunkData;

    private List<GameObject> chunksContainer = new List<GameObject>();


    void Start()
    {
        // Serialize the object into JSON and save string.
        saveFile = JsonUtility.ToJson(chunkData);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // Load
        {
            ReadFile();
        }

        if (Input.GetKeyDown(KeyCode.U)) // Unload
        {
            WriteFile();
        }

        // distance check
    }

    public void ReadFile()
    {
        // Deserialize the JSON data .
        ChunkData _loadedData = JsonUtility.FromJson<ChunkData>(saveFile);

        float x = 0;
        float z = 0;
        const float spacing = 187.5F;
        const int rowLength = 16;


        for (int i = 0; i < chunkData.terrainData.Length; i++)
        {
            GameObject _chunk = new GameObject();

            _chunk.AddComponent<Terrain>();
            _chunk.AddComponent<TerrainCollider>();

            _chunk.GetComponent<Terrain>().materialTemplate = _loadedData.chunksMat;
            _chunk.GetComponent<Terrain>().terrainData = _loadedData.terrainData[i];
            _chunk.GetComponent<TerrainCollider>().terrainData = _loadedData.terrainData[i];

            var xPos = _loadedData.chunkPositionX + (x * spacing);
            var zPos = _loadedData.chunkPositionZ + (z * spacing);
            _chunk.transform.position = new Vector3(xPos, _loadedData.chunkPositionY, zPos);

            z++;
            if (z >= rowLength)
            {
                z = 0;
                x++;
            }

            chunksContainer.Add(_chunk);
        }
    }

    public void WriteFile()
    {
        // Serialize the object into JSON and save string.
        saveFile = JsonUtility.ToJson(chunkData);

        // Write JSON to file.
        File.WriteAllText(Application.dataPath + "chunkData.json", saveFile);

        foreach (var _chunk in chunksContainer.ToArray())
        {
            chunksContainer.Remove(_chunk);
            Destroy(_chunk);
        }
    }
}