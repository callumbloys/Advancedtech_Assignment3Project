using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject gunOnFloor;

    private bool pickedUp = false;
    public static bool hasGun = false;

    private void Start()
    {
        gun.SetActive(false);
        gunOnFloor.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickedUp)
        {
            gun.SetActive(true);
            gunOnFloor.SetActive(false);
            Debug.Log("pickup Gun");
            hasGun = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickedUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickedUp = false;
        }

    }
}
