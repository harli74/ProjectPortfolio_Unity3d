using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    public Transform Player;
    public float speed;
    public GameObject StartPanel;
    void Start()
    {
        StartPanel.SetActive(true);
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
      
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        Player.rotation = Quaternion.Euler(0,rotY,0);
        if (Input.GetKey(KeyCode.W))
        {
            Player.Translate(Vector3.forward * speed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            Player.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
    
}
