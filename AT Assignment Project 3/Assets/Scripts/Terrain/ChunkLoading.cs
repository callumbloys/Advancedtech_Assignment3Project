using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoading : MonoBehaviour
{
    private Transform player;
    [SerializeField] private ChunkLoadingFromFile chunkLoadingFromFile;

    private void Awake()
    {
        player = transform;
    }

    private void Update()
    {
        for(int i = 0; i < chunkLoadingFromFile.GetChunks().Count; i++)
        {
            if (Vector3.Distance(player.position, chunkLoadingFromFile.GetChunks()[i].transform.position) > 600)
            {
                // if chunk is loaded, unload it
                if(chunkLoadingFromFile.GetChunks()[i].GetComponent<Chunk>().isLoaded)
                {
                    chunkLoadingFromFile.UnloadChunk(chunkLoadingFromFile.GetChunks()[i], i);
                }
            }

            if (Vector3.Distance(player.position, chunkLoadingFromFile.GetChunks()[i].transform.position) < 600)
            {
                // if chunk is unloaded, load it
                if (!chunkLoadingFromFile.GetChunks()[i].GetComponent<Chunk>().isLoaded)
                {
                    chunkLoadingFromFile.LoadChunk(chunkLoadingFromFile.GetChunks()[i], i);
                }
            }
        }
    }
}

