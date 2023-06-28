using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;
    public Rigidbody rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.playerHealth = GameManager.playerHealth - damage;
            GameObject poofs = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(poofs, 4.0f);
            Destroy(gameObject);
        }
    }
}
