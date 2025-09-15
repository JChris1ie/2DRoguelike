using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class BaseEnemy : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float enemyPrimaryAttackDamage = 10;
    public float enemySpeed = 5;

    
   
    public void EnemyTakeDamage(float amount)
    {
        enemyHealth -= amount;
    }
    public void HealEnemyr(float amount)
    {
        enemyHealth += amount;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            Character character = other.gameObject.GetComponent<Character>();
            if (character != null)
            {
                
                character.PlayerTakeDamage(enemyPrimaryAttackDamage);
                Debug.Log($"Player took {enemyPrimaryAttackDamage} damage");
            }
        }
        
    }
}
