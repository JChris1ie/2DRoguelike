using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackBehavior : MonoBehaviour
{
    public float healAmount = 50f;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character playerStats = collision.gameObject.GetComponent<Character>();
            Debug.Log("Collided with " + collision.gameObject.name);
            if (playerStats != null)
            {
                playerStats.HealPlayer(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
