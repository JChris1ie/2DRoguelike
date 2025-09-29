using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy to Spawn")]
    public BaseEnemy enemy;

    [Header("Spawn Key")]
    public KeyCode spawnKey;

    private void Update()
    {
        TrackInputs();
    }
    private void TrackInputs()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        BaseEnemy newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);

    }
}
