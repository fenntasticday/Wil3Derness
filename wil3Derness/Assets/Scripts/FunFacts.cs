using UnityEngine;
using TMPro;
public class FunFacts : MonoBehaviour
{
    // public int faunaID;
    public string funFact;
    public bool canTrigger = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canTrigger == true && (Input.GetKeyDown(KeyCode.E)))
        {
            GameObject panel = GameObject.FindWithTag("FactPanel");
            PanelMover panelToMove = panel.GetComponent<PanelMover>();
            GameObject textObj = GameObject.FindWithTag("FactText");
            TextMeshProUGUI text = textObj.GetComponent<TextMeshProUGUI>();
            text.text = funFact;
            panelToMove.PanelShow();
            Time.timeScale = 0;
        }
    }

     void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            canTrigger = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if(other.tag == "Player")
        {
            canTrigger = false;
        }
    }

}
