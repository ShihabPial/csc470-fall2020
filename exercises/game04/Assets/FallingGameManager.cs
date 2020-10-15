using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingGameManager : MonoBehaviour
{

    int score = 10;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score -= 1;
        scoreText.text = score.ToString();

        if(score == 0)
        {
            SceneManager.LoadScene("WizardScene");
        }
    }
}
