using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfFarAway : MonoBehaviour
{
    private GameObject ItemActivarotObject;
    private AsteroidActivator activationScript;

    // Start is called before the first frame update
    void Start()
    {
        ItemActivarotObject = GameObject.Find("ItemActivarorObject");
        activationScript = ItemActivarotObject.GetComponent<AsteroidActivator>();

        activationScript.activatorItems.Add(new ActivatorItem { asteroid = this.gameObject, itemPos = transform.position });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
