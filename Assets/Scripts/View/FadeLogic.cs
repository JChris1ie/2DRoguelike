using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private float fadeTime = 1.5f;
    public Image uiImage; 
    private float opacity;
    private int isChanging;
    private float elapsed;
    public bool isWaiting;
    GameObject doorObj;
    Door doorScript;
    GameObject player;
    PlayerMovement moveScript;
    TextVisibility text1;
    TextVisibility text2;
    void Start()
    {
        elapsed = 0;
        isChanging = 0;
        uiImage = gameObject.GetComponent<Image>();
        Color currentColor = uiImage.color;
        currentColor.a = 0;
        uiImage.color = currentColor;
        isWaiting = false;

        doorObj = GameObject.FindWithTag("Door");
        doorScript = doorObj.GetComponent<Door>();

        player = GameObject.FindWithTag("Player");
        moveScript = player.GetComponent<PlayerMovement>();

        text1 = GameObject.FindWithTag("Ability1").GetComponentInParent<TextVisibility>();
        text2 = GameObject.FindWithTag("Ability2").GetComponentInParent<TextVisibility>();

        FadeOut();
    }

    private void Update()
    {
        if (isChanging == 1) //fade in
        {
            if (elapsed > fadeTime)
            {
                text1.Show();
                text2.Show();
                elapsed = 0;
                isChanging = 0;
                return;
            }
            elapsed += Time.deltaTime;
            opacity = elapsed/fadeTime;

            Color currentColor = uiImage.color;
            currentColor.a = opacity;
            uiImage.color = currentColor;
            isWaiting = true;
        }

        if (isChanging == 2) //fade out
        {
            text1.Hide();
            text2.Hide();
            if (elapsed > fadeTime)
            {
                elapsed = 0;
                isChanging = 0;
                return;
            }
            elapsed += Time.deltaTime;
            opacity = 1 - (elapsed / fadeTime);

            Color currentColor = uiImage.color;
            currentColor.a = opacity;
            uiImage.color = currentColor;
        }

        if (isWaiting && doorScript.answered)
        {
            isWaiting = false;
            moveScript.resetLocation();
            FadeOut();
        }


    }

    public void FadeIn()
    {
        isChanging = 1;
    }
    public void FadeOut()
    {
        isChanging = 2;
    }
}
