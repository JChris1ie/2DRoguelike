using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipper : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.D) && facingRight == false && !Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.A) && facingRight == true && !Input.GetKey(KeyCode.D)))
        {
            facingRight = !facingRight;
            spriteRenderer.flipX = facingRight;
        }
    }
}
