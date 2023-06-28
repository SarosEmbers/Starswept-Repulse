using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> playerShipsToChoose = new List<GameObject>
    {

    };
    public static int chosenShip;
    public static GameObject playerShip;
    public GameObject[] enemy;

    public EnemyFiring EF;
    public ShipMovement SM;
    public FlockerScript FS;
    public TouchMenus TM;

    public static int playerHealth = 100;
    public int stateManager = 1;

    public bool upgradeThruster = false;
    public bool upgradeCamo = false;
    public bool upgradeEMP = false;
    public bool upgradeLaser = false;

    public bool inSpace = false;

    public int invScrap = 0;
    public int invMineral = 0;
    public int invTech = 0;
    public int invWarpCore = 0;
    public int invArchCore = 0;
    public int invCoin = 0;
    public int points = 0;

    public GameObject ChangeCams;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //SM = player.GetComponent<ShipMovement>();
        enemy = GameObject.FindGameObjectsWithTag("Enemy"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager == 1)
        {
            menuState();
        } else if (stateManager == -1)
        {
            worldState();
        }
        if (playerHealth <= 0)
        {
            ChangeCams.GetComponent<changeCam>().GameOver();
        }
    }
    public void ResetEverything()
    {
        playerHealth = 100;
        playerHealth = 100;
        stateManager = 1;

        upgradeThruster = false;
        upgradeCamo = false;
        upgradeEMP = false;
        upgradeLaser = false;

        invScrap = 0;
        invMineral = 0;
        invTech = 0;
        invWarpCore = 0;
        invArchCore = 0;
        invCoin = 0;
        points = 0;
    }
    /*
    public void RestartLevel()
    {
        Debug.Log("Restart");
        changeCam.GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("NintendoDSTestbed");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("NintendoDSTestbed");

    }    */
    public void stateChange()
    {
        stateManager *= -1;
    }
    public void worldState()
    {
        /*
        SM.maxVelocity = 7.0f;
        for (int i = 0; i < enemy.Length; i++)
        {
            FS = enemy[i].GetComponent<FlockerScript>();
            EF = enemy[i].GetComponent<EnemyFiring>();
            FS.maxVel = 5.0f;
            EF.findTarget();
        }
        */
    }
    public void menuState()
    {
        /*
        SM.maxVelocity = 0;
        for (int i = 0; i < enemy.Length; i++)
        {
            FS = enemy[i].GetComponent<FlockerScript>();
            EF = enemy[i].GetComponent<EnemyFiring>();
            FS.maxVel = 0.0f;
            EF.TargetSpotted = null;
        }
        */
    }

    public void GameLoaded()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player");
        if (playerShip.name == "Player1")
        {
            chosenShip = 0;
        }
        else if (playerShip.name == "Player2")
        {
            chosenShip = 1;
        }
        else if (playerShip.name == "Player3")
        {
            chosenShip = 2;
        }
    }

    public void WantToBuy(string thingToBuy)
    {
        switch (thingToBuy)
        {
            case "Scrap":
                if (invCoin >= 5)
                {
                    invCoin = invCoin - 5;
                    invScrap++;
                }
                else if (invCoin <= 4)
                {
                    TM.YouFool("Mon");
                }

                break;
            case "Mineral":
                if (invCoin >= 10)
                {
                    invCoin = invCoin - 10;
                    invMineral++;
                }
                else if (invCoin <= 9)
                {
                    TM.YouFool("Mon");
                }

                break;
            case "Core":
                if (invMineral >= 15 && invTech >= 10)
                {
                    invMineral = invMineral - 15;
                    invTech = invTech - 10;
                    invWarpCore++;
                }
                else if (invMineral <= 14 && invTech <= 9)
                {
                    TM.YouFool("Mon");
                }

                break;
        }
    }

    public void WantToSell(string thingToSell)
    {
        switch (thingToSell)
        {
            case "Scrap":
                if (invScrap >= 1)
                {
                    invScrap--;
                    invCoin = invCoin + 5;
                }
                else if (invScrap == 0)
                {
                    TM.YouFool("Stuff");
                }

                break;
            case "Mineral":
                if (invMineral >= 1)
                {
                    invMineral--;
                    invCoin = invCoin + 10;
                }
                else if (invMineral == 0)
                {
                    TM.YouFool("Stuff");
                }

                break;
            case "Tech":
                if (invTech >= 1)
                {
                    invTech--;
                    invCoin = invCoin + 25;
                }
                else if (invTech == 0)
                {
                    TM.YouFool("Stuff");
                }

                break;
        }
    }

    public void CraftAbility(string abilityToCraft)
    {
        switch (abilityToCraft)
        {
            case "EMP":
                //TM.YouFool("Stuff");
                break;
            case "Thruster":

                break;
            case "Camo":

                break;
            case "Laser":

                break;
        }
    }
}
