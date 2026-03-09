// using System.Numerics;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerMovement inputManager;
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public float movementSpeed = 7;
    public float rotationSpeed = 15;

    private void Awake()
    {
        inputManager = GetComponent<PlayerMovement>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }
    public void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.linearVelocity = movementVelocity;
    }

    public void HandleRotation()
    {
        Vector3 targetdirection = Vector3.zero;
        targetdirection = cameraObject.forward * inputManager.verticalInput;
        targetdirection = targetdirection + cameraObject.right * inputManager.horizontalInput;
        targetdirection.Normalize();
        targetdirection.y=0;
        if (targetdirection == Vector3.zero)
            targetdirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetdirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);
        transform.rotation = playerRotation;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }
}
