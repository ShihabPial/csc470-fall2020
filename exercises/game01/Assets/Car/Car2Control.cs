using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class Car2Control : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody rb;
    private float mvX;
    private float mvY;
    private float mvZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(3.0f, 0.0f, 0.0f);

        rb.AddForce(movement * speed);
    }
}
