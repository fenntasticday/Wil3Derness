using DialogueEditor;
using Unity.Cinemachine;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public PanelMover panel;
    public PlayerMovement playerControls;
    public CinemachineInputAxisController cameraControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            
            panel.PanelShow();
            playerControls.OnDisable();
            cameraControl.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void resumeTime()
    {
        panel.PanelHide();
        playerControls.OnEnable();
        cameraControl.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
