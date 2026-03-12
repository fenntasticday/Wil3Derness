using DialogueEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransportationHandler : MonoBehaviour
{
    bool canTransport = false;
    public PanelMover panel;
    public int sceneInt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneInt);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTransport = false;
            panel.PanelHide();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTransport = true;
            panel.PanelShow();
        }
    }
}
