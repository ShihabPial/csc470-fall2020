using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{

    public Color meterColor;
    public Image meterFG;
    public Image meterFGBG;
    float meterDiff = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        meterColor.a = 1;
        meterFG.color = meterColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(meterFGBG.fillAmount > meterFG.fillAmount)
        {
            meterFGBG.fillAmount -= meterDiff * Time.deltaTime;
        }
    }

    public void setMeter(float val)
    {
        meterFG.fillAmount = val;
    }
}
