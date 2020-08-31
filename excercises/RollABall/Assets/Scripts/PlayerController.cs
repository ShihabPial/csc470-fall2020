using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

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
        Vector3 movement = new Vector3(mvX, 0.0f, mvY);

        rb.AddForce(movement * speed);
	}
}
