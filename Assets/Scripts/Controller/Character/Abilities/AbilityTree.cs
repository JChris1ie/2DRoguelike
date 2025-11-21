using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Node
{
    public string ability { get; set; }

    public Node[] nodes = new Node[3];
    public Node node1 { get; set; }
    public Node node2 { get; set; }

    public Node node3 { get; set; }

    public Node(string ability, Node node1 = null, Node node2 = null, Node node3 = null)
    {
        this.ability = ability;
        nodes[0] = node1;
        nodes[1] = node2;
        nodes[2] = node3;
    }
}

public class AbilityTree : MonoBehaviour
{
    public Node head = new Node("knight", new Node("Longsword", new Node("Blunt_Edge", new Node("Energized", new Node("Critical_Hit", new Node("Lucky")), new Node("Flame_Sword", new Node("Hack_and_Slash"))))), new Node("Parry", new Node("Perfect_Parry", new Node("Bubble_Shield", new Node("Impervious", new Node("Second_Wind")), new Node("Home_Run", new Node("Passive_Regen"))))), new Node("Dash", new Node("Dash+", new Node("Speed_Up", new Node("Bullet_Time", new Node("Concussive")), new Node("Agile", new Node("Light_Speed"))))));

    public string[] current_abilities = { "knight", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };

    int new_ability_count = 0;

    public string[] new_abilities = new string[6];


    public string[] get_all_abilities()
    {
        /*current_abilities[0] = "knight";*/

        Array.Clear(new_abilities, 0, new_abilities.Length);
        new_ability_count = 0;

        foreach (Node next_node in this.head.nodes)
        {
            get_all_abilities_(next_node);
        }

        System.Random random = new System.Random();
        if (new_ability_count < 3)
        {
            return new string[] { new_abilities[0], new_abilities[1] };
        }

        int random_ability1 = random.Next(0, new_ability_count);
        int random_ability2 = random.Next(0, new_ability_count-1);
        if (random_ability2 >= random_ability1) random_ability2++;

        return new string[] { new_abilities[random_ability1], new_abilities[random_ability2] };


    }
    public void get_all_abilities_(Node node)
    {
        if (node == null) return;

        if (Array.Exists(current_abilities, name => name == node.ability))
        {
            foreach (Node next_node in node.nodes)
            {
                if (next_node != null)
                {
                    get_all_abilities_(next_node);
                }
                
            }
        }
        else
        {
            for (int i = 0; i < new_abilities.Length; i++)
            {
                if (new_abilities[i] == null)
                {
                    new_abilities[i] = node.ability;
                    new_ability_count++;
                    break;
                }
            }
        }

    }

}