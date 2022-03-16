using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoading : MonoBehaviour
{
    [SerializeField] private List<GameObject> chunks;
   //[SerializeField] private float chunkRadius = 0.6f;
    [SerializeField] private Camera mainCamera;

    public GameObject player;

    public float distanceThreshold = 100;

    private void Start()
    {
        /*foreach (GameObject chu in chunks)
        {
            chu.SetActive(false);
        }
        chunks[135].SetActive(true);*/
    }

    void Update()
    {
        /*if (player.transform.position == chunks[].transform.position)
        {

        }*/

        foreach (GameObject chunk in chunks)
        {
            if ((player.transform.position.magnitude - chunk.transform.position.magnitude + 150) > distanceThreshold)
            {
                chunk.SetActive(true);
                Debug.Log("rendering chunk");
            }               
            else
            {
                chunk.SetActive(false);
            }
        }
    }

    private void LoadedChunks()
    {
        
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
}

