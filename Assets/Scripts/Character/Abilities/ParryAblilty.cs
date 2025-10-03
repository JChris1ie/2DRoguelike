using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ParryAblilty : Ability
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
        Debug.Log("ParryAbility shield prefab scale: " + shield.transform.localScale);
    }
    public override void Activate(GameObject wielder)
    {
        if (!isShieldOnScreen && !isShieldOnCooldown)
        {
            GameObject shieldInstance = Instantiate(shield, wielder.transform.position, Quaternion.identity, wielder.transform);
            Debug.Log("Shield spawned at: " + shieldInstance.transform.position);
            Debug.Log("Spawned shield scale: " + shieldInstance.transform.localScale);
            var shieldBehavior = shieldInstance.GetComponent<ShieldBehavior>();
            shieldBehavior.wielder = wielder;

            StartCoroutine(PutShieldOnScreen(shieldInstance, shieldBehavior));
        }
    }

    private IEnumerator PutShieldOnScreen(GameObject shieldInstance, ShieldBehavior shieldBehavior)
    {
        isShieldOnScreen = true;

        shieldBehavior.SetShieldRotation();
        shieldInstance.SetActive(true);

        yield return new WaitForSeconds(shieldScreenTime);

        Destroy(shieldInstance);
        isShieldOnScreen = false;

        StartCoroutine(PutShieldCoolDown());
    }
    IEnumerator PutShieldCoolDown()
    {
        isShieldOnCooldown = true;
        yield return new WaitForSeconds(shieldCooldownTime);
        isShieldOnCooldown = false;
    }
}
