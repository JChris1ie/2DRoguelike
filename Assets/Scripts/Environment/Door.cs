using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{

    public UnityEvent ChangeScene;

    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.CompareTag("Player")) {
            Debug.Log("Change Scene");
            ChangeScene.Invoke();
        }
    }
}
