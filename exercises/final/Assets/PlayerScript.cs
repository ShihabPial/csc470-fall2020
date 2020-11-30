using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterController cc;
    float moveSpeeed = 10;

    Vector2 mouseDirection;

    public GameObject bullet;
 

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Basic WASD movement
        float xDirection = Input.GetAxis("Horizontal");
        xDirection *= 1; //Was moving oppopsite direction. So multiplied with -1
        float zDirection = Input.GetAxis("Vertical");
        zDirection *= 1;//Was moving oppopsite direction. So multiplied with -1

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position = transform.position + moveDirection * moveSpeeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletEgg = Instantiate(bullet, transform.position + transform.forward * 3, Quaternion.identity);
            Rigidbody bulletEggRb = bullet.GetComponent<Rigidbody>();
            bulletEggRb.AddForce(transform.forward * 8000);
            Destroy(bullet, 5);
        }
    }


}
