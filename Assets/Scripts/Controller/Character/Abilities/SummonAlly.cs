using System.Collections;
using UnityEngine;
public class SummonAlly : Ability
{
    [Header("Summon Prefab")]
    public GameObject summon;

    public float onScreenTime;

    public override void Activate(GameObject wielder)
    {
        GameObject newSummon = Instantiate(summon, transform.position, Quaternion.identity);
        StartCoroutine(DeleteSummon(newSummon));
    }
    IEnumerator DeleteSummon(GameObject summon )
    {

        yield return new WaitForSeconds(onScreenTime);
        Destroy(summon);
    }
}
