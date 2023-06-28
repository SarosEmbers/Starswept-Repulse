using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherCore : MonoBehaviour
{
    public int health = 100;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoreDamage(int gamage)
    {
        health = health - gamage;

        if (health <= 0.0f)
        {
            this.gameObject.GetComponentInParent<mothership>().CoreDestroyed();
        }
    }
}
