using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Door : MonoBehaviour
{

    string[] new_abilities = { null, null };

    public UnityEvent ChangeScene;

    public AbilityTree player;

    bool answered = true;
    void Start()
    {
        // Find the player's AbilityTree component (attached to the Player GameObject)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<AbilityTree>();
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
                        Debug.Log(i +" New ability added! "+ new_abilities[1]);
                        answered = true;
                        break;
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.CompareTag("Player") && answered == true)
        {
            Debug.Log("Touched door");
            new_abilities = player.get_all_abilities();
            //string ability1 = new_abilities[0];
            Debug.Log(new_abilities[0]);
            //string ability2 = new_abilities[1];
            Debug.Log(new_abilities[1]);
            answered = false;
            ChangeScene.Invoke();
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
}