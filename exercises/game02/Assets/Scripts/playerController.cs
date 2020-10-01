using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    float speed = 5f;
    float rotateSpeed = 100f;
    int score = 0;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime , 0, Space.World);

        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);

        if (speed > 0)
        {
            speed -= 4 * Time.deltaTime;
        }
        // Make it so we move faster when we press space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed += 5;
        }
        // Make sure speed doesn't get less than zero or greater than 15.
        speed = Mathf.Clamp(speed, 0, 15);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Chakra"))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();
        }        
    }
}
