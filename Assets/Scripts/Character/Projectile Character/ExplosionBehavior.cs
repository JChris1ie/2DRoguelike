using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    public float explosionDamage;
    public float explosionOnScreenTime;

    private void Start()
    {
        StartCoroutine(EndExplosion());
    }
    IEnumerator EndExplosion()
    {
        yield return new WaitForSeconds(explosionOnScreenTime);
        Destroy(gameObject);
    }
}
