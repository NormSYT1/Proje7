using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float sensitivity = 400f;
    private float xRotation = 0f;
    public Transform playerBody;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xRotation = -mouseY;   
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(30f, xRotation, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}
