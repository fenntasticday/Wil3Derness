using UnityEngine;

public class FunFacts : MonoBehaviour
{
    public int faunaID;
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

        }
    }

     void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            canTrigger = true;
        }
    }

}
