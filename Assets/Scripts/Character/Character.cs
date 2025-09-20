using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.Rendering.DebugUI.Table;

public abstract class Character : MonoBehaviour //This class is the main parent of all character objects. It is labeled abstract because it is a blueprint, and will not be used independently
{
    [Header("KeyBinds")]

    public KeyCode primaryFireKey;
    public KeyCode defenceKey;
    public KeyCode mainAbilityKey;
    public KeyCode ultimateKey;

    [Header("Stats")]

    public float characterHealth = 100f;
    public float characterMaxHealth = 100f;
    public float characterPrimaryAttackDamage = 10;

    private void Update()
    {
        TrackInputs(); // This tracks inputs that will be a thing in every character (Primary, Defence, Main, Ultimate)
    }

    public void PlayerTakeDamage(float amount) // Can be used to decreace the players health by a given amount until their health is 0 or below
    {
        characterHealth -= amount;
        //Debug.Log($"Player health is now {characterHealth}");
        if (characterHealth <= 0)
        {
            KillPlayer();
        }
    }
    public void HealPlayer(float amount) // Can be used later for health buff objects or regeneration abilities
    {
        characterHealth += amount;
        if (characterHealth >= characterMaxHealth)
        {
            characterHealth = characterMaxHealth;
        }
        Debug.Log($"Player has been healed for {amount}, player health is now {characterHealth}");
    }
    public void KillPlayer()
    {
        // Any dead logic will go here in the future
        Debug.Log("Player has been slain");
    }
    public void TrackInputs()
    {
        if (Input.GetKeyDown(primaryFireKey))
        {
            CharacterPrimaryAttack();
        }
        else if (Input.GetKeyDown(mainAbilityKey))
        {
            CharacterUseMainAbility();
        }
        else if (Input.GetKeyDown(defenceKey))
        {
            CharacterUseDefenceAbility();
        }
        else if (Input.GetKeyDown(ultimateKey))
        {
            CharacterUseUltimateAbility();
        }

    }
    // These are methods that must be created on a class by class basis in order to make every ability unique
    // THIS MEANS ALL OF THESE METHODS MUST BE IMPLEMENTED IN EACH CHILD CLASS OF CHARACTER (Which is our intention) 
    // If a child implements one of these methods, it's children do not have to implement it
    public abstract void CharacterPrimaryAttack();
    public abstract void CharacterUseMainAbility();
    public abstract void CharacterUseDefenceAbility();
    public abstract void CharacterUseUltimateAbility();

}
