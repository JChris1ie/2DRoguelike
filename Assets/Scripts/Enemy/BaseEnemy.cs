using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class BaseEnemy : MonoBehaviour
{
    [Header("Stats")]
    public float enemyHealth = 100f;
    public float enemyPrimaryAttackDamage = 10;

    [Header("Drops")]

    public bool dropHealth = true;
    public GameObject healthDrop;
    
   
    public void EnemyTakeDamage(float amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            KillEnemy();
        }
    }
    public void HealEnemyr(float amount)
    {
        enemyHealth += amount;
    }
    
    private void KillEnemy()
    {
        if (dropHealth)
        {
            Instantiate(healthDrop, transform.position, Quaternion.identity);
        }

        Debug.Log("Enemy has been slain");
        gameObject.SetActive(false);
    }
}
