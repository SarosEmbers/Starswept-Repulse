using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCamo : MonoBehaviour
{
    public GameObject[] enemy;

    public bool isCloaked = false;

    private Rigidbody rb;
    public GameObject player;
    public MeshRenderer playerRender;

    public float camoTimerTimer = 0; //For the cooldown
    public float camoTimer = 0; //For how long the camo lasts for
    public float camoMax = 3.5f;
    public float camoMaxCooldown = 15.0f;
    public GameObject camoParticle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (camoTimer >= 0.0f)
        {
            camoTimer -= 1 * Time.deltaTime;
        }

        if (camoTimerTimer >= 0.0f)
        {
            camoTimerTimer -= 1 * Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire3"))
        {
            if (camoTimerTimer <= 0.0f && camoTimer <= 0.0f)
            {
                GoingDark();
                isCloaked = true;
                camoTimer = camoMax;
            }
        }
    }

    public void callGoingDark()
    {
        if (camoTimerTimer <= 0.0f && camoTimer <= 0.0f)
        {
            GoingDark();
            isCloaked = true;
            camoTimer = camoMax;
        }
    }

    void GoingDark()
    {
        Debug.Log("Cloaked! What now?");

        playerRender.enabled = false;
        camoParticle.SetActive(true);
        Invoke("BackToLight", camoMax);
    }

    void BackToLight()
    {
        Debug.Log("They can see you!");

        playerRender.enabled = true;
        isCloaked = false;
        camoTimerTimer = camoMaxCooldown;
        camoParticle.SetActive(false);
    }
}
