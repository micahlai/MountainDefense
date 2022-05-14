﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 10;
    private float time = 100;
    public Transform[] spawners;
    public bool canSpawn = true;
    public scoreManager score;

    [Header("Spawning Characteristics")]
    public Color normalColor;
    public Color fastColor;
    public float maxSpeed = 1.3f;
    public float maxScaleFactor = 1.5f;
    public float normalScale = 2;


    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    private void Update()
    {
        
        
    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            
                float secondsInBetween = 0;
                if(score != null)
                {
                    secondsInBetween = 1 / (Mathf.Log10((score.scoreNum + 100) / 100) * 50 + 1);
                }
                else
                {
                    secondsInBetween = 0.2f;
                }
                
            if (canSpawn && !GameObject.Find("Rain").GetComponent<startStopParticle>().isRunning)
            {
                SpawnEnemy();
            }
                yield return new WaitForSeconds(secondsInBetween);
            

        }
        yield return null;
    }

    public void SpawnEnemyOnPoint(int spawnPoint)
    {
        Transform s = spawners[spawnPoint];

        GameObject enemyObject = Instantiate(enemy, s.position, s.rotation);
        AI enemyAI = enemyObject.GetComponent<AI>();

        float speed = Random.Range(0f, 1f);
        enemyObject.GetComponent<Renderer>().material.color = Color.Lerp(normalColor, fastColor, speed);
        enemyAI.speedMultiplier = Mathf.Lerp(1, maxSpeed, speed);

        float size = Random.Range(0f, 1f);
        float sizeScale = Mathf.Lerp(1, maxScaleFactor, size);
        enemyObject.transform.localScale = new Vector3(normalScale * sizeScale, normalScale * sizeScale, normalScale * sizeScale);
    }
    public void SpawnEnemy()
    {
        SpawnEnemyOnPoint(Random.Range(0, spawners.Length));
    }
}
