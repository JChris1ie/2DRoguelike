using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacter : Character
{
    [Header("Ability Prefabs")]
    public GameObject leftClickAbility;
    public GameObject rightClickAbility;
    public GameObject mainAbility;
    public GameObject ultimateAbility;

    private Ability leftClickAbilityScript;
    private Ability rightClickAbilityScript;
    private Ability mainAbilityScript;
    private Ability ultimateAbilityScript;



    private void Start()
    {
        leftClickAbilityScript = Instantiate(leftClickAbility, transform).GetComponent<Ability>();
        rightClickAbilityScript = Instantiate(rightClickAbility, transform).GetComponent<Ability>();
        mainAbilityScript = Instantiate(mainAbility, transform).GetComponent<Ability>();
        ultimateAbilityScript = Instantiate(ultimateAbility, transform).GetComponent<Ability>();
    }


    public override void CharacterPrimaryAttack()
    {
        leftClickAbilityScript.Activate(gameObject);
    }
    public override void CharacterUseDefenceAbility()
    {
        rightClickAbilityScript.Activate(gameObject);
    }
    public override void CharacterUseMainAbility()
    {
        mainAbilityScript.Activate(gameObject);
    }

    public override void CharacterUseUltimateAbility()
    {
        ultimateAbilityScript.Activate(gameObject);
    }
}
