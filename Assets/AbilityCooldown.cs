using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    public Slider s_dash, s_EMP, s_camo, s_beam;
    public WDash dash;
    public WEmp emp;
    public WCamo cloak;
    public WBigBeam beam;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        s_dash.value = player.GetComponent<WDash>().dashTimer;
        s_EMP.value = player.GetComponent<WEmp>().EMPTimer;
        s_camo.value = player.GetComponent<WCamo>().camoTimerTimer;
        s_beam.value = player.GetComponent<WBigBeam>().beamTimerTimer;
    }
}
