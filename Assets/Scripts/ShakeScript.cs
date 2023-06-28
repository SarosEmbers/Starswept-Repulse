using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour {

    float CurrentShakeMagnitude;
    float ShakeSecondsRemaining;
    Vector3 PositionAtStartOfShake;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ShakeSecondsRemaining > 0.0f)
        {
            Vector2 cameraOffset = Random.insideUnitCircle * CurrentShakeMagnitude;
            transform.localPosition = new Vector3(
                transform.localPosition.x + cameraOffset.x,
                transform.localPosition.y,
                transform.localPosition.z + cameraOffset.y
                );

            ShakeSecondsRemaining -= Time.deltaTime;
            if(ShakeSecondsRemaining <= 0.0f)
            {
                ShakeSecondsRemaining = 0.0f;
                transform.localPosition = PositionAtStartOfShake;
            }
        }
	}

    public void Shake(float shakeSeconds, float shakeMagnitude)
    {
        ShakeSecondsRemaining = shakeSeconds;
        CurrentShakeMagnitude = shakeMagnitude;
        PositionAtStartOfShake = transform.localPosition;
    }

    public bool IsShaking()
    {
        return ShakeSecondsRemaining > 0.0f;
    }
}
