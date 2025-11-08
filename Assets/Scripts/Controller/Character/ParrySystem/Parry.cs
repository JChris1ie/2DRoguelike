using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public bool inRange = false;

    public Collider2D currentProjectile;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyProjectileAttack"))
        {
            inRange = true;
            currentProjectile = other;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyProjectileAttack") || other.gameObject.CompareTag("Attack"))
        {
            inRange = false;
            currentProjectile = null;
        }
    }
    public Collider2D GetCurrentProjectile()
    {
        return currentProjectile; 
    }
}
