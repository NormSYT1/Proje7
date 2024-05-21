using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float xRot = 0f;
    float yRot = 0f;
    public float sensitivity = 100f;
    public GameObject player;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        xRot -= mouseY;
        yRot += mouseY;
        xRot = Mathf.Clamp(xRot, 0, 10f);
        yRot = Mathf.Clamp(xRot, -15f, 10f);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        player.transform.Rotate(Vector3.up * mouseX);
    }
}
