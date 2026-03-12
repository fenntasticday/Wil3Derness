using UnityEngine;
using DialogueEditor;
using System.Collections;
using TMPro;

public class ConversationTrigger : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    public PanelMover panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            panel.PanelShow();
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Cursor.visible = true;
                //playerControls.OnDisable();
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            panel.PanelHide();
    }
}
