using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShield : MonoBehaviour
{
    public bool inRange = false;

    public Collider2D currentProjectile;

    public GameObject door_object; //required for reference to player abilities
    public Door door; //required for reference to player abilities



    private void Start()
    {
        door_object = GameObject.FindWithTag("Door"); //required for reference to player abilities
        door = door_object.GetComponent<Door>(); //required for reference to player abilities

    }
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
