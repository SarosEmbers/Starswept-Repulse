using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBigBeam : MonoBehaviour
{
    public GameObject player;

    public ParticleSystem beamBeam;

    public float beamTimerTimer = 0; //For the cooldown
    public float beamTimer = 0; //For how long the camo lasts for
    public float beamMax = 2.0f;
    public float beamMaxCooldown = 60.0f;
    public BoxCollider beamBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beamTimer >= 0.0f)
        {
            beamTimer -= 1 * Time.deltaTime;
        }

        if (beamTimerTimer >= 0.0f)
        {
            beamTimerTimer -= 1 * Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (beamTimerTimer <= 0.0f && beamTimer <= 0.0f)
            {
                BigBeam();
                beamTimer = beamMax;
            }
        }
    }

    public void callBigBeam()
    {
        if (beamTimerTimer <= 0.0f && beamTimer <= 0.0f)
        {
            BigBeam();
            beamTimer = beamMax;
        }
    }

    void BigBeam()
    {
        Debug.Log("Annihilate them all.");
        beamBox.enabled = true;
        beamBeam.Play();

        Invoke("NoMoreBeam", beamMax);
    }

    void NoMoreBeam()
    {
        beamBox.enabled = false;
        beamBeam.Stop();
        beamTimerTimer = beamMaxCooldown;
    }
}
