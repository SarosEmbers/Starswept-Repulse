using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float maxVelocity = 5;

    public float rotationSpeed = 3;

    #region Monobehavior API

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // These Axis values are not accurate whatsoever lmao
    void FixedUpdate()
    {
        float zAxis = Input.GetAxisRaw("Vertical");
        float xAxis = Input.GetAxisRaw("Horizontal");

        ThrustForward(zAxis);
        Rotate(transform, xAxis * rotationSpeed);
        /*
        if (INPUT CAMO BUTTON)
        {
            camo();
        }
        */
    }

    #endregion

    #region Maneuvering API

    private void ClampVelocity()
    {
        float z = Mathf.Clamp(rb.velocity.z, -maxVelocity, maxVelocity);
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);

        rb.velocity = new Vector3(x, 0.0f, z);

    }

    private void ThrustForward(float amount)
    {
        Vector3 force = transform.forward * maxVelocity * amount;

        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amound)
    {
        t.Rotate(0, amound, 0);
    }
    public void CallRotL()
    {
        float xAxis = 25.0f;
        Rotate(transform, xAxis * rotationSpeed);
    }
    public void CallRotR()
    {
        float xAxis = -25.0f;
        Rotate(transform, xAxis * rotationSpeed);
    }
    #endregion
}
