using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public GameObject wielder; 
    public float minRadius; 
    public bool allowExtend = true;

    private Vector3 baseScale;

    private GameObject sprite;

    public GameObject door_object; //required for reference to player abilities
    public Door door; //required for reference to player abilities

    private void Start()
    {
        door_object = GameObject.FindWithTag("Door"); //required for reference to player abilities
        door = door_object.GetComponent<Door>(); //required for reference to player abilities
        sprite = GameObject.FindWithTag("Bubble");
        sprite.SetActive(false);
        if (door.Has_ability("Bubble_Shield")) sprite.SetActive(true);
    }

    private void Awake()
    {
        baseScale = transform.localScale;
        if (baseScale == Vector3.zero)
            baseScale = Vector3.one; 
        baseScale = new Vector3(
            Mathf.Abs(baseScale.x),
            Mathf.Abs(baseScale.y),
            Mathf.Abs(baseScale.z)
        );
    }
    public void SetShieldRotation()
    {
        if (Camera.main == null || wielder == null) return;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = wielder.transform.position.z;

        Vector2 offset = mouseWorld - wielder.transform.position;
        float dist = offset.magnitude;

        Vector2 dir = dist > 0.0001f ? offset / dist : (Vector2)transform.right;

        float placeDist = allowExtend ? Mathf.Max(minRadius, dist) : minRadius;
        transform.position = (Vector3)(dir * placeDist) + wielder.transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        
        if (dir.x < 0)
            transform.localScale = new Vector3(baseScale.x, -baseScale.y, baseScale.z);
        else
            transform.localScale = baseScale;
    }
}
