using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EarthSpin : MonoBehaviour
{
    public int rotationSpeed = 5;
    public float rotX = 5;
    public float rotY = 5;
    public float rotZ = 5;

    public Vector3 rotationDirection = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        float ranX = Random.Range(-10, 10);
        rotX = ranX;
        float ranY = Random.Range(-10, 10);
        rotY = ranY;
        float ranZ = Random.Range(-10, 10);
        rotZ = ranZ;
    }

    // Update is called once per frame
    void Update()
    {

        //https://docs.unity3d.com/2018.1/Documentation/ScriptReference/Transform.Rotate.html
        transform.Rotate(Vector3.up * Time.deltaTime * rotX);
        transform.Rotate(Vector3.forward * Time.deltaTime * rotY);
        transform.Rotate(Vector3.right * Time.deltaTime * rotZ);

        //transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);


    }
}
