using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedEnemy : BaseEnemy
{
    public float enemyProjectileSpeed;
    

    public GameObject enemyProjectile;
    
    
    private bool isProjectileOnCoolDown = false;

    
    private ShootRadius shootRadiusScript;
    protected override void Start()
    {
        base.Start();
        shootRadiusScript = GetComponentInChildren<ShootRadius>();
        
    }
    private void Update()
    {
        if (shootRadiusScript != null)
        {
            if (!isProjectileOnCoolDown && shootRadiusScript.isPlayerInRadius)
            {
                ShootAtPlayer();
            }
        }
        else
        {
            if (!isProjectileOnCoolDown)
            {
                ShootAtPlayer();
            }
        }
    }
    private void ShootAtPlayer()
    {
        Vector2 direction = (characterObject.transform.position - transform.position).normalized;
        GameObject newProjectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
        var projBehavior = newProjectile.GetComponent<EnemyProjectileBehavior>();
        if (projBehavior != null)
        {
            projBehavior.enemyObject = gameObject;
            projBehavior.playerDirection = direction;
            projBehavior.speed = enemyProjectileSpeed;
        }
        StartCoroutine(PutEnemyProjectileOnCoolDown());

    }
    IEnumerator PutEnemyProjectileOnCoolDown()
    {
        isProjectileOnCoolDown = true;
        yield return new WaitForSeconds(attackCooldown);
        isProjectileOnCoolDown = false;
    }
}
