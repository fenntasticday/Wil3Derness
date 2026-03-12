using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    public int sceneint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sceneMove()
    {
        SceneManager.LoadScene(sceneint);
    }
}
