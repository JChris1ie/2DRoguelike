using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleScreenFade : MonoBehaviour
{
    // Start is called before the first frame update
    private float fadeTime = 1.5f;
    public Image uiImage;
    private float opacity;
    private int isChanging;
    private float elapsed;
    public bool isWaiting;
    private RectTransform trans;
    private bool forGame;
    void Start()
    {
        forGame = true;
        elapsed = 0;
        isChanging = 0;
        uiImage = gameObject.GetComponent<Image>();
        Color currentColor = uiImage.color;
        currentColor.a = 0;
        uiImage.color = currentColor;
        FadeIn();
        trans = gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isChanging == 2) //fade in
        {
            if (elapsed > fadeTime)
            {
                elapsed = 0;
                isChanging = 0;
                trans.anchoredPosition = new Vector2(0, 5000);
                return;
            }
            elapsed += Time.deltaTime;
            opacity = 1 - (elapsed / fadeTime);

            Color currentColor = uiImage.color;
            currentColor.a = opacity;
            uiImage.color = currentColor;
        }

        if (isChanging == 1) //fade out
        {
            if (elapsed > fadeTime)
            {
                elapsed = 0;
                isChanging = 0;
                if (forGame)
                {
                    Debug.Log("Starting game");
                    SceneManager.LoadScene("Scene1");
                }
                else
                {
                    Debug.Log("Starting tutorial");
                    SceneManager.LoadScene("Tutorial");
                }
                return;
            }
            elapsed += Time.deltaTime;
            opacity = elapsed / fadeTime;

            Color currentColor = uiImage.color;
            currentColor.a = opacity;
            uiImage.color = currentColor;
        }

    }

    public void FadeIn()
    {
        isChanging = 2;
    }
    public void FadeOutForGame()
    {
        trans.anchoredPosition = new Vector2(0, 0);
        isChanging = 1;
        forGame = true;
    }
    public void FadeOutForTutorial()
    {
        trans.anchoredPosition = new Vector2(0, 0);
        isChanging = 1;
        forGame = false;
    }
}

