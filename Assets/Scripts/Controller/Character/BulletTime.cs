using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    [Header("How long they are slowed")]
    public float slowTime = 1;
    private Door door;
    private GameObject doorObj;
    private PlayerMovement moveScript;

    private void Start()
    {
        doorObj = GameObject.FindWithTag("Door");
        door = doorObj.GetComponent<Door>();
        moveScript = gameObject.GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (door.Has_ability("Bullet_Time") && moveScript.isDashing)
        {
            if (other.CompareTag("Octodude") || other.CompareTag("Notpapyrus") || other.CompareTag("Freaker"))
            {
                EnemyMovement enemyMoveScript = other.GetComponent<EnemyMovement>();
                enemyMoveScript.slowDuration = slowTime;
            }
        }

    }

}
