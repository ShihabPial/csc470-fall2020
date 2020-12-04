using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    public CharacterController cc;
    float moveSpeeed = 10;
    //float rotateSpeed = 5f;
    public NavMeshAgent agent;
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
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirectionRL = new Vector3(transform.forward.z, 0, transform.forward.x);
        cc.Move(moveDirectionRL * moveSpeeed * xDirection * Time.deltaTime);

        Vector3 moveDirectionUD = new Vector3(transform.forward.x, 0, transform.forward.z);
        moveDirectionUD = moveDirectionUD.normalized;
        cc.Move(moveDirectionUD * moveSpeeed * zDirection * Time.deltaTime);

        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0, Space.Self);

       // transform.Translate(transform.forward * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletEgg = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
            Rigidbody eggRB = bulletEgg.GetComponent<Rigidbody>();
            eggRB.AddForce(transform.forward * 8000);
            Destroy(bulletEgg, 5);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // When we collide with the apple tree, update score in game manager, and destroy the tree.
        if (other.CompareTag("House"))
        {
           

        }
    }

}
