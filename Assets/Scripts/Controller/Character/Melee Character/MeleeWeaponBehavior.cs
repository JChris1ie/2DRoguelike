using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeWeaponBehavior : MonoBehaviour
{
    private GameObject player;
    public float angle;
    private float distance;
    private float radius;
    private Vector3 diffInPosition;
    private float duration;
    private float prevAngle;
    private Door door;
    private GameObject door_object;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        door_object = GameObject.FindWithTag("Door");
        duration = 0.25f;
        radius = 1.5f;

        door = door_object.GetComponent<Door>();
        if (door.Has_ability("Longsword"))
        {
            gameObject.transform.localScale = new Vector3(0.2f * Mathf.Sqrt(2), 0.2f * Mathf.Sqrt(2), 0.4f);
            radius *= 1.25f;
        }

        if (door.Has_ability("Hack_and_Slash")) duration = 0.125f;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diffInPosition = mousePos - player.transform.position; //calculate vector spanning between player and mouse
        diffInPosition = diffInPosition/diffInPosition.magnitude; //turn vector into unit vector (magnitude is 1)
        if (diffInPosition.x >= 0) angle = Mathf.Atan(diffInPosition.y / diffInPosition.x); //if vector is in quadrants 1 or 4, arctan works as normal
        else angle = Mathf.Atan(diffInPosition.y / diffInPosition.x) + Mathf.PI; //if vector is in quadrants 2 or 3, arctan gives values on the wrong side -> account for this by adding pi
        angle -= Mathf.PI / 4;  //start swing 45 degrees clockwise
        gameObject.transform.position = player.transform.position + new Vector3(Mathf.Cos(angle),Mathf.Sin(angle)) * radius; //calculate desired position for sword based on player position, angle, and radius
        gameObject.transform.Rotate(0,0, angle*180/Mathf.PI); //calculate desired starting rotation for sword using just the angle
    }

    private void Update()
    {
        prevAngle = angle;
        angle += Mathf.PI/2/duration* Time.deltaTime; //increase the angle of the swing by a function of the duration, the total distance and the amt of time passed between frames
        gameObject.transform.position = player.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius; //calculate new desired position from scratch based on the same factors as in start
        gameObject.transform.Rotate(0, 0, (angle-prevAngle) * 180 / Mathf.PI);  //adjust angle based on the difference in time between current fram and previous frame
    }
}

/*{
    public GameObject wielder; // Tie this to the melee character who is weilding the weapon
    public float minRadius; // Radius at which the weapon is from the player
    public bool allowExtend = true;

    public MeleeCharacter meleeCharacter;

    bool prevState;

    private Vector3 baseScale;

    private float baseRotationZ;

    float angle;
    float placeDist;
    float dist;
    float new_angle;
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

    private void Start()
    {
        wielder = GameObject.FindWithTag("Player");
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = wielder.transform.position.z;
        Vector2 offset = mouseWorld - wielder.transform.position;
        dist = offset.magnitude;
        Vector2 dir = dist > 0.0001f ? offset / dist : Vector2.right;
        //dir = new Vector2(Mathf.Cos(Mathf.Acos(dir.x) - Mathf.PI / 4), Mathf.Sin(Mathf.Asin(dir.x) - Mathf.PI / 4));
        placeDist = allowExtend ? Mathf.Max(minRadius, dist) : minRadius;
        transform.position = (Vector3)(dir * placeDist) + wielder.transform.position;

        angle = (-Mathf.PI / 4 + Mathf.Atan2(dir.y, dir.x)) * Mathf.Rad2Deg;
        angle = (Mathf.Atan2(dir.y, dir.x)) *Mathf.Rad2Deg;

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
        gameObject.transform.RotateAround(wielder.transform.position, new Vector3(0,0,1), -Mathf.PI / 4);

    }

    private void Update()
    {
        new_angle = angle - Time.deltaTime * Mathf.PI / 0.5f;
        gameObject.transform.Rotate(0, 0, Mathf.PI / 2 *Mathf.Rad2Deg * Time.deltaTime/0.25f);
        //Vector3 newPosition = new Vector3(minRadius * (Mathf.Sin(new_angle)-Mathf.Sin(angle)) + transform.position.x, minRadius * (Mathf.Cos(new_angle) - Mathf.Cos(angle)) + transform.position.y, transform.position.z);
        //gameObject.transform.position = newPosition;
        angle = new_angle;
    }

    public void SetMeleeRotation()
    {
        if (Camera.main == null || wielder == null) return;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = wielder.transform.position.z;
        Vector2 offset = mouseWorld - wielder.transform.position;
        dist = offset.magnitude;
        Vector2 dir = dist > 0.0001f ? offset / dist : Vector2.right;
        //dir = new Vector2 ();
        placeDist = allowExtend ? Mathf.Max(minRadius, dist) : minRadius;
        transform.position = (Vector3)(dir * placeDist) + wielder.transform.position;

        angle = (-Mathf.PI/4 + Mathf.Atan2(dir.y, dir.x)) * Mathf.Rad2Deg;

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
        gameObject.transform.RotateAround(wielder.transform.position, new Vector3(0, 0, 1), -Mathf.PI / 4);
    } 


} */