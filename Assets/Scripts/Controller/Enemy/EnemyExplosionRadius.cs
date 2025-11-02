using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionRadius : MonoBehaviour
{
    [Header("Explosion Prefab")]
    public GameObject explosion;

    private BaseEnemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<BaseEnemy>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            enemy.DeleteEnemy();
        }
    }

}
