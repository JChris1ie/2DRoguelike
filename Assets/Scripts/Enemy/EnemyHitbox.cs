using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    private BaseEnemy enemy;
    private Character character;

    private EnemyProjectileBehavior projectileScript;
    private ExplosionBehavior explosionScript;
    void Awake()
    {
        enemy = GetComponentInParent<BaseEnemy>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        character = player.GetComponentInChildren<Character>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.CompareTag("Attack"))
        {
            projectileScript = other.gameObject.GetComponent<EnemyProjectileBehavior>();
            if (projectileScript != null)
            {
                enemy.EnemyTakeDamage(projectileScript.projectileDamage);
                Debug.Log($"Enemy took {projectileScript.projectileDamage} damage");
            }
            else
            {
                enemy.EnemyTakeDamage(character.characterPrimaryAttackDamage);
                Debug.Log($"Enemy took {character.characterPrimaryAttackDamage} damage");
            }
                
            
        }
        else if (other.gameObject.CompareTag("PlayerExplosion"))
        {
            explosionScript = other.gameObject.GetComponentInParent<ExplosionBehavior>();
            enemy.EnemyTakeDamage(explosionScript.explosionDamage);
        }
    }
}
