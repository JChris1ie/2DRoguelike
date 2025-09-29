using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacter : ProjectileCharacter
{
    [Header("Sheild Object")]
    public GameObject shield;

    [Header("Stats")]
    public float shieldScreenTime;
    public float shieldCooldownTime;

    public bool isShieldOnScreen = false;
    
    private bool isShieldOnCooldown = false;

    private void Start()
    {
        shield.SetActive(false);
    }
    public override void CharacterUseDefenceAbility()
    {
        if (!isShieldOnScreen && !isShieldOnCooldown)
        {
            StartCoroutine(PutShieldOnScreen());
        }

    }
    
    IEnumerator PutShieldOnScreen()
    {
        
        isShieldOnScreen = true;
        shield.GetComponent<ShieldBehavior>().SetShieldRotation();
        shield.SetActive(true);
        yield return new WaitForSeconds(shieldScreenTime);
        shield.SetActive(false);
        isShieldOnScreen = false;
        StartCoroutine(PutShieldCoolDown());
    }
    IEnumerator PutShieldCoolDown()
    {
        isShieldOnCooldown = true;
        yield return new WaitForSeconds(shieldCooldownTime);
        isShieldOnCooldown = false;
    }
    public override void CharacterUseMainAbility()
    {
        Debug.Log("Hello World");
    }

    public override void CharacterUseUltimateAbility()
    {
        Debug.Log("Hello World");
    }
}
