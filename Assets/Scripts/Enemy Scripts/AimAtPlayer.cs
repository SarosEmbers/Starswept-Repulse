using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayer : MonoBehaviour
{
	public Transform targetToFace;
	public float rotSpeed = 0.1f;

	// Use this for initialization
	void Start()
	{
		//targetToFace = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 playerPos = targetToFace.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(playerPos);
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);

		//Vector2 direction = new Vector2(playerPos.x - transform.position.x, playerPos.z - transform.position.z);
	}

	//This script is currently useless so fear not Eli

}
