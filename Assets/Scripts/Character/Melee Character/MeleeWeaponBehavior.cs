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
    
    public void SetMeleeRotation()
    {
        if (Camera.main == null || wielder == null) return; //Safety check to make sure there is a wielder


        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); // checks where the mouse is in the world and saves it's position
        mouseWorld.z = wielder.transform.position.z;

        Vector2 offset = mouseWorld - wielder.transform.position; // direction vector from weilder to mouse
        float dist = offset.magnitude; // how far mouse is from wielder

        Vector2 dir;
        if (dist > 0.0001f) dir = offset / dist; // if the mouse is on the player it defaults to the wielders right direction
        else dir = transform.right;

        float placeDist = allowExtend ? Mathf.Max(minRadius, dist) : minRadius; //If the weapon can extend, it goes out but stays within the minimum distance

        transform.position = (Vector3)(dir * placeDist) + wielder.transform.position; //Moves weapon to player's position

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //Converts the directions to degrees
        transform.rotation = Quaternion.Euler(0f, 0f, angle); //rotates the weapon to the mouse
    }

}