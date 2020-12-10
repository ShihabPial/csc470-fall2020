using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public CharacterController cc;
    float moveSpeeed = 5;
    //float rotateSpeed = 5f;
    public NavMeshAgent agent;
    Vector2 mouseDirection;

    public GameObject bullet;

    public float health = 100f;

    public GameManager gm;

    public Image healthImage;

    public AudioSource shootingAudioSource;
    public AudioClip shootingclip;

    public AudioSource footstepAudio;
    public AudioClip footstepClip;
    bool waitingToPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!waitingToPlay) 
            { 
                waitingToPlay = true;
                footstepAudio.clip = footstepClip;
                footstepAudio.volume = (Random.Range(0.8f, 1f));
                footstepAudio.pitch = (Random.Range(0.8f, 1.1f));
                StartCoroutine(wait());
                footstepAudio.Play();
            }
            
        }

        //Basic WASD movement
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirectionRL = new Vector3(transform.forward.z, 0, transform.forward.x);
        moveDirectionRL = moveDirectionRL.normalized;
        cc.Move(moveDirectionRL * moveSpeeed * xDirection * Time.deltaTime);

        Vector3 moveDirectionUD = new Vector3(transform.forward.x, 0, transform.forward.z);
        moveDirectionUD = moveDirectionUD.normalized;
        cc.Move(moveDirectionUD * moveSpeeed * zDirection * Time.deltaTime);

        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0, Space.Self);

       // transform.Translate(transform.forward * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            shootingAudioSource.clip = shootingclip;
            shootingAudioSource.Play();
            GameObject bulletEgg = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
            Rigidbody eggRB = bulletEgg.GetComponent<Rigidbody>();
            eggRB.AddForce(transform.forward * 2000);
            Destroy(bulletEgg, 5);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            takeDamage();
        }

        if(other.CompareTag("House"))
        {
            healUP();
        }

        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage()
    {
        this.health -= 20;

        if (healthImage.alphaHitTestMinimumThreshold >= 0)
        {
            healthImage.color = new Color(healthImage.color.r, healthImage.color.g, healthImage.color.b, healthImage.color.a + 0.2f);
   
        }
    }

    public void healUP()
    {
        if(health < 100)
        {
            health += 5;
        }

        if (healthImage.alphaHitTestMinimumThreshold <= 1)
        {
            healthImage.color = new Color(healthImage.color.r, healthImage.color.g, healthImage.color.b, healthImage.color.a - 0.2f);

        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.25f);
        waitingToPlay = false;
    }
}
