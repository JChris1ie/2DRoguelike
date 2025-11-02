using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHitbox : MonoBehaviour
{
    
    private Character playerScript; //The character class script
    void Awake()
    {
        playerScript = GetComponentInParent<Character>(); //Put the class into the player script variable            
    }

    // This fuction tracks if the player has an object labeled with any of the tags listed and decrements the players health by the damage atrigbute of the projectile
    void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.gameObject.CompareTag("EnemyProjectileAttack"))
        {
            EnemyProjectileBehavior projectile = other.gameObject.GetComponent<EnemyProjectileBehavior>();
            float amount = projectile.projectileDamage;
            if (projectile != null)
            {
                playerScript.PlayerTakeDamage(amount);
                Debug.Log($"Player took {amount} damage");
            }
        }
        else if (other.gameObject.CompareTag("EnemyExplosion"))
        {
           
            ExplosionBehavior explosionScript = other.gameObject.GetComponentInParent<ExplosionBehavior>();
            playerScript.PlayerTakeDamage(explosionScript.explosionDamage);
        }

    }
}
