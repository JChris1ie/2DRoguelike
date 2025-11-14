using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class BaseEnemy : MonoBehaviour
{
    [Header("Stats")]
    public float enemyHealth = 100f;
    public float enemyMaxHealth = 100f;
    public float enemyPrimaryAttackDamage = 10;
  
    public float attackCooldown = 1f;

    [Header("Drops")]
    public bool dropItems = true;
    public List<GameObject> drops;

    [Header("Damage Text System")]
    public DamageMessage damageMessage;
    public HealthBar healthBar;

    public GameObject characterObject;
    private Character characterScript;

    public GameObject door_object; //required for reference to player abilities
    public Door door; //required for reference to player abilities
    protected virtual void Start()
    {
        enemyHealth = enemyMaxHealth;
        characterObject = GameObject.FindGameObjectWithTag("Player");
        characterScript = characterObject.GetComponent<Character>();

        door_object = GameObject.FindWithTag("Door"); //required for reference to player abilities
        door = door_object.GetComponent<Door>(); //required for reference to player abilities

    }
    public void EnemyTakeDamage(float amount)
    {
        if (door.Has_ability("Critical_Hit"))
        {
            System.Random random = new System.Random();
            int rng = random.Next(0, 100);  //RNJesus
            Debug.Log(rng);

            if (door.Has_ability("Lucky"))
            {
                if (rng <= 30) amount *= 3;  //compare random number to dodge odds and exit function if the attack was dodged
            }
            else
            {
                if (rng <= 15) amount *= 3;
            }
        }

        enemyHealth -= amount;
        if (characterScript != null)
        {
            characterScript.GivePlayerUltCharge(amount / 10);
        }
        if (damageMessage)
        {
            damageMessage.ShowMessage($"{amount}");
        }
        if (enemyHealth <= 0)
        {
            KillEnemy();
        }
        else if (healthBar != null)
        {
            healthBar.ChangeFill(Mathf.Clamp01(enemyHealth / enemyMaxHealth));
        }
        
    }
    public void HealEnemy(float amount)
    {
        enemyHealth += amount;
    }
    
    private void KillEnemy()
    {
        if (dropItems)
        {
            foreach (GameObject drop in drops)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }
        }
        

        Debug.Log("Enemy has been slain");
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    public void DeleteEnemy()//This function should only be used for irregular deaths such as when the enemy explodes itself and does not drop anything or give ult charge.
    {
        Destroy(gameObject);
    }
    public void Updatedamage(float amount)
    {
        enemyPrimaryAttackDamage *= amount;
    }
}
