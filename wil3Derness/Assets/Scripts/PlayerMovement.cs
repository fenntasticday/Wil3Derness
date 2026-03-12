using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playerControls;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    public void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.Locomotion.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    public void OnDisable()
    {
        playerControls.Disable();

        movementInput = Vector2.zero;
        verticalInput = 0;
        horizontalInput = 0;
    
    }

    public void HandleAllInputs()
    {
        HandoleMovementInput();
    }

    private void HandoleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }
}
