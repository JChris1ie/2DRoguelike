using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipper : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && facingRight == false)
        {
            spriteRenderer.flipX = true;
            facingRight = true;
            Debug.Log("flipped");
        }
        if (Input.GetKeyDown(KeyCode.A) && facingRight == true)
        {
            spriteRenderer.flipX = false;
            facingRight = false;
            Debug.Log("flipped");
        }
    }
}
