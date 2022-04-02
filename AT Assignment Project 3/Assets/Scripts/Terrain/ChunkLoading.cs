using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoading : MonoBehaviour
{
    [SerializeField] private ChunkLoadingFromFile chunkLoadingFromFile;

    private void Update()
    {
        foreach(GameObject chunk in chunkLoadingFromFile.GetChunks().ToArray())
        {
            // If chunk is loaded, unload it
            if (Vector3.Distance(transform.position, chunk.transform.position) > 600)
            {
                // if chunk is loaded, unload it
                if (chunk.GetComponent<Chunk>().isLoaded)
                {
                    chunkLoadingFromFile.UnloadChunk(chunk);
                }
            }

            // If chunk is unloaded, load it
            else if (Vector3.Distance(transform.position, chunk.transform.position) <= 600)
            {
                // if chunk is loaded, unload it
                if (!chunk.GetComponent<Chunk>().isLoaded)
                {
                    chunkLoadingFromFile.LoadChunk(chunk);
                }
            }
        }
    }



    /*private Transform player;
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
                    chunkLoadingFromFile.UnloadChunk(chunkLoadingFromFile.GetChunks()[i]);
                }
            }

            if (Vector3.Distance(player.position, chunkLoadingFromFile.GetChunks()[i].transform.position) < 600)
            {
                // if chunk is unloaded, load it
                if (!chunkLoadingFromFile.GetChunks()[i].GetComponent<Chunk>().isLoaded)
                {
                    chunkLoadingFromFile.LoadChunk(chunkLoadingFromFile.GetChunks()[i]);
                }
            }
        }
    }*/
}

