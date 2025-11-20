using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeCharacter : Character
{
    [Header("Melee Weapon Object")]
    public GameObject meleeWeapon;

    [Header("Stats")]
    public float weaponScreenTime;
    public float weaponCooldownTime;

    public bool isWeaponOnScreen = false;
    public bool activateMelee = false;
    private bool isWeaponOnCooldown = false;

    new private void Start()
    {
        meleeWeapon.SetActive(false);
    }
    
    public override void CharacterPrimaryAttack()
    {
        
        if (!isWeaponOnScreen && !isWeaponOnCooldown)
        {
            StartCoroutine(PutSwordOnScreen());
        }
        
    }
    IEnumerator PutSwordOnScreen()
    {
        activateMelee = true;
        isWeaponOnScreen = true;
        //meleeWeapon.GetComponent<MeleeWeaponBehavior>().SetMeleeRotation();
        meleeWeapon.SetActive(true);
        yield return new WaitForSeconds(weaponScreenTime);
        meleeWeapon.SetActive(false);
        isWeaponOnScreen = false;
        activateMelee = false;
        StartCoroutine(PutWeaponOnSwingCoolDown());
    }
    IEnumerator PutWeaponOnSwingCoolDown()
    {
        isWeaponOnCooldown = true;
        yield return new WaitForSeconds(weaponCooldownTime);
        isWeaponOnCooldown = false;
    }
   
}
