using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileCharacter : Character
{
    [Header("Projectile Object")]
    public GameObject projectile;

    [Header("Stats")]
   
    public float projectileCooldownTime;

    public float projectileSpeed;

    private bool isProjectileOnCooldown = false;



    public override void CharacterPrimaryAttack()
    {

        if (!isProjectileOnCooldown)
        {
            PutProjectileOnScreen();
        }

    }
    public void PutProjectileOnScreen()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.SetActive(true);
        var projBehavior = newProjectile.GetComponent<Projectilebehavior>();
        if (projBehavior != null)
        {
            projBehavior.wielder = gameObject;          
            projBehavior.projectileCharacter = this;    
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
