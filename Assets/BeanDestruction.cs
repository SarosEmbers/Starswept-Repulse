using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanDestruction : MonoBehaviour
{
    public int damage = 125;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        Asteroids asteroid = other.GetComponent<Asteroids>();
        MotherCore motherCore = other.GetComponent<MotherCore>();
        MotherShield mothShield = other.GetComponent<MotherShield>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (asteroid != null)
        {
            asteroid.BreakApart(damage);
        }
        if (motherCore != null)
        {
            if (other.name == "CoreCollider")
            {
                motherCore.CoreDamage(damage);
            }
        }
        if (mothShield != null)
        {
            mothShield.ShieldDamage(damage);
        }
    }
}
