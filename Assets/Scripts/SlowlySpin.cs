using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlySpin : MonoBehaviour
{
    public int rotationSpeed = 5;
    public Vector3 rotationDirection = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDirection * Time.deltaTime * rotationSpeed);
    }
}
