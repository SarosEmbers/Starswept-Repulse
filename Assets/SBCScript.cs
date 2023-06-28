using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SBCScript : MonoBehaviour
{
    public GameObject player;
    public GameObject shipUI;
    public GameObject mainUI;
    public GameObject battleUI;
    public GameObject hubHub;
    public GameObject hubBay;
    public GameObject playerCam;
    public GameObject pointsUI;

    public GameObject P1Cam, P2Cam, P3Cam;
    public GameObject subPlayerCamNorth, subPlayerCamSouth, subPlayerCamEast, subPlayerCamWest;

    public Transform NintendoDS;
    public Transform AsteroidActivator;

    public GameManager GM;

    Vector3 OutOfTheWay = new Vector3(5000.0f, -2.01f, 23.0f);

    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart(int shipChosen)
    {
        /*
        switch (shipChosen)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
        }

        //Set all cams active on initial start
        subPlayerCamNorth = GameObject.Find("TopScreenCam(North)");
        subPlayerCamSouth = GameObject.Find("TopScreenCam(South)");
        subPlayerCamEast = GameObject.Find("TopScreenCam(East)");
        subPlayerCamWest = GameObject.Find("TopScreenCam(West)");
        //Set all cams except North innactive
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AsteroidActivator = GameObject.FindGameObjectWithTag("Stroid").transform;

        GameManager.playerHealth = 100;
        GM.inSpace = false;

        if (other.gameObject == player)
        {
            player.transform.position = OutOfTheWay;
            shipUI.SetActive(true);
            mainUI.SetActive(true);
            //Pause/Menu state
            battleUI.SetActive(false);
            
            hubHub.SetActive(true);
            player.SetActive(false);
            pointsUI.SetActive(false);

            GameObject[] spareEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject item in spareEnemy)
            {
                Destroy(item);
            }

            AsteroidActivator.SendMessage("UnloadScene");
            NintendoDS.SendMessage("SceneUnloaded");

            /*
            if (subPlayerCamNorth.activeSelf == true)
            {
                subPlayerCamNorth.SetActive(false);
            }
            else if (subPlayerCamSouth.activeSelf == true)
            {
                subPlayerCamSouth.SetActive(false);
            }
            else if (subPlayerCamEast.activeSelf == true)
            {
                subPlayerCamEast.SetActive(false);
            }
            else if (subPlayerCamWest.activeSelf == true)
            {
                subPlayerCamWest.SetActive(false);
            }
            else
            {
                Debug.Log("Wut");
            }
            */
        }
    }
}
