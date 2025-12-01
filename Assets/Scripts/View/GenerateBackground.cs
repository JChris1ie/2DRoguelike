using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GenerateBackground : MonoBehaviour
{

    // Arrays for storing prefabs of background pieces
    public GameObject[] topRight;
    public GameObject[] topLeft;
    public GameObject[] bottomRight;
    public GameObject[] bottomLeft;

    private string filePath= "Assets/Scripts/Model/savedFloors.txt";
    private GameObject[] checkList;
    private Vector3 position;

    void Awake()
    {
        string fileContents = File.ReadAllText(filePath);
        // Generates scene once program wakes
        if (fileContents!="")
        {
            int counter = 0;
            foreach (string line in fileContents.Split("\n"))
            {
                if (counter== 0)
                {
                    checkList = topRight;
                    position = new Vector3(-5, 5, 1);
                }
                else if (counter== 1)
                {
                    checkList = topLeft;
                    position = new Vector3(5, 5, 1);
                }
                else if (counter == 2)
                {
                    checkList=bottomRight;
                    position = new Vector3(5, -5, 1);
                }
                else if (counter== 3)
                {
                    checkList = bottomLeft;
                    position = new Vector3(-5, -5, 1);
                }
                counter++;
                foreach(GameObject item in checkList)
                {
                    if (item.name == line.Trim()) 
                    {
                        Instantiate(item,position,Quaternion.identity);
                        break;
                    }
                }
            }
        }
        else
        {
            ChangeScene();
        }
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

    private List<GameObject> ConvertToList(GameObject[] list)
    {
        return new List<GameObject>(list);
    }
}
