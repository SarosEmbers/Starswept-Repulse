using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothTurret : MonoBehaviour
{
    public GameObject missile;
    public float missileCooldown = 10.0f;
    public int health = 5;
    void Start()
    {
        
    }

    
    void Update()
    {
        missileCooldown -= 1 * Time.deltaTime;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void missileShoot()
    {
        Instantiate(missile, transform.position, Quaternion.identity);
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("player bullet"))
        {
            health--;
        }
    }
}
