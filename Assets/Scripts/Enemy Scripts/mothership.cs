using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothership : MonoBehaviour
{
    public GameObject turret, enemyShip, Player;
    public int health = 10;
    public float spawnTCooldown = 15.0f;
    public float spawnECooldown = 40.0f;
    public float spawnTMax = 15.0f;
    public float spawnEMax = 40.0f;

    public GameObject[] TurretSpawns;
    public GameManager GM;
    public GameObject DestructionParticles, Explosion;
    public GameObject FleeUI;
    public enum MotherDifficulty
    {
        Test,
        Easy,
        Medium,
        Hard,
        AllScape
    }
    public MotherDifficulty Difficulty = MotherDifficulty.Easy;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        spawnTCooldown -= 1 * Time.deltaTime;
        spawnECooldown -= 1 * Time.deltaTime;
        if (spawnTCooldown <= 0)
        {
            //spawnTurrets();
            spawnTCooldown = spawnTMax;
        }

        if (spawnECooldown <= 0)
        {
            //spawnEnemeis();
            spawnECooldown = spawnEMax;
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //spawnEnemeis();
            spawnTurrets();
        }
    }

    public void CoreDestroyed()
    {
        Debug.Log("Core Destroyed");
        //ESCAPE
        GameObject[] closeEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in closeEnemy)
        {
            Vector3 vectorToTarget = enemy.transform.position - transform.position;
            float distanceToTarget = vectorToTarget.magnitude;
            if (distanceToTarget == 400.0f)
            {
                enemy.SendMessage("RandRotate");
            }
        }
        this.gameObject.GetComponent<SlowlySpin>().enabled = false;
        DestructionParticles.SetActive(true);
        Invoke("BigExplosion", 10.0f);
        FleeUI.SetActive(true);
    }

    public void spawnTurrets()
    {

        switch (Difficulty)
        {
            case MotherDifficulty.Test:

                foreach(GameObject turretSpot in TurretSpawns)
                {
                    GameObject leTurrets = Instantiate(turret, new Vector3(turretSpot.transform.position.x, turretSpot.transform.position.y, turretSpot.transform.position.z), Quaternion.identity);
                    leTurrets.transform.parent = this.transform;
                }

            break;
            case MotherDifficulty.Easy:

                break;
            case MotherDifficulty.Medium:

                break;
            case MotherDifficulty.Hard:

                break;
            case MotherDifficulty.AllScape:

                break;
        }
        /*
        int rand = Random.Range(1, 16);
        Instantiate(turret, new Vector3(TurretSpawns[rand].transform.position.x, TurretSpawns[rand].transform.position.y, TurretSpawns[rand].transform.position.z), Quaternion.identity);
        */
    }
    public void spawnEnemeis()
    {
        float rand = Random.Range(-30.0f, 30.0f);
        Instantiate(enemyShip, new Vector3(transform.position.x + rand, transform.position.y + rand, transform.position.z), Quaternion.identity);
    }

    public void BigExplosion()
    {
        FleeUI.SetActive(false);
        GameObject explosionParticle = Instantiate(Explosion, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        Destroy(explosionParticle, 12.0f);
        Destroy(this.gameObject);
    }
}