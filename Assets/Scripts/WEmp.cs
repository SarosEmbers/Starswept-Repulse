using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEmp : MonoBehaviour
{
    public GameObject player;

    public float EMPRange = 25.0f;
    public float EMPTimer = 0;
    public float EMPMaxCooldown = 10.0f;
    public GameObject EMPParticle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (EMPTimer >= 0.0f)
        {
            EMPTimer -= 1 * Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (EMPTimer < 0.0f)
            {
                EMP();
            }
        }
    }

    public void callEMP()
    {
        if (EMPTimer < 0.0f)
        {
            EMP();
        }
    }

    void EMP()
    {
        Debug.Log("Not today.");

        GameObject burstEffect = Instantiate(EMPParticle, transform.position, Quaternion.identity);
        Destroy(burstEffect, 2.3f);

        GameObject[] unluckyEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in unluckyEnemy)
        {
            Vector3 vectorToTarget = enemy.transform.position - transform.position;
            float distanceToTarget = vectorToTarget.magnitude;

            if (distanceToTarget <= EMPRange)
            {
                enemy.SendMessage("RandRotate");
            }
        }

        EMPTimer = EMPMaxCooldown;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(player.transform.localPosition, EMPRange);
    }
}
