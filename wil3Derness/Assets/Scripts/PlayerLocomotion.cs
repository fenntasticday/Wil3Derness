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
    public Animator m_Animator;

    [Header("Ground Snapping")]
    [Tooltip("Distance to check for ground. Adjust based on if your character pivot is at the feet or center.")]
    public float groundCheckDistance = 1.2f;
    [Tooltip("Offset raycast slightly up to avoid clipping with the ground.")]
    public float groundCheckOffset = 0.5f;
    public LayerMask groundLayer = ~0;
    public float slopeForce = 15f;

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

        Vector3 rayOrigin = transform.position + (Vector3.up * groundCheckOffset);
        bool isGrounded = Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, groundCheckDistance, groundLayer);
        if (isGrounded)
        {
            moveDirection = Vector3.ProjectOnPlane(moveDirection, hit.normal).normalized;
        }
        else
        {
            moveDirection.y = 0;
        }
        moveDirection *= movementSpeed;
        Vector3 movementVelocity = moveDirection;

        if (isGrounded)
        {
            if (movementVelocity.y <= 0)
            {
                movementVelocity.y -= slopeForce;
            }
        }
        else
        {
            movementVelocity.y = playerRigidbody.linearVelocity.y;
        }

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
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (m_Animator == null) return;

        bool isMoving = Mathf.Abs(inputManager.verticalInput) > 0.1f || Mathf.Abs(inputManager.horizontalInput) > 0.1f;

        m_Animator.SetBool("isMoving", isMoving);
    }
}
