using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class BubbleUp : Ability
{
    public GameObject bubblePrefab;
    public float onScreenTime;
    public float cooldownTime;

    private bool isOnScreen = false;
    private bool isOnCooldown = false;
    public override void Activate(GameObject wielder)
    {
        if (!isOnCooldown && !isOnScreen)
        {
            GameObject Bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            StartCoroutine(DeleteBubble(Bubble));
        }
        
    }
    IEnumerator DeleteBubble(GameObject summon)
    {
        isOnScreen = true;
        yield return new WaitForSeconds(onScreenTime);
        Destroy(summon);
        isOnScreen = false;
        StartCoroutine(GoOnCooldown());
    }
    IEnumerator GoOnCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
}
