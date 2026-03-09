using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement inputManager;
    public PlayerLocomotion playerLocomotion;
   private void Awake()
    {
        inputManager = GetComponent<PlayerMovement>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
}
