using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public dropScript DS;
    public int rockBreak = 100;
    public GameObject rockExplode;
    public GameManager GM;

    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
    }

    void Update()
    {

    }

    public void BreakApart(int gamage)
    {
        rockBreak -= gamage;

        Debug.Log(rockBreak);

        if (rockBreak <= 25)
        {

        }
        if (rockBreak <= 0)
        {
            GameObject explode = Instantiate(rockExplode, transform.position, transform.rotation);
            Destroy(explode, 4.0f);

            Die();
        }
    }

    void Die()
    {
        DS.dropItems();
        Destroy(gameObject);

        GM.points = GM.points + 5;
    }
}
