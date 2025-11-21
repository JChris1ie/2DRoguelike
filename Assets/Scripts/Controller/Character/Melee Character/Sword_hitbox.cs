using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_hitbox : MonoBehaviour
{
    public GameObject door_object; //required for reference to player abilities
    public Door door; //required for reference to player abilities

    private void Start()
    {
        door_object = GameObject.FindWithTag("Door"); //required for reference to player abilities
        door = door_object.GetComponent<Door>(); //required for reference to player abilities
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyProjectileAttack") && door.Has_ability("Home_Run"))
        {
            EnemyProjectileBehavior projScript = other.GetComponent<EnemyProjectileBehavior>();
            projScript.hasBeenParried = true;
            other.gameObject.tag = "Attack";
            projScript.playerDirection *= -1;
        }
    }
}
