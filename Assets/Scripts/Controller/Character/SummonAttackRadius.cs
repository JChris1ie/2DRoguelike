using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAttackRadius : MonoBehaviour
{
    [HideInInspector]
    public bool isSummonInRange = false;
    private bool isSummonOnCooldown = false;
    private float attackCooldown;

    private AllySummon summon;
    private GameObject enemyObject;
    private BaseEnemy enemy;
    void Start()
    {
        summon = GetComponentInParent<AllySummon>();
        attackCooldown = summon.attackCooldown;
    }
    private void Update()
    {
        if (summon.enemy)
        {
            enemyObject = summon.enemy;
            enemy = enemyObject.GetComponentInParent<BaseEnemy>();
        }
        
        if (!isSummonOnCooldown && isSummonInRange)
        {
            AttackEnemy();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == enemyObject)
        {
            isSummonInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == enemyObject)
        {
            isSummonInRange = false;
        }
    }
    IEnumerator GoIntoCooldown()
    {
        isSummonOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        isSummonOnCooldown = false;
    }
    void AttackEnemy()
    {
        if (enemy != null)
        {
            enemy.EnemyTakeDamage(summon.attackDamage);
            StartCoroutine(GoIntoCooldown());
        }
    }
}
