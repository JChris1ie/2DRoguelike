using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
public class RoundCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public int roomCount = 1;
    public void IncreaceRoomCount()
    {
        roomCount++;
        counterText.text = roomCount.ToString();
    }
}
