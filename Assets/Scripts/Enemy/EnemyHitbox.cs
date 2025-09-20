using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    private BaseEnemy enemy;
    private Character character;
    void Awake()
    {
        enemy = GetComponentInParent<BaseEnemy>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Found player: " + player.name);
        character = player.GetComponentInChildren<Character>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.CompareTag("Attack"))
        {
                
                enemy.EnemyTakeDamage(character.characterPrimaryAttackDamage);
                Debug.Log($"Enemy took {character.characterPrimaryAttackDamage} damage");
            
        }

    }
}
