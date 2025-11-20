using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyHitbox : MonoBehaviour
{
    private BaseEnemy enemy;
    private Character character;

    private EnemyProjectileBehavior projectileScript;
    private ExplosionBehavior explosionScript;

    private Door door;
    private GameObject door_obj;

    private GameObject sword;
    private MeleeWeaponBehavior swordScript;

    private float angle;

    private Rigidbody2D rigidBody;

    private EnemyMovement movementScript;
    void Awake()
    {
        enemy = GetComponentInParent<BaseEnemy>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        character = player.GetComponentInChildren<Character>();
        door_obj = GameObject.FindWithTag("Door");
        door = door_obj.GetComponent<Door>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (door.Has_ability("Blunt_Edge"))
        {
            sword = GameObject.FindWithTag("Sword");
            if (sword)
            {
                swordScript = sword.GetComponent<MeleeWeaponBehavior>();
                angle = swordScript.angle;
                rigidBody = gameObject.GetComponentInParent<Rigidbody2D>();
                rigidBody.velocity = new Vector2(Mathf.Cos(angle)*4, Mathf.Sin(angle)*4);
                movementScript = gameObject.GetComponentInParent<EnemyMovement>();
                movementScript.stunDuration = 0.15f;
            }
        }

        if (other.gameObject.CompareTag("Attack"))
        {
            projectileScript = other.gameObject.GetComponent<EnemyProjectileBehavior>();
            if (projectileScript != null)
            {
                enemy.EnemyTakeDamage(projectileScript.projectileDamage);
                Debug.Log($"Enemy took {projectileScript.projectileDamage} damage");
            }
            else
            {
                enemy.EnemyTakeDamage(character.characterPrimaryAttackDamage);
                Debug.Log($"Enemy took {character.characterPrimaryAttackDamage} damage");
            }           
            
        }
        else if (other.gameObject.CompareTag("PlayerExplosion"))
        {
            explosionScript = other.gameObject.GetComponentInParent<ExplosionBehavior>();
            enemy.EnemyTakeDamage(explosionScript.explosionDamage);
        }
    }
}
