using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingGameManager : MonoBehaviour
{

    float time = 10.0f;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        time -= Time.deltaTime * 2;
        timeText.text = time.ToString();

        if (time < 0)
        {
            SceneManager.LoadScene("WizardScene");
        }
             
    }
}
