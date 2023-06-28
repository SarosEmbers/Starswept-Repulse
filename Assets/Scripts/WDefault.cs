using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WDefault : MonoBehaviour
{
    public Transform firePointL;
    public Transform firePointR;
    public Transform firePointL2;
    public Transform firePointR2;

    public bool switchoffL;
    public bool switchoffR;

    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Trigger1"))
        {
            ShootL();
        }
        if (Input.GetButtonDown("Trigger2"))
        {
            ShootR();
        }
    }

    void ShootL ()
    {
        // Shooting Logic
        if (firePointL2 != null && switchoffL == true)
        {
            GameObject lpBullet = Instantiate(bulletPrefab, firePointL2.position, firePointL2.rotation);
            Destroy(lpBullet, 2.5f);
            switchoffL = false;
        }
        else
        {
            GameObject lpBullet = Instantiate(bulletPrefab, firePointL.position, firePointL.rotation);
            Destroy(lpBullet, 2.5f);
            switchoffL = true;
        }
    }

    void ShootR ()
    {
        if(firePointR2 != null && switchoffR == true)
        {
            GameObject rpBullet = Instantiate(bulletPrefab, firePointR2.position, firePointR2.rotation);
            Destroy(rpBullet, 2.5f);
            switchoffR = false;
        }
        else
        {
            GameObject rpBullet = Instantiate(bulletPrefab, firePointR.position, firePointR.rotation);
            Destroy(rpBullet, 2.5f);
            switchoffR = true;
        }
    }
}
