using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject PlayerMagnetTo;

    private Rigidbody itemBod;
    public float MagnetRange = 8.0f;

    public GameManager GM;
    public enum pickupType
    {
        Scrap,
        Mineral,
        ArchaicTech
    }
    public pickupType ItemToPickUp = pickupType.Mineral;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        PlayerMagnetTo = GameObject.FindGameObjectWithTag("Player");
        itemBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = PlayerMagnetTo.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;

        if (distanceToTarget <= MagnetRange)
        {
            Vector3 force = vectorToTarget * 3.0f;

            itemBod.AddForce(force);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ItemToPickUp == pickupType.Scrap)
            {
                GM.invScrap++;
            }
            if (ItemToPickUp == pickupType.Mineral)
            {
                GM.invMineral++;
            }
            if (ItemToPickUp == pickupType.ArchaicTech)
            {
                GM.invTech++;
            }
            Destroy(gameObject);
        }
    }
}
