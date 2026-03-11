using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem; // Added this

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float zoomLerpSpeed = 10f;
    [SerializeField] private float minDistance = 5f;
    [SerializeField] private float maxDistance = 10f;

    private PlayerControls controls;
    private CinemachineCamera cam; 
    private CinemachineOrbitalFollow orbital;
    private Vector2 scrollDelta;
    private float targetZoom;
    private float currentZoom;

    void Start()
    {
        controls = new PlayerControls();
        controls.Enable();
        
        controls.CameraControls.MouseZoom.performed += HandleMouseScroll;
        
        Cursor.lockState = CursorLockMode.Locked;  

        cam = GetComponent<CinemachineCamera>();
        orbital = cam.GetComponent<CinemachineOrbitalFollow>();

        targetZoom = currentZoom = orbital.Radius;
    }

    private void HandleMouseScroll(InputAction.CallbackContext context)
    {
        scrollDelta = context.ReadValue<Vector2>();
    }

    void Update()
    {
        if(scrollDelta.y != 0)
        {

            targetZoom = Mathf.Clamp(targetZoom - scrollDelta.y * zoomSpeed, minDistance, maxDistance);
            scrollDelta = Vector2.zero;
        }

        // float bumperDelta = controls.CameraControls.GamepadZoom.ReadValue<float>();
        // if(bumperDelta != 0)
        // {
        //     targetZoom = Mathf.Clamp(orbital.Radius - bumperDelta * zoomSpeed, minDistance, maxDistance);
        // }
        currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * zoomLerpSpeed);
        orbital.Radius = currentZoom;
    }
}