using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingMeleeWeapon : Ability
{
    [Header("Melee Weapon Prefab")]
    public GameObject meleeWeaponPrefab;

    [Header("Stats")]
    public float weaponScreenTime;
    public float weaponCooldownTime;

    private bool isWeaponOnScreen = false;
    private bool isWeaponOnCooldown = false;

    public override void Activate(GameObject wielder)
    {
        if (!isWeaponOnScreen && !isWeaponOnCooldown)
        {
            wielder = GameObject.FindWithTag("Player");
            GameObject weaponInstance = Instantiate(meleeWeaponPrefab, wielder.transform.position, meleeWeaponPrefab.transform.rotation, wielder.transform);
            var weaponBehavior = weaponInstance.GetComponent<MeleeWeaponBehavior>();
            //weaponBehavior.wielder = wielder;

            StartCoroutine(PutSwordOnScreen(weaponInstance, weaponBehavior));
        }
    }

    private IEnumerator PutSwordOnScreen(GameObject weaponInstance, MeleeWeaponBehavior weaponBehavior)
    {
        isWeaponOnScreen = true;
        weaponInstance.SetActive(true);

        yield return new WaitForSeconds(weaponScreenTime);

        Destroy(weaponInstance);
        isWeaponOnScreen = false;

        StartCoroutine(PutWeaponOnSwingCoolDown());
    }
    IEnumerator PutWeaponOnSwingCoolDown()
    {
        isWeaponOnCooldown = true;
        yield return new WaitForSeconds(weaponCooldownTime);
        isWeaponOnCooldown = false;
    }
    public void ChangeAttackSpeed(float percentage)
    {
        //Debug.Log("Changing attack speed...");
        weaponCooldownTime *= percentage;
        weaponScreenTime *= percentage;

    }
}
