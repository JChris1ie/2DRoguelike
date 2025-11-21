using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("Pause Key")]
    public KeyCode pauseKey = KeyCode.Escape;

    private bool paused = false;
    private void Update()
    {
        TrackInputs();
    }
    private void TrackInputs()
    {
            if (Input.GetKeyDown(pauseKey))
            {
                if (!paused)
                {
                    paused = true;
                    Time.timeScale = 0;
                    // pull up pause screen here 
                }
                else 
                {
                    paused = false;
                    Time.timeScale = 1;
                    // take away pause screen here 
                }
            }
        
        
        
    }

}
