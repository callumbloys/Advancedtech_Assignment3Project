using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushback : MonoBehaviour
{
    public float pushbackForce = 4;
    public float speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Debug.Log("ATTACKED");
            Vector3 direction = (transform.position - other.transform.position).normalized;

            if(other.GetComponent<Rigidbody>() != null)
            {
                other.GetComponent<Rigidbody>().AddForce(direction * speed);
            }
        }
    }
}
