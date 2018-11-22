using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    [SerializeField] int totalEnemyCount = 0;
    [SerializeField] int countPerSpawn = 1;
    [SerializeField] Text countText;

    [SerializeField] AudioClip spawnedEnemySFX;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(SpawnEnemies());
        countText.text = "Spawned Enemies: " + totalEnemyCount.ToString();
    }

    IEnumerator SpawnEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(secondBetweenSpawns);

        while (true) // because I want to do this forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondBetweenSpawns);
            EnemyCounter();
            yield return delay;
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
        }
    }

    private void EnemyCounter()
    {
        totalEnemyCount = totalEnemyCount + countPerSpawn;
        countText.text = "Spawned Enemies: " + totalEnemyCount.ToString();
    }
}
