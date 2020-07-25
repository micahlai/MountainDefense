using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 10;
    private float time = 0;
    public Transform[] spawners;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (time >= spawnRate)
        {
            Transform s = spawners[Random.Range(0, spawners.Length)];

            Instantiate(enemy, s.position, s.rotation);
            time = 0;

        }
    }
}
