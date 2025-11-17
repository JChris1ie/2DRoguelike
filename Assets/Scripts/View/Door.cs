using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Door : MonoBehaviour
{

    string[] new_abilities = { null, null };

    public UnityEvent ChangeScene;

    public AbilityTree player;

    private PlayerMovement playerMovementScript;

    public Character character;

    public RoundCounter roundCounter;

    bool answered = true;

    void Start()
    {
        // Find the player's AbilityTree component (attached to the Player GameObject)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<AbilityTree>();
        playerMovementScript = playerObject.GetComponent<PlayerMovement>();
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        roundCounter = GameObject.FindGameObjectWithTag("RoundCounter").GetComponent <RoundCounter>();

    }

    void Update()
    {
        if (answered == false)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                for (int i = 0; i < player.current_abilities.Length; i++)
                {
                    Debug.Log(player.current_abilities[i]);
                    if (player.current_abilities[i] == "")
                    {
                        player.current_abilities[i] = new_abilities[0];
                        Get_Pick_Up_Ability(new_abilities[0]);
                        Debug.Log(i + " New ability added! " + new_abilities[0]);
                        answered = true;
                        break;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                for (int i = 0; i < player.current_abilities.Length; i++)
                {
                    if (player.current_abilities[i] == "")
                    {
                        player.current_abilities[i] = new_abilities[1];
                        Get_Pick_Up_Ability(new_abilities[1]);
                        Debug.Log(i +" New ability added! "+ new_abilities[1]);
                        answered = true;
                        break;
                    }
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
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        
        if (collider.CompareTag("Player") && answered == true)
        {
            roundCounter.IncreaceRoomCount();
            new_abilities = player.get_all_abilities();
            //string ability1 = new_abilities[0];
            Debug.Log(new_abilities[0]);
            //string ability2 = new_abilities[1];
            Debug.Log(new_abilities[1]);
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
        GameObject.FindWithTag("RoomGenerator").GetComponent<GenerateBackground>().DeleteTiles();
        yield return new WaitForSeconds(.1f);
    }
}

