using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{

    //Array of objects to spawn (note I've removed the private goods variable)
    public GameObject[] theGoodies;

    //Time it takes to spawn theGoodies
    [Space(3)]
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;

    // the range of X
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    // the range of y
    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;

    bool start = false;

    void Start()
    {
    }

    public void Update()
    {
        // timer to spawn the next goodie Object
        /*
            theCountdown -= Time.deltaTime;
            if (theCountdown <= 0)
            {
                SpawnGoodies();
                theCountdown = waitingForNextSpawn;

        }
        */
    }


    public void SpawnGoodies()
    {
        // Defines the min and max ranges for x and y
        float tempNum = Random.Range(xMin, xMax);
        float roundNum = Mathf.Sign(tempNum) * (Mathf.Abs((int)tempNum) + 0.5f);
        Vector2 pos = new Vector2(roundNum, Random.Range(yMin, yMax));

        // Choose a new goods to spawn from the array (note I specifically call it a 'prefab' to avoid confusing myself!)
        GameObject goodsPrefab = theGoodies[Random.Range(0, theGoodies.Length)];

        // Creates the random object at the random 2D position.
        Instantiate(goodsPrefab, pos, transform.rotation);
        PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") + 1);

        // If I wanted to get the result of instantiate and fiddle with it, I might do this instead:
        //GameObject newGoods = (GameObject)Instantiate(goodsPrefab, pos)
        //newgoods.something = somethingelse;
    }
}
