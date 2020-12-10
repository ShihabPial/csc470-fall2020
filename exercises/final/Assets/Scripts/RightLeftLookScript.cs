using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftLookScript : MonoBehaviour
{
    Vector2 mouseDirection;
    float rotationSpeed = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseChange = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDirection = mouseDirection + mouseChange * rotationSpeed;

        this.transform.localRotation = Quaternion.AngleAxis(mouseDirection.x, Vector3.up);
    }
}
