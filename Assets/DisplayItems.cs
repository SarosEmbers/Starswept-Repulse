using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItems : MonoBehaviour
{
    public GameManager GM;
    public string textValue;
    public Text numofScrap;
    public Text numofMineral;
    public Text numofTech;
    public Text numofWarp;
    public Text numofCoin;
    public Text overallPoints;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        numofScrap.text = GM.invScrap.ToString();
        numofMineral.text = GM.invMineral.ToString();
        numofTech.text = GM.invTech.ToString();
        numofWarp.text = GM.invWarpCore.ToString();
        numofCoin.text = GM.invCoin.ToString();
        overallPoints.text = GM.points.ToString();
    }
}
