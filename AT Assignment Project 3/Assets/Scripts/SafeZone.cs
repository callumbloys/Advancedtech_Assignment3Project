using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafeZone : MonoBehaviour
{
    public static bool isSafe;
    public GameObject safeZoneText;

    void Start()
    {
        isSafe = false;
        safeZoneText.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isSafe = true;
            safeZoneText.SetActive(true);
            Debug.Log("entering safe zone");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isSafe = false;
        safeZoneText.SetActive(false);
        Debug.Log("exiting safe zone");
    }
}
