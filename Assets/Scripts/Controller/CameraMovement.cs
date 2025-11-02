using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    

    void Update()
    {
        transform.position = new Vector3(
            playerTransform.position.x,
            playerTransform.position.y,
            transform.position.z
        );

    }
}
