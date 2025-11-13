using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleHitbox : MonoBehaviour
{
    public bool bubbleParries = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bubbleParries)
        {

            if (other.gameObject.CompareTag("EnemyProjectileAttack"))
            {
                EnemyProjectileBehavior projScript = other.GetComponent<EnemyProjectileBehavior>();
                projScript.hasBeenParried = true;
                other.gameObject.tag = "Attack";
                projScript.playerDirection = -projScript.playerDirection;

            }
        }
        else
        {
            if (other.gameObject.CompareTag("EnemyProjectileAttack"))
            {
                EnemyProjectileBehavior projScript = other.GetComponent<EnemyProjectileBehavior>();
                projScript.Disable();
            }
        }

    }
}
