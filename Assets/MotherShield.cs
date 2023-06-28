using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShield : MonoBehaviour
{
    public int shieldHealth = 250;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShieldDamage(int gamage)
    {
        shieldHealth -= gamage;

        Debug.Log(shieldHealth);

        if (shieldHealth <= 25)
        {

        }
        if (shieldHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
