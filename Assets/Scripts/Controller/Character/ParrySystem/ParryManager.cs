using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ParryManager : MonoBehaviour
{
    [Header("Parry Multipliers")]
    public float parrySpeedMultiplier = 1.5f;
    public float parryDamageMultiplier = 1.5f;

    [Header("Perfect Parry Multipliers")]
    public float perfectParrySpeedMultiplier = 2.0f;
    public float perfectParryDamageMultiplier = 2.0f;

    private Parry parryScript;
    private PerfectParry perfectParryScript;


    void Start()
    {
        parryScript = GetComponentInChildren<Parry>();
        perfectParryScript = GetComponentInChildren<PerfectParry>();
    }

    
    void Update()
    {
        if (parryScript.inRange) 
        {
            Collider2D projectile = parryScript.GetCurrentProjectile();
            
            if (projectile != null)
            {
                EnemyProjectileBehavior projScript = projectile.GetComponent<EnemyProjectileBehavior>();
                if (projScript != null)
                {
                    if (perfectParryScript.inRange)
                    {

                        if (!projScript.hasBeenParried)
                        {
                            projScript.hasBeenParried = true;
                            projectile.gameObject.tag = "Attack";
                            projScript.playerDirection = -projScript.playerDirection;
                            projScript.projectileDamage = projScript.projectileDamage * perfectParryDamageMultiplier;
                            projScript.speed = projScript.speed * perfectParrySpeedMultiplier;
                        }
                    }
                    else
                    {
                        if (!projScript.hasBeenParried)
                        {
                            projScript.hasBeenParried = true;
                            projectile.gameObject.tag = "Attack";
                            projScript.playerDirection = -projScript.playerDirection;
                            projScript.projectileDamage = projScript.projectileDamage * parryDamageMultiplier;
                            projScript.speed = projScript.speed * parrySpeedMultiplier;

                        }
                    }
                }
            }
           
              
        }

    }
}
