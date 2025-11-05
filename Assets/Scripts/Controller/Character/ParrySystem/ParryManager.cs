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

    public GameObject door_object; //required for reference to player abilities
    public Door door; //required for reference to player abilities

    void Start()
    {
        parryScript = GetComponentInChildren<Parry>();
        perfectParryScript = GetComponentInChildren<PerfectParry>();

        door_object = GameObject.FindWithTag("Door"); //required for reference to player abilities
        door = door_object.GetComponent<Door>(); //required for reference to player abilities
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
                            if (!door.Has_ability("Perfect_Parry") && !door.Has_ability("Parry")) projScript.Disable();

                            if (door.Has_ability("Perfect_Parry"))
                            {
                                projScript.hasBeenParried = true;
                                projectile.gameObject.tag = "Attack";
                                projScript.playerDirection = -projScript.playerDirection;
                                projScript.projectileDamage = projScript.projectileDamage * perfectParryDamageMultiplier;
                                projScript.speed = projScript.speed * perfectParrySpeedMultiplier;
                            }

                            if (!door.Has_ability("Perfect_Parry") && door.Has_ability("Parry"))
                            {
                                projScript.hasBeenParried = true;
                                projectile.gameObject.tag = "Attack";
                                projScript.playerDirection = -projScript.playerDirection;
                                projScript.projectileDamage = projScript.projectileDamage * parryDamageMultiplier;
                                projScript.speed = projScript.speed * parrySpeedMultiplier;
                            }
                        }
                    }
                    else
                    {
                        if (!projScript.hasBeenParried)
                        {
                            if (door.Has_ability("Parry"))
                            {
                                projScript.hasBeenParried = true;
                                projectile.gameObject.tag = "Attack";
                                projScript.playerDirection = -projScript.playerDirection;
                                projScript.projectileDamage = projScript.projectileDamage * parryDamageMultiplier;
                                projScript.speed = projScript.speed * parrySpeedMultiplier;
                            }

                            else
                            {
                                projScript.Disable();
                            }

                        }
                    }
                }
            }
           
              
        }

    }
}
