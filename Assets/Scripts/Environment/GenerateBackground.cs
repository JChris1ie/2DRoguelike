using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBackground : MonoBehaviour
{

    public GameObject[] mapPieces;

    void Awake()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        // Method that can be called at any time to change background environment 
        Instantiate(mapPieces[Random.Range(0,mapPieces.Length)], new Vector3(-5,5,0),Quaternion.identity);
        Instantiate(mapPieces[Random.Range(0,mapPieces.Length)], new Vector3(5,5,0),Quaternion.identity);
        Instantiate(mapPieces[Random.Range(0,mapPieces.Length)], new Vector3(5,-5,0),Quaternion.identity);
        Instantiate(mapPieces[Random.Range(0,mapPieces.Length)], new Vector3(-5,-5,0),Quaternion.identity);
        
        
    }

}
