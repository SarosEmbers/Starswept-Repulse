using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour
{
    public GameManager GM;

    public float AttackZone = 20.0f;
    public GameObject TargetSpotted;

    public Transform firingPoint;
    public GameObject enemBullet;
    public bool attackingPlayer = false;
    public bool attackThePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        findTarget();
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = TargetSpotted.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;

        if (distanceToTarget <= AttackZone)
        {
            if (!attackThePlayer)
            {
                Debug.Log(distanceToTarget);

                DoTheFire();
                attackThePlayer = true;
            }
        }
        else if (distanceToTarget >= AttackZone)
        {
            //Debug.Log("Disengage");

            CancelInvoke();
            attackThePlayer = false;
        }
    }

    private void DoTheFire()
    {
        InvokeRepeating("FireAtWill", 2.0f, 1.0f);
    }

    private void FireAtWill()
    {
        GameObject enemmyBullet = Instantiate(enemBullet, firingPoint.position, firingPoint.rotation);
        Destroy(enemmyBullet, 2.5f);
    }
    public void findTarget()
    {
        TargetSpotted = GameObject.FindGameObjectWithTag("Player");
    }
}
