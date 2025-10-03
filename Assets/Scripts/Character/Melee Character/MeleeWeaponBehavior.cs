using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeWeaponBehavior : MonoBehaviour
{
    public GameObject wielder; // Tie this to the melee character who is weilding the weapon
    public float minRadius; // Radius at which the weapon is from the player
    public bool allowExtend = true;

    public MeleeCharacter meleeCharacter;

    bool prevState;

    private Vector3 baseScale;

    private float baseRotationZ;
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

        baseRotationZ = transform.eulerAngles.z;
    }

    public void SetMeleeRotation()
    {
        if (Camera.main == null || wielder == null) return;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = wielder.transform.position.z;
        Vector2 offset = mouseWorld - wielder.transform.position;
        float dist = offset.magnitude;
        Vector2 dir = dist > 0.0001f ? offset / dist : Vector2.right;
        float placeDist = allowExtend ? Mathf.Max(minRadius, dist) : minRadius;
        transform.position = (Vector3)(dir * placeDist) + wielder.transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (dir.x < 0)
        {
           
            transform.localScale = new Vector3(baseScale.x, -baseScale.y, baseScale.z);
            transform.rotation = Quaternion.Euler(0f, 0f, angle - baseRotationZ);
        }
        else
        {
            
            transform.localScale = baseScale;
            transform.rotation = Quaternion.Euler(0f, 0f, angle + baseRotationZ);
        }
    }


} 