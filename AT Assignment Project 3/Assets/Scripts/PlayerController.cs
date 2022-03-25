using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float PlayerHealth = 100; 
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject Player;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(PlayerHealth);
        if (PlayerHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        //Debug.Log("DEAD");
        Player.transform.position = respawnPoint.transform.position;
        PlayerHealth = 100;
    }
}
