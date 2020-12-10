using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform player;
    public Transform gun;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RotateCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector2 look = new Vector2(mouseX, mouseY);
        transform.Rotate(0, mouseY, 0);

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        Vector3 rotGun = gun.transform.rotation.eulerAngles;
        Vector3 rotPlayer = player.transform.rotation.eulerAngles;

        rotGun.x -= rotAmountY;
        rotGun.z = 0;
        rotPlayer.y += rotAmountX;

        gun.rotation = Quaternion.Euler(rotGun);
        player.rotation = Quaternion.Euler(rotPlayer);
    }
}
