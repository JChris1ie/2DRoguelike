using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehavior : MonoBehaviour
{
   
    public GameObject enemyObject; 
    private RangedEnemy enemyStats;
    public float projectileDamage;

    public bool hasBeenParried = false;
    public Vector2 playerDirection;
    public float speed;
    void Start()
    {
        enemyStats = enemyObject.GetComponent<RangedEnemy>();
        projectileDamage = enemyStats.enemyPrimaryAttackDamage;
    }
    void Update()
    {
        transform.position += (Vector3)playerDirection * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // add walls later on
        {
            Destroy(gameObject);
        }

    }
}

