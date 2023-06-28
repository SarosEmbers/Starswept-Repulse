using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBoundsForce : MonoBehaviour
{
    public GameObject SBC;
    public float forceAmount = 1.0f;

    public bool forceToSBC = false;
    public Vector3 forceDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SBC = GameObject.FindGameObjectWithTag("Respawn");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && forceToSBC == true)
        {
            SBC = GameObject.FindGameObjectWithTag("Respawn");

            //Vector3 force = new Vector3(1f, 0f, 0f);
            Vector3 forceToSBC = SBC.transform.position * forceAmount;
            other.GetComponent<Rigidbody>().AddForce(forceToSBC);
        }
        else if (other.tag == "Player" && forceToSBC == false)
        {
            other.GetComponent<Rigidbody>().AddForce(forceDirection * forceAmount);
        }
    }
}
