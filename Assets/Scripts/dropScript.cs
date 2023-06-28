using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropScript : MonoBehaviour
{
    public GameManager GM;
    //public dropList DL;
    public string dropType;

    public GameObject dropScrap;
    public GameObject dropMineral;
    public GameObject dropTech;

    public void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
    }
    public void dropItems()
    {
        //int rand = Random.Range(0, 29);
        switch (dropType)
        {
            case "Scrap":

                    Instantiate(dropScrap, this.gameObject.transform.position, Quaternion.identity);
                break;
            case "Mineral":

                    Instantiate(dropMineral, this.gameObject.transform.position, Quaternion.identity);
                break;
            case "Tech":
                Vector3 spawnPos = new Vector3(this.gameObject.transform.position.x, 0.0f, this.gameObject.transform.position.z);
                    Instantiate(dropTech, spawnPos, Quaternion.identity);
                break;
        }
    }
}