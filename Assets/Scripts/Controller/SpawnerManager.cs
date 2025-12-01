using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerManager : MonoBehaviour
{
    public GameObject spawner;

    public int numberOfSpawners;

    public float rangeFromCenter;
    private void Start()
    {
        SpawnSpawners();
    }
    public void SpawnSpawners()
    {
        for (int i = 0; i < numberOfSpawners; i++)
        {
            spawner = Instantiate(spawner, CalculateRandomPosition(), Quaternion.identity);
        }
    }
    public Vector3 CalculateRandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(-rangeFromCenter, rangeFromCenter), Random.Range(-rangeFromCenter, rangeFromCenter), 0f);
        return position;
    }
}
