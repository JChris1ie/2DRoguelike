using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectilebehavior : MonoBehaviour
{
    public GameObject wielder; 
    [SerializeField] private float minRadius; 
    [SerializeField] private bool allowExtend = true;

    public ProjectileCharacter projectileCharacter;
    private Vector2 dir;
    private Vector2 movement;

    private void Update()
    { 
            MoveProjectile();      
    }
    public void LaunchProjectile()
    {
        if (wielder == null) return; 

        
        Vector3 mouseWorld = Camera.main != null
            ? Camera.main.ScreenToWorldPoint(Input.mousePosition)
            : wielder.transform.position + Vector3.right;

        mouseWorld.z = wielder.transform.position.z;

        Vector2 offset = mouseWorld - wielder.transform.position;
        float dist = offset.magnitude;

       
        dir = dist > 0.0001f ? offset / dist : Vector2.right;

        float placeDist = allowExtend ? Mathf.Max(minRadius, dist) : minRadius;
        transform.position = (Vector3)(dir * placeDist) + wielder.transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        
    }
    private void MoveProjectile()
    {
        movement = new Vector2(dir.x, dir.y).normalized * projectileCharacter.projectileSpeed * Time.deltaTime; 
        transform.position = (Vector2)transform.position + movement;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // anything that the projectile should colide with aka basically anything pyshical
        {
            
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Wall")) // added by Jeb
        {
            Destroy(gameObject);
        }
            
    }
}
