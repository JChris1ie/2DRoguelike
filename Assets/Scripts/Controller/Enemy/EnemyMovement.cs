using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    public bool useRangedMovement;
    //public Transform playerPosition;

    public bool moveEnemy = true;

    private ShootRadius shootRadiusScript;
    private EnemyAttackRadius attackRadiusScript;
    private GameObject playerObject;
    public float stunDuration;

    private Rigidbody2D rb;
   
    private void Start()
    {
        shootRadiusScript = GetComponentInChildren<ShootRadius>();
        attackRadiusScript = GetComponentInChildren<EnemyAttackRadius>();
        playerObject = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        if (useRangedMovement)
        {
            if (!shootRadiusScript.isPlayerInRadius)
            {
                MoveEnemy();
            }
        }
        else 
        {
            if (attackRadiusScript is null || !attackRadiusScript.isPlayerInRange)
            {
                MoveEnemy();
            }
        }
   
        
    }
    private void MoveEnemy()
    {
        if (stunDuration > 0)
        {
            stunDuration -= Time.deltaTime;
            return;
        }
        Vector2 targetPos = playerObject.transform.position;
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, enemySpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
