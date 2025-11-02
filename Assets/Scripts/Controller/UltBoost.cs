using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltBoost : MonoBehaviour
{
    
    
    public float percentageGained = 50f;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character playerStats = collision.gameObject.GetComponent<Character>();
            Debug.Log("Collided with " + collision.gameObject.name);
            if (playerStats != null)
            {
                playerStats.GivePlayerUltCharge(percentageGained);
                Destroy(gameObject);
            }
        }
    }
    
}
