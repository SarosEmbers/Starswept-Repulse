using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;
    public Rigidbody rb;
    public GameObject impactEnemyEffect;
    public GameObject impactRockEffect;
    public GameObject impactScrapEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
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
            GameObject poofs = Instantiate(impactEnemyEffect, this.transform.position, this.transform.rotation);
            Destroy(poofs, 4.0f);
            Destroy(gameObject);
        }
        if (asteroid != null)
        {
            asteroid.BreakApart(damage);
            GameObject poofs = Instantiate(impactRockEffect, this.transform.position, this.transform.rotation);
            Destroy(poofs, 4.0f);
            Destroy(gameObject);
        }
        if (motherCore != null)
        {
            if (other.name == "CoreCollider")
            {
                motherCore.CoreDamage(damage);
            }
            Destroy(gameObject);
        }
        if (mothShield != null)
        {
            mothShield.ShieldDamage(damage);
            Destroy(gameObject);
        }
    }

}
