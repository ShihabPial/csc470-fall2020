using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Color meterColor;
    public Image meterFG;

    private void Start()
    {
        meterColor.a = 1;
        meterFG.color = meterColor;
    }

    private void Update()
    {
        
    }
    public void setHealth(int health)
    {
        meterFG.fillAmount = health;
    }

}
