using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;

    public int howManyToSpawn = 500;

    public List<GameObject> asteroidsList = new List<GameObject>
    {

    };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= howManyToSpawn; i++)
        {
            SpawnItem();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnItem()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(asteroidsList[Random.Range(0,asteroidsList.Count)], pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.localPosition, size);
    }
}
