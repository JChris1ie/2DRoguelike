using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : Ability
{
    [Header("Projectile Object")]
    public GameObject projectile;

    [Header("Stats")]

    public float projectileCooldownTime = 1f;

    public float projectileSpeed = 3f;

    private bool isProjectileOnCooldown = false;

    private GameObject character;

    private Door door;
    private GameObject door_obj;
    
    public override void Activate(GameObject wielder)
    {
        door_obj = GameObject.FindWithTag("Door");
        door = door_obj.GetComponent<Door>();
        if (door.Has_ability("Hack_and_Slash")) projectileCooldownTime = 0.5f;

        if (!isProjectileOnCooldown)
        {
            character = wielder;
            PutProjectileOnScreen();
        }

    }
    public void PutProjectileOnScreen()
    {
        GameObject newProjectile = Instantiate(projectile, character.transform.position, Quaternion.identity);
        newProjectile.SetActive(true);
        var projBehavior = newProjectile.GetComponent<Projectilebehavior>();
        if (projBehavior != null)
        {
            projBehavior.wielder = character;
            projBehavior.projectileSpeed = projectileSpeed;
            projBehavior.LaunchProjectile();
        }

        StartCoroutine(PutProjectileOnCoolDown());
    }
    IEnumerator PutProjectileOnCoolDown()
    {
        isProjectileOnCooldown = true;
        yield return new WaitForSeconds(projectileCooldownTime);
        isProjectileOnCooldown = false;
    }
}
