using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBackground : MonoBehaviour
{

    // Arrays for storing prefabs of background pieces
    public GameObject[] topRight;
    public GameObject[] topLeft;
    public GameObject[] bottomRight;
    public GameObject[] bottomLeft;

    void Awake()
    {
        // Generates scene once program wakes
        ChangeScene();
    }

    public void ChangeScene()
    {
        // Method that can be called at any time to change background environment 
        // Randomly selects 1 quarter of the background at a time, taking 1 piece from each array
        Instantiate(topRight[Random.Range(0,topRight.Length)], new Vector3(-5,5,1), Quaternion.identity);
        Instantiate(topLeft[Random.Range(0,topLeft.Length)], new Vector3(5,5,1), Quaternion.identity);
        Instantiate(bottomRight[Random.Range(0,bottomRight.Length)], new Vector3(5,-5,1), Quaternion.identity);
        Instantiate(bottomLeft[Random.Range(0,bottomLeft.Length)], new Vector3(-5,-5,1), Quaternion.identity);        
    }

}
