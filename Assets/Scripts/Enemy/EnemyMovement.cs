using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    public Transform playerPosition;



   
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, enemySpeed * Time.deltaTime);
    }
}
