using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGame : MonoBehaviour
{
    private GameObject[] floors;
    private GameObject roundCounter;
    public void save() {
        floors=GameObject.FindGameObjectsWithTag("Floor");
        roundCounter=GameObject.FindWithTag("RoundCounter");
        File.WriteAllText("saveGame.csv", (floors[0].ToString(),floors[1].ToString(),floors[2].ToString(),floors[3].ToString(), roundCounter.GetComponent<RoundCounter>().roomCount).ToString());
    }
}
