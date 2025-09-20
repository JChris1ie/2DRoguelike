using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRadius : MonoBehaviour
{
    private BaseEnemy enemy;
    void Start()
    {
        enemy = GetComponentInParent<BaseEnemy>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Character character = other.gameObject.GetComponent<Character>();
            if (character != null)
            {

                character.PlayerTakeDamage(enemy.enemyPrimaryAttackDamage);
                Debug.Log($"Player took {enemy.enemyPrimaryAttackDamage} damage");
            }
        }

    }
}
