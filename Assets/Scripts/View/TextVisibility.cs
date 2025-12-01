using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text1;
    TMP_Text text2;
    TMP_Text text3;

    void Start()
    {
        text1 = gameObject.GetComponent<TMP_Text>();
        text2 = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
        text3 = gameObject.transform.GetChild(1).GetComponent<TMP_Text>();
        Hide();
    }

    // Update is called once per frame
    public void Hide()
    {
        text1.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
    }
    public void Show()
    {
        text1.enabled = true;
        text2.enabled = true;
        text3.enabled = true;
    }
}
