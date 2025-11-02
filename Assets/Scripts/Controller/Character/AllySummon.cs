using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class AllySummon : MonoBehaviour
{
   
    public float movementSpeed;
    public float attackCooldown;
    public float attackDamage;

    //public Transform playerPosition;

    public bool moveEnemy = true;

    private SummonAttackRadius attackRadiusScript;
    private GameObject summonObject;
    public GameObject enemy;

    private Rigidbody2D rb;

    private void Start()
    {
        attackRadiusScript = GetComponentInChildren<SummonAttackRadius>();
        enemy = GameObject.FindWithTag("Enemy");
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        if (!enemy)
        {
            enemy = GameObject.FindWithTag("Enemy");
        }
        if (attackRadiusScript is null || !attackRadiusScript.isSummonInRange)
        {
            if (enemy)
            {
                MoveSummon();
            }
        }
            

    }
    private void MoveSummon()
    {
        Vector2 targetPos = enemy.transform.position;
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
            
    }
    

}
