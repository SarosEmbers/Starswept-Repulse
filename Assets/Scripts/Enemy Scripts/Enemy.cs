using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public dropScript DS;
    public GameManager GM;

    public int pointValue = 50;
    public float radarTimer = 10.0f;

    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        radarTimer -= 1 * Time.deltaTime;
        if (radarTimer <= 0)
        {
            radarPing();
            radarTimer = 10.0f;
        }
    }
    public void TakeDamage (int gamage)
    {
        health -= gamage;

        Debug.Log(health);

        if (health <= 25)
        {

        }
        if (health <= 0)
        {
            Die();
        }
    }
    void Die ()
    {
        if (this.gameObject.name == "Moth_Turret")
        {

        }
        else
        {
            DS.dropItems();
            Destroy(gameObject);
            GM.points = GM.points + pointValue;
        }
    }
    public void radarPing()
    {
        this.gameObject.GetComponent<EnemyFiring>().findTarget();
        this.gameObject.GetComponent<FlockerScript>().reTargetPlayer();
    }
}
