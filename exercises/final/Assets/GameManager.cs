using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text text;
    public string[] textEntries;
    public static GameManager instance;
    public Image fadeImage;
    public Image healthImage;
    public PlayerScript player;
    public GameObject textbox;


    public void Awake()
    {
        if(instance!= null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fade());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator fade()
    {
        while(fadeImage.color.a >= 0)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - 0.6f * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(sequence());
    }

    IEnumerator sequence()
    {
        textbox.SetActive(true);

        text.text = textEntries[0];
        int count = 0;
        while(count < textEntries.Length)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                count++;
                if (count < textEntries.Length) 
                { 
                    text.text = textEntries[count];
                }
            }
            yield return null;
        }

        textbox.SetActive(false);
    }

}
