using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraObject;
    private CharacterController characterController;
    private Vector3 movementInputDirection;
    private Vector3 playerVelocity;

    private float gravityValue = -9.81f;
    private bool isGrounded;

    public float movementSpeed;
    public float jumpHeight;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        isGrounded = characterController.isGrounded;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        // Get the forward and right direction from the camera, ignoring vertical tilt
        Vector3 forward = cameraObject.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cameraObject.transform.right;
        right.y = 0;
        right.Normalize();

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Apply Gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Movement relative to camera direction
        movementInputDirection = (forward * y + right * x).normalized + (playerVelocity.y * Vector3.up);

        characterController.Move(movementInputDirection * movementSpeed * Time.deltaTime);
    }
}
