using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeCam : MonoBehaviour
{
    public Canvas TopCanvas;
    public Camera testCam;
    public GameManager GM;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuTop, pauseMenuBottom, battleUIBottom, pointCounter, gameOverTop, gameOverBottom;

    private void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        gameOverTop.SetActive(false);
        gameOverBottom.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("."))
        {
            swapCheck();

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

    public void swapCheck()
    {

        TopCanvas.worldCamera = Camera.main;
        Debug.Log(Camera.main.name);
    }
    public void Resume()
    {
        pauseMenuTop.SetActive(false);
        pauseMenuBottom.SetActive(false);
        battleUIBottom.SetActive(true);

        Time.timeScale = 1f;

        GameIsPaused = false;
    }
    void Pause()
    {
        if (GM.inSpace == true)
        {
            pauseMenuTop.SetActive(true);
            pauseMenuBottom.SetActive(true);
            battleUIBottom.SetActive(false);

            Time.timeScale = 0f;

            GameIsPaused = true;
        }
    }
    public void LoadMenu()
    {
        //GM.RestartLevel()
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void GameOver()
    {
        gameOverTop.SetActive(true);
        gameOverBottom.SetActive(true);
        battleUIBottom.SetActive(false);

        Time.timeScale = 0.3f;

        GameIsPaused = true;
    }
    public void RestartLevel()
    {
        gameOverTop.SetActive(false);
        gameOverBottom.SetActive(false);

        Debug.Log("Restart");
        GameIsPaused = false;
        Time.timeScale = 1f;
        //SceneManager.LoadScene("NintendoDSTestbed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GM.ResetEverything();
    }
}
