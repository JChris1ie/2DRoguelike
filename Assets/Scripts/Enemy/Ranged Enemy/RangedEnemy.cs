using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedEnemy : BaseEnemy
{
    public float enemyProjectileSpeed;
    public float enemyProjectileCoolDownTime = 1;

    public GameObject enemyProjectile;
    public GameObject playerObject;
    
    private bool isProjectileOnCoolDown = false;

    private ShootRadius shootRadiusScript;
    private void Start()
    {
        shootRadiusScript = GetComponentInChildren<ShootRadius>();
        playerObject = GameObject.FindWithTag("Player");
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
        Vector2 direction = (playerObject.transform.position - transform.position).normalized;
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
        yield return new WaitForSeconds(enemyProjectileCoolDownTime);
        isProjectileOnCoolDown = false;
    }
}
