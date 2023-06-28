using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingText : MonoBehaviour
{
    public Vector3 scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.Translate(scrollSpeed);
    }
}
