using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchMenus : MonoBehaviour
{
    public GameObject player;
    Transform playerActions;
    Vector3 NorthSpawn = new Vector3(5000.0f, -2.01f, 23.0f);
    Vector3 SouthSpawn = new Vector3(5000.0f, -2.01f, -23.0f);
    Vector3 EastSpawn = new Vector3(5054.0f, -2.01f, 0.0f);
    Vector3 WestSpawn = new Vector3(4946.0f, -2.01f, -23.0f);

    public GameManager GM;

    public string Direction = "North";

    public GameObject noWarp, noMon, nonResource;

    public void StartGame ()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
    }
    public void QuitGame()
    {
        Debug.Log("Quitter");
        Application.Quit();
    }

    public void LoadNorth()
    {
        SceneManager.LoadScene("LvlNorth", LoadSceneMode.Additive);
        //SceneLoaded();
        Invoke("SceneLoaded", 0.3f);
        Direction = "North";
        GM.inSpace = true;
    }
    public void LoadEast()
    {
        SceneManager.LoadScene("LvlEast", LoadSceneMode.Additive);
        //SceneLoaded();
        Invoke("SceneLoaded", 0.3f);
        Direction = "East";
        GM.inSpace = true;
    }
    public void LoadSouth()
    {
        SceneManager.LoadScene("LvlSouth", LoadSceneMode.Additive);
        //SceneLoaded();
        Invoke("SceneLoaded", 0.3f);
        Direction = "South";
        GM.inSpace = true;
    }
    public void LoadWest()
    {
        SceneManager.LoadScene("LvlWest", LoadSceneMode.Additive);
        //SceneLoaded();
        Invoke("SceneLoaded", 0.3f);
        Direction = "West";
        GM.inSpace = true;
    }

    public void SetPlayerActive()
    {
        /*
        switch (GameManager.playerShip.name)
        {
            case "Player1":
                break;
            case "Player2":
                break;
            case "Player3":
                break;
        }
        */
        GameManager.playerShip.SetActive(true);
    }

    public void SceneLoaded()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerActions = GameObject.FindGameObjectWithTag("Player").transform;

        /*player.GetComponent<WDefault>();
        player.GetComponent<WDash>();
        player.GetComponent<WBigBeam>();
        player.GetComponent<WCamo>();
        player.GetComponent<WEmp>();
        */
        switch (Direction)
        {
            case "North":
                player.transform.position = NorthSpawn;
                break;
            case "South":
                player.transform.position = SouthSpawn;
                break;
            case "East":
                player.transform.position = EastSpawn;
                break;
            case "West":
                player.transform.position = WestSpawn;
                break;
        }
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    public void SceneUnloaded()
    {
        switch (Direction)
        {
            case "North":
                SceneManager.UnloadSceneAsync("LvlNorth");
                break;
            case "South":
                SceneManager.UnloadSceneAsync("LvlSouth");
                break;
            case "East":
                SceneManager.UnloadSceneAsync("LvlEast");
                break;
            case "West":
                SceneManager.UnloadSceneAsync("LvlWest");
                break;
        }
    }

    public void Warp()
    {
        Debug.Log("Checkpoint 1");

        if (GM.invWarpCore >= 1)
        {
            Vector3 toSafety = new Vector3(5000.0f, -2.01f, 23.0f);

            player.transform.position = toSafety;
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else
        {
            YouFool("Wrap");
        }
    }

    public void YouFool(string getGot)
    {
        switch (getGot)
        {
            case "Wrap":
                noWarp.SetActive(true);

                break;
            case "Mon":
                noMon.SetActive(true);

                break;
            case "Stuff":
                nonResource.SetActive(true);

                break;
        }

        Invoke("NowGoOn", 1.5f);
    }

    public void NowGoOn()
    {
        Debug.Log("Checkpoint 2");
        if (noWarp.activeSelf == true)
        {
            noWarp.SetActive(false);
        }
        if (nonResource.activeSelf == true)
        {
            nonResource.SetActive(false);
        }
        if (noMon.activeSelf == true)
        {
            noMon.SetActive(false);
        }
    }

    public void BattleUI(string action)
    {
        playerActions.SendMessage(action);
    }

    public void RotateShip(string leftOrRight)
    {
        playerActions.SendMessage(leftOrRight);
    }
}
