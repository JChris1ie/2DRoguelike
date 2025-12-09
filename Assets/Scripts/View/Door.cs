using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;



public class Door : MonoBehaviour
{

    string[] new_abilities = { null, null };

    public UnityEvent ChangeScene;

    public AbilityTree player;

    private PlayerMovement playerMovementScript;
    
    private TestCharacter testCharacter;

    private GameObject meleeWeapon;

    private SwingMeleeWeapon swing;

    public Character character;

    public RoundCounter roundCounter;

    private LaunchProjectile launch;

    public bool answered = true;

    GameObject textObj1;
    GameObject textObj2;

    TMP_Text text1;
    TMP_Text text2;

    void Start()
    {
        // Find the player's AbilityTree component (attached to the Player GameObject)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<AbilityTree>();
        playerMovementScript = playerObject.GetComponent<PlayerMovement>();
        //meleeCharScript = playerObject.GetComponent<PlayerMovement>();
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        roundCounter = GameObject.FindGameObjectWithTag("RoundCounter").GetComponent <RoundCounter>();
        testCharacter = character.GetComponent<TestCharacter>();
        textObj1 = GameObject.FindWithTag("Ability1");
        textObj2 = GameObject.FindWithTag("Ability2");

        text1 = textObj1.GetComponent<TMP_Text>();
        text2 = textObj2.GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (answered == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                for (int i = 0; i < player.current_abilities.Length; i++)
                {
                    Debug.Log(player.current_abilities[i]);
                    if (player.current_abilities[i] == "")
                    {
                        player.current_abilities[i] = new_abilities[0];
                        Get_Pick_Up_Ability(new_abilities[0]);
                        Debug.Log(i + " New ability added! " + new_abilities[0]);
                        break;
                    }
                answered = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                for (int i = 0; i < player.current_abilities.Length; i++)
                {
                    if (player.current_abilities[i] == "")
                    {
                        player.current_abilities[i] = new_abilities[1];
                        Get_Pick_Up_Ability(new_abilities[1]);
                        Debug.Log(i +" New ability added! "+ new_abilities[1]);
                        break;
                    }
                answered = true;
                }
            }
        }
    }

    public void Get_Pick_Up_Ability(string ability)
    {
        Debug.Log(ability);
        if (ability == "Speed_Up")
        {
            playerMovementScript.ChangeSpeed(0.50f);
        }
        if (ability == "Hack_and_Slash")
        {
            meleeWeapon = GameObject.FindWithTag("MeleeAbility");
            swing = meleeWeapon.GetComponent<SwingMeleeWeapon>();
            //Debug.Log("Should change atk spd");
            swing.ChangeAttackSpeed(0.5f);
        }
        if(ability == "Demolitionist")
        {
            launch = GameObject.FindWithTag("Bomb").GetComponent<LaunchProjectile>();
            launch.GetDemolitionist();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        
        if (collider.CompareTag("Player") && answered == true && GameObject.FindGameObjectsWithTag("Spawner").Length==0 && GameObject.FindGameObjectsWithTag("Octodude").Length==0 && GameObject.FindGameObjectsWithTag("Freaker").Length==0 && GameObject.FindGameObjectsWithTag("Notpapyrus").Length==0)
        {
            roundCounter.IncreaceRoomCount();
            new_abilities = player.get_all_abilities();
            Debug.Log(new_abilities[0]);
            text1.text = new_abilities[0];
            Debug.Log(new_abilities[1]);
            text2.text = new_abilities[1];
            answered = false;
            StartCoroutine(DestroyFloor());
            
            ChangeScene.Invoke();

            if (Has_ability("Passive_Regen"))
            {
                character.HealPlayer(10);
            }
        }
    }

    public bool Has_ability(string ability_check)
    {
        foreach (string ability in player.current_abilities)
        {
            if (ability == ability_check) return true;
            if (ability == "") return false;
        }
        return false;
    }

    IEnumerator DestroyFloor() {
        Destroy(GameObject.FindWithTag("Floor"));
        yield return new WaitForSeconds(.1f);
        Destroy(GameObject.FindWithTag("Floor"));
        yield return new WaitForSeconds(.1f);
        Destroy(GameObject.FindWithTag("Floor"));
        yield return new WaitForSeconds(.1f);
        Destroy(GameObject.FindWithTag("Floor"));
        yield return new WaitForSeconds(.1f);
    }
}

