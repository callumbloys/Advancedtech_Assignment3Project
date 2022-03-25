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

    [SerializeField] private Transform player;
    [SerializeField] private ChunkData chunkData;

    private List<GameObject> chunksContainer = new List<GameObject>();

    [ContextMenu("Generate Terrain")]
    void Start()
    {
        // Convert the saveFile chunkdata to to json format
        saveFile = JsonUtility.ToJson(chunkData);

        float x = 0;
        float z = 0;
        const float chunkSize = 187.5F;
        const int rowLength = 16;

        for (int i = 0; i < chunkData.terrainData.Length; i++)
        {
            ChunkData _loadedData = new ChunkData();

            // Create chunk
            GameObject _chunk = new GameObject("Chunk " + x + "," + z);
            _chunk.AddComponent<Chunk>().isLoaded = true;
            _chunk.AddComponent<Terrain>();
            _chunk.AddComponent<TerrainCollider>();

            var xPos = 0.0f;
            var zPos = 0.0f;

            string path = Application.dataPath + "/ChunkData/Chunk " + x + "," + z + ".json";
            if (File.Exists(path))
            {
                print("File exists, loading data from file");

                // If a json file exists, read data from it
                _loadedData = JsonUtility.FromJson<ChunkData>(File.ReadAllText(path));
                xPos = _loadedData.chunkPositionX;
                zPos = _loadedData.chunkPositionZ;
            }

            else // NOTE for self: Unoptimised. Iterates thru this block each iteration - don't do dis
            {
                print("No files exist, loading with serialised data");
                // Grab data from serialised chunkdata
                _loadedData = JsonUtility.FromJson<ChunkData>(saveFile);
                xPos = (x * chunkSize);
                zPos = (z * chunkSize);
            }

            _chunk.GetComponent<Terrain>().terrainData = _loadedData.terrainData[i];
            _chunk.GetComponent<TerrainCollider>().terrainData = _loadedData.terrainData[i];
            _chunk.GetComponent<Terrain>().materialTemplate = _loadedData.chunksMat;
            _chunk.transform.position = new Vector3(xPos, _loadedData.chunkPositionY, zPos);

            z++;
            if (z >= rowLength)
            {
                z = 0;
                x++;
            }

            _chunk.transform.parent = transform;
            chunksContainer.Add(_chunk);

            // Convert the new chunkdata to to json format
            saveFile = JsonUtility.ToJson(_loadedData, true);

            // Write new chunkdata to JSON file
            File.WriteAllText(Application.dataPath + "/ChunkData/" + _chunk.name + ".json", saveFile);
        }     
    }
   
    public void LoadChunk(GameObject chunk, int index)
    {
        ChunkData _loadedData = new ChunkData();

        chunk.AddComponent<Terrain>();
        chunk.AddComponent<TerrainCollider>();


        string path = Application.dataPath + "/ChunkData/" + chunk.name + ".json";
        _loadedData = JsonUtility.FromJson<ChunkData>(File.ReadAllText(path));


        //chunk.GetComponent<Terrain>().terrainData         = _loadedData.terrainData[index];
        //chunk.GetComponent<TerrainCollider>().terrainData = _loadedData.terrainData[index];
        chunk.GetComponent<Terrain>().materialTemplate    = _loadedData.chunksMat;
        chunk.transform.position = new Vector3(_loadedData.chunkPositionX, _loadedData.chunkPositionY, _loadedData.chunkPositionZ); 
        chunk.transform.parent = transform;

        chunk.GetComponent<Chunk>().isLoaded = true;
        //chunk.SetActive(true);
        chunksContainer.Add(chunk);

    }

    public void UnloadChunk(GameObject chunk, int index)
    {
        ChunkData dataToSave = new ChunkData();
        dataToSave.chunkPositionX = chunk.transform.position.x;
        dataToSave.chunkPositionY = chunk.transform.position.y;
        dataToSave.chunkPositionZ = chunk.transform.position.z;
        dataToSave.chunksMat = chunk.GetComponent<Terrain>().materialTemplate;

        //dataToSave.terrainData[index] = new TerrainData();
        //dataToSave.terrainData[index] = chunk.GetComponent<Terrain>().terrainData;





        // Convert the new chunkdata to to json format
        saveFile = JsonUtility.ToJson(dataToSave, true);

        // Write new chunkdata to JSON file
        File.WriteAllText(Application.dataPath + "/ChunkData/" + chunk.name + ".json", saveFile);

        Destroy(chunk.GetComponent<Terrain>());
        Destroy(chunk.GetComponent<TerrainCollider>());

        chunk.GetComponent<Chunk>().isLoaded = false;
        //chunk.SetActive(false);
        chunksContainer.Remove(chunk);
    }

    public List<GameObject>GetChunks()
    {
        return chunksContainer;
    }
}