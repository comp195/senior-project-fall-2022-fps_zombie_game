using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEstartScreen : MonoBehaviour
{
    [SerializeField] private GameObject TutScreen;
    [SerializeField] private GameObject Credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayButton()
    {
        SceneManager.LoadScene("Scenes/Level-1");
    }

    public void Tutorial()
    {
        TutScreen.SetActive(true);
    }

    public void BackButton()
    {
        TutScreen.SetActive(false);
    }

    public void CreditsScreen()
    {
        Credits.SetActive(true);
    }

    public void BackCredit()
    {
        Credits.SetActive(false);
    }
}
