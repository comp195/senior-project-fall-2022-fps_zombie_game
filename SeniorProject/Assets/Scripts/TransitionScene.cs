using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Continue()
    {
        SceneManager.LoadScene("Level-2");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Scenes/GameStartScreen");
    }
}
