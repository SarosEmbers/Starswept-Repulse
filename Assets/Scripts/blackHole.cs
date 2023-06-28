using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackHole : MonoBehaviour
{
    public GameObject player;

    public Vector3 distBetween;
    public float distX;
    public float distY;
    public float distZ;
    public float forceX, forceY, forceZ;

    public float grav = 3.0f;

    public float gravityRange = 500.0f;
    public bool inRange = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distBetween = this.gameObject.transform.position - player.transform.position;
        distY = this.gameObject.transform.position.y - player.transform.position.y;
        distX = this.gameObject.transform.position.x - player.transform.position.x;
        distZ = this.gameObject.transform.position.z - player.transform.position.z;
        if (distX <= 0)
        {
            forceX = distX * grav / 1500;
        } else if (distX > 0)
        {
            forceX = -1 * distX * grav /1500;
        }
        if (distY <= 0)
        {
            forceY = distY * grav;
        } else if (forceY > 0)
        {
            forceY = -1 * distY * grav;
        }
        if (distZ <= 0)
        {
            forceZ = distZ * grav / 1500;
        } else if (distZ > 0)
        {
            forceZ = -1 * distZ * grav / 1500;
        }
        if (inRange)
        {
            player.gameObject.GetComponent<Rigidbody>().AddForce(forceX, forceY, forceZ);
        } else if (!inRange)
        {
            player.gameObject.GetComponent<Rigidbody>().AddForce(0.0f, 0.0f, 0.0f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        //half the size of the collider minus the distance between both objects
        inRange = true;   
    }
    public void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.localPosition, gravityRange);
    }
}
