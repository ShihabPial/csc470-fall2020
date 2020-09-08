using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarControl : MonoBehaviour
{
    public float speed = 0.0f;

    private Rigidbody rb;
    private float mvX;
    private float mvY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        mvX = movementVector.x;
        mvY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(-0.5f, 0.0f);

        rb.AddForce(movement * speed);
    }
}


