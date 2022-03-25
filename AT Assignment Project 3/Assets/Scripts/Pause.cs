using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
        }
       /* if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }*/

    }
}
