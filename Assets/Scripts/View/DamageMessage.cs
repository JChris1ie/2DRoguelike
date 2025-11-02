using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageMessage : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI damageText;

    [Header("Text On Screen Time")]
    public float onScreenTime;

    [Header("How much to move")]
    public float textSpeed;

    private bool moveText = false;
    private Vector2 randomDirection;
    void Start()
    {
        damageText.gameObject.SetActive(false); 
    }
    private void Update()
    {
        if (moveText)
        {
            MoveText();
        }
    }
    public void ShowMessage(string message)
    {
        transform.localPosition = Vector3.zero;
        damageText.gameObject.SetActive(true);
        damageText.text = message;
        StartCoroutine(TurnOffText());

        randomDirection = UnityEngine.Random.insideUnitCircle.normalized;
        moveText = true;
    }
    IEnumerator TurnOffText()
    {
        yield return new WaitForSeconds(onScreenTime);
        moveText = false;
        damageText.gameObject.SetActive(false);
    }
    private void MoveText()
    {
        transform.position += (Vector3)randomDirection * textSpeed * Time.deltaTime;
    }
}
