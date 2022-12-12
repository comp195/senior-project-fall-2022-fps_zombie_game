using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

    private float current_health = 0f; // current health
    [SerializeField] private float starting_Health = 100f; // starting health of the player
    [SerializeField] private TextMeshProUGUI HealthText; // The Display Text
    private string HealthLeftmsg;// msg displaying the health
    
    private int xPos; // to get position of enemy
    private int zPos; // enemy position
    private int enemycount;

    [SerializeField] private GameObject Enemy; // refrence to enemy
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(EnemySpawn()); // to spawn enemies in random locations
        itemscollected = 0;
        totalFood = Food.transform.childCount; 
        current_time = starting_Time; // time set to 120 seconds at the start
        msgPrefix = "Time: ";
        current_health = starting_Health; // initial health of our hero is 100
        HealthLeftmsg = "HEALTH: ";

    }

    // Update is called once per frame
    void Update()
    {
        current_time -= 1 * Time.deltaTime; // time updated each frame, which is subtracted by 1 second per frame
        countdownText.SetText(msgPrefix + (current_time));
        
        
       // current_health -= 1; // health subtracted by 1
        HealthText.SetText(HealthLeftmsg+ (current_health)); // health display
        if (current_health <= 0)
        {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
        

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
        while (current_time > -1)
        {
             xPos = Random.Range(49, 124);
             zPos = Random.Range(49, 694);
            Instantiate(Enemy, new Vector3(xPos,1 , zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            enemycount += 1;


        }
        
    }
}
