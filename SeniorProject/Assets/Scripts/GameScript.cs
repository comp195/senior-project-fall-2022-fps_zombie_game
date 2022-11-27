using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameScript : MonoBehaviour
{

    [SerializeField] public GameObject StartScreen; // startscreen 
    [SerializeField] public GameObject GameOverScreen; // game over
    [SerializeField] private GameObject Food;

    private int totalFood; //Total food remaining
    private float itemscollected; // number of food items collected 

    private float current_time = 0f; //to hold the current time 
    [SerializeField]private float starting_Time = 120f; //  starting time for the Game being 120 seconds which is 2 mins
    [SerializeField] TextMeshProUGUI countdownText; // UI on screen to display time
    private string msgPrefix; // to display Time: 120s
    
    private int xPos; // to get position of enemy
    private int zPos; // enemy position
    private int enemycount;

    [SerializeField] private GameObject Enemy; // refrence to enemy
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn()); // to spawn enemies in random locations
        itemscollected = 0;
        totalFood = Food.transform.childCount;
        StartScreen.SetActive(true);
        GameOverScreen.SetActive(false);
        Time.timeScale=0; // game paused
        current_time = starting_Time; // time set to 120 seconds at the start
        msgPrefix = "Time: ";
        
    }

    // Update is called once per frame
    void Update()
    {
        current_time -= 1 * Time.deltaTime; // time updated each frame, which is subtracted by 1 second per frame
        countdownText.SetText(msgPrefix + (current_time));

        if (current_time <= 0)
        {
            current_time = 0;
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
        
        
        

    }

    public void CollectedItem() // to see how many health boxes have been collected
    {
        itemscollected++;
    }

    public void StartButton() // Start button on start screen
    {
        Time.timeScale = 1;
        StartScreen.SetActive(false); // game unpaused
    }

    public void Restart() // restart button on GameOver Screen
    {
        SceneManager.LoadScene("Level-1");
        StartScreen.SetActive(false);
    }

    public void MainMenu() // main menu button on GameOver screen 
    {
        StartScreen.SetActive(true);
    }

    float numItemsCollected()
    {
        return itemscollected;
    }

    IEnumerator EnemySpawn() // to place enemy spawn randomly around the placed enemy.
    {
        while (enemycount < 100)
        {
            xPos = Random.Range(575,535);
            zPos = Random.Range(579, 545);
            Instantiate(Enemy, new Vector3(xPos, 14, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            enemycount += 1;


        }
        
    }
}
