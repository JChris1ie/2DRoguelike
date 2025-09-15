using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharacter : Character
{
    [Header("Melee Weapon Object")]
    public GameObject meleeWeapon;

    [Header("Stats")]
    public float weaponScreenTime;
    public float weaponCooldownTime;

    public bool isWeaponOnScreen = false;
    public bool activateMelee = false;
    private bool isWeaponOnCooldown = false;

    private void Start()
    {
        meleeWeapon.SetActive(false);
    }
    private void Update()
    {
        if (isWeaponOnScreen)
        {

        }
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
        meleeWeapon.GetComponent<MeleeWeaponBehavior>().SetMeleeRotation();
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
   
    public override void CharacterUseMainAbility()
    {
        Debug.Log("Hello World");
    }
    public override void CharacterUseDefenceAbility()
    {
        Debug.Log("Hello World");

    }
    public override void CharacterUseUltimateAbility()
    {
        Debug.Log("Hello World");
    }
}
