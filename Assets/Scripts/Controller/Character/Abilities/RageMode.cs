using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class RageMode : Ability
{
    public float duration;
    public float boostToMaxHealth = 100;
    public float boostToHealth = 100;
    public float boostToDamage = 10;
    Character characterScript;
    public override void Activate(GameObject weilder)
    {
        characterScript = weilder.GetComponent<Character>();
        StartCoroutine(BoostStats());
    }
    

    IEnumerator BoostStats()
    {
        characterScript.characterMaxHealth += boostToMaxHealth;
        characterScript.characterHealth += boostToHealth;
        characterScript.characterPrimaryAttackDamage += boostToDamage;
        yield return new WaitForSeconds(duration);
        characterScript.characterMaxHealth -= boostToMaxHealth;
        characterScript.characterHealth -= boostToHealth;
        characterScript.characterPrimaryAttackDamage -= boostToDamage;

    }
}
