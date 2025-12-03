using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerManager : MonoBehaviour
{
    private Door doorscript;

    private GameObject doorObj;

    public GameObject spawner;

    public int numberOfSpawners;

    public float rangeFromCenter;

    private bool betweenLevels;
    private void Start()
    {
        doorObj = GameObject.FindWithTag("Door");
        doorscript = doorObj.GetComponent<Door>();
        betweenLevels = false;
        SpawnSpawners();
    }

    private void Update()
    {
        if (doorscript.answered == false && betweenLevels == false)
        {
            betweenLevels = true;
        }
        else if (doorscript.answered == true && betweenLevels == true)
        {
            betweenLevels = false;
            numberOfSpawners++;
            SpawnSpawners();
        }
    }
    public void SpawnSpawners()
    {
        for (int i = 0; i < numberOfSpawners; i++)
        {
            Instantiate(spawner, CalculateRandomPosition(), Quaternion.identity);
        }
    }
    public Vector3 CalculateRandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(-rangeFromCenter, rangeFromCenter), Random.Range(-rangeFromCenter, rangeFromCenter), 0f);
        return position;
    }
}
