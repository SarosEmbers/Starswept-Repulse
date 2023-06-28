using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WDash : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;

    public float dashStrength = 25.0f;
    public float dashTimer = 0;
    public float dashMaxCooldown = 3.5f;
    public GameObject dashParticle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (dashTimer >= 0.0f)
        {
            dashTimer -= 1 * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (dashTimer <= 0.0f)
            {
                Dash();
            }
        }
    }

    public void callDash()
    {
        if (dashTimer <= 0.0f)
        {
            Dash();
        }
    }

    void Dash()
    {
        Debug.Log("W O O S H");

        Vector3 force = transform.forward * dashStrength;

        rb.AddForce(force);

        Invoke("slowDown", 0.4f);
    }

    public void slowDown()
    {
        float z = Mathf.Clamp(rb.velocity.z, -5, 5);
        float x = Mathf.Clamp(rb.velocity.x, -5, 5);

        rb.velocity = new Vector3(x, 0.0f, z);
        //rb.velocity =
        dashTimer = dashMaxCooldown;
    }
}
