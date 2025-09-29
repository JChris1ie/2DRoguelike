using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRadius : MonoBehaviour
{
    public bool isPlayerInRadius = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ENEMY PLAYER IS WITHING RANGE");
            isPlayerInRadius=true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ENEMY PLAYER IS OUT OF RANGE");
            isPlayerInRadius = false;
        }
        
    }
}
