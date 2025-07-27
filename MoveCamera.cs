using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform playerBody;

    public float mouseSensitivity;
    private float maxVerticalRotation = 90f;

    private float xRotation;
    private float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        mouseSensitivity *= 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Moving mouse up and down rotates the x axis, vice versa, which is why it is inverse
        xRotation -= y;
        yRotation += x;

        // Clamps the x rotation between the maxVerticalRotation and negative maxVerticalRotation to prevent player from looking all the way backwards.
        xRotation = Mathf.Clamp(xRotation, -maxVerticalRotation, maxVerticalRotation);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);

        playerBody.Rotate(Vector3.up * x);
    }
}
