using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawnerBehavior : MonoBehaviour
{
    [Header("List of enemies")]
    public List<GameObject> enemies;

    [Header("Round Multiplier for enemy Stats")]
    public float multiplier = 1;

    [Header("Wave Info")]
    public float wave = 1;

    public float firstWaveTime = 10;
    public float secondWaveTime = 20;
    public float thirdWaveTime = 30;

    public int firstWaveEnemies = 1;
    public int secondWaveEnemies = 1;
    public int thirdWaveEnemies = 1;

    private int currentEnemyNumber;
    private void SpawnAllEnemies()
    { 
        foreach (GameObject enemy in enemies)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            GiveEnemyMultiplier(enemy);
        }
        
    }
    private void SpawnRandomEnemy()
    {
        int r = Random.Range(0,enemies.Count);
        GameObject enemy = enemies[r];
        Instantiate(enemy, transform.position, Quaternion.identity);
        GiveEnemyMultiplier(enemy);
    }
    private void SpawnNextEnemy()
    {
        GameObject enemy = enemies[currentEnemyNumber];
        Instantiate(enemy, transform.position, Quaternion.identity);
        GiveEnemyMultiplier(enemy);
        currentEnemyNumber += 1;
        if (currentEnemyNumber >= enemies.Count)
        {
            currentEnemyNumber = 0;
        }
    }
    private void SpawnEnemies(int amount, bool isRandom)
    {
        for (int i = 0; i < amount; i++)
        {
            if (isRandom)
            {
                SpawnRandomEnemy();
            }
            else
            {
                SpawnNextEnemy();
            }
                
        }
    }
    private void GiveEnemyMultiplier(GameObject enemy)
    {
            enemy.GetComponent<BaseEnemy>().Updatedamage(multiplier);
    }
    // All waves here
    private void Start()
    {
        StartCoroutine(BeginFirstWave());
    }
    IEnumerator BeginFirstWave()
    {
        SpawnEnemies(1, false);
        yield return new WaitForSeconds(firstWaveTime);
        StartCoroutine(BeginSecondWave());
    }
    IEnumerator BeginSecondWave()
    {
        SpawnEnemies(1, true);
        yield return new WaitForSeconds(secondWaveTime);
        StartCoroutine(BeginThirdWave());
    }
    IEnumerator BeginThirdWave()
    {
        SpawnEnemies(1, false);
        yield return new WaitForSeconds(thirdWaveTime);
        Destroy(gameObject);
    }
}
