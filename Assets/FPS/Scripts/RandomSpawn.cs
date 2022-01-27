using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2022-01-26
public class RandomSpawn : MonoBehaviour
{
    public GameObject spawner;

    public float xRandom = 0f;
    public float zRandom = 0f;

    public float radius = 0f;
    public float maxSpawn = 1f;
    public static float spawnCounter = 0f;

    //spawn randomly around n radius at the start of the game
    void Start()
    {
        while (spawnCounter < maxSpawn)
        {
            xRandom = Random.Range(1, radius);
            zRandom = Random.Range(1, radius);
            Vector3 randomPos = new Vector3(xRandom, 0.5f, zRandom);
            Instantiate(spawner, randomPos, Quaternion.identity);

            spawnCounter += 1;
        }
    }
}
