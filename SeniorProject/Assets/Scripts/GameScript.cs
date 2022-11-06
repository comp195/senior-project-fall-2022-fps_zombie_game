using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameScript : MonoBehaviour
{

    [SerializeField] public GameObject StartScreen; // startscreen 

    [SerializeField] private GameObject Food;

    private int totalFood; //Total food remaining
    private float itemscollected; // number of food items collected 

    private float current_time = 0f; //to hold the current time 
    private float starting_Time = 120f; //  starting time for the Game being 120 seconds which is 2 mins
    [SerializeField] TextMeshProUGUI countdownText; // UI on screen to display time
    private string msgPrefix; // to display Time: 120s
    

    // Start is called before the first frame update
    void Start()
    {
        itemscollected = 0;
        totalFood = Food.transform.childCount;
        StartScreen.SetActive(false);
        Time.timeScale=1; // game paused
        current_time = starting_Time; // time set to 120 seconds at the start
        msgPrefix = "Time: ";
    }

    // Update is called once per frame
    void Update()
    {
        
        current_time -= 1 * Time.deltaTime; // time updated each frame, which is subtracted by 1 second per frame
        countdownText.SetText(msgPrefix + (current_time));
        
        
        

    }

    public void CollectedItem()
    {
        itemscollected++;
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        StartScreen.SetActive(false); // game unpaused
    }

    float numItemsCollected()
    {
        return itemscollected;
    }
}
