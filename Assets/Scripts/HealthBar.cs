using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Bar Image")]
    public UnityEngine.UI.Image healthBar;
    
    public void ChangeFill(float amount)
    {
        
        healthBar.fillAmount = amount; 
    }
}
