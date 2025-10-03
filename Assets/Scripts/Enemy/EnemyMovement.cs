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
   
    private void Start()
    {
        shootRadiusScript = GetComponentInChildren<ShootRadius>();
        attackRadiusScript = GetComponentInChildren<EnemyAttackRadius>();
        playerObject = GameObject.FindWithTag("Player");
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
            if (!attackRadiusScript.isPlayerInRange)
            {
                MoveEnemy();
            }
        }
        
        
    }
    private void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, enemySpeed * Time.deltaTime);
    }
}
