using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenue : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuTop, pauseMenuBottom;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Start"))
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            Debug.Log("SCREEEEE");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuTop.SetActive(false);
        pauseMenuBottom.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuTop.SetActive(true);
        pauseMenuBottom.SetActive(true);

        Time.timeScale = 0f;

        GameIsPaused = true;
    }
}
