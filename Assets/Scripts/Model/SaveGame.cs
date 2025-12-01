using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UIElements;

public class SaveGame : MonoBehaviour
{
    private List<GameObject> floors;
    private GameObject roundCounter;

    List<string> txtLines = new List<string>();
    string filePath = "Assets/Scripts/Model/savedFloors.txt";
    public void saveFloor() {
        StartCoroutine(wait(1));
        floors = GetGameObjectsWithTag("Floor");
        txtLines = new List<string>();
        foreach (GameObject prefab in floors.GetRange(floors.Count - 4, 4))
        {
            string prefabName = prefab.name.Replace("(Clone)", "").Trim();
            string line = $"{prefabName}";
            txtLines.Add(line);
        }
        File.WriteAllText(filePath, string.Empty);
        File.WriteAllLines(filePath, txtLines.ToArray());
        Debug.Log("Prefabs saved to TXT: " + filePath);
    }

    IEnumerator wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    List<GameObject> GetGameObjectsWithTag(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        if (gameObjects.Length == 0)
        {
            return new List<GameObject>();
        }
        return new List<GameObject>(gameObjects);
    }
}
