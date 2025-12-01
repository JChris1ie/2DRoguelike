using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concussive : MonoBehaviour
{
    private Door door;
    private GameObject doorObj;
    private PlayerMovement moveScript;
    private EnemyMovement enemyMoveScript;
    private BaseEnemy enemy;
    public float damageAmt;
    public float concussTime;

    // Start is called before the first frame update
    void Start()
    {
        doorObj = GameObject.FindWithTag("Door");
        door = doorObj.GetComponent<Door>();
        moveScript = gameObject.GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (door.Has_ability("Concussive") && moveScript.isDashing)
        {
            if (other.CompareTag("Octodude") || other.CompareTag("Notpapyrus") || other.CompareTag("Freaker"))
            {
                EnemyMovement enemyMoveScript = other.GetComponent<EnemyMovement>();
                enemyMoveScript.concussDuration = concussTime;
                enemy = other.GetComponentInParent<BaseEnemy>();
                enemy.EnemyTakeDamage(damageAmt);
                moveScript.EndDash();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (moveScript.isDashing)
        {
            if (other.CompareTag("Octodude") || other.CompareTag("Notpapyrus") || other.CompareTag("Freaker"))
            {
                EnemyMovement enemyMoveScript = other.GetComponent<EnemyMovement>();
                enemyMoveScript.rb.velocity = new Vector2(0, 0);
            }
        }
    }
}
