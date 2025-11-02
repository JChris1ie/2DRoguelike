using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
public class EnemyAttackRadius : MonoBehaviour
{
    [HideInInspector]
    public bool isPlayerInRange = false;
    private bool isEnemyOnCooldown = false;
    private float attackCooldown;

    private BaseEnemy enemy;
    private Character characterScript;
    void Start()
    {
        enemy = GetComponentInParent<BaseEnemy>();
        attackCooldown = enemy.attackCooldown;
        GameObject character = GameObject.FindWithTag("Player");
        characterScript = character.GetComponent<Character>();
    }
    private void Update()
    {
        if (!isEnemyOnCooldown && isPlayerInRange)
        {
            AttackPlayer();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange= false;
        }
    }
    IEnumerator GoIntoCooldown()
    {
        isEnemyOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        isEnemyOnCooldown = false;
    }
    void AttackPlayer()
    {
        if (characterScript != null)
        { 
            characterScript.PlayerTakeDamage(enemy.enemyPrimaryAttackDamage);
            StartCoroutine(GoIntoCooldown());
        }
    }
}

