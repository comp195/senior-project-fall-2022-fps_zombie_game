using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScriptLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject Food;

    private int totalFood; //Total food remaining
    private float itemscollected; // number of food items collected 

    private float current_time = 0f; //to hold the current time 
    [SerializeField]private float starting_Time = 90f; //  starting time for the Game being 120 seconds which is 2 mins
    [SerializeField] TextMeshProUGUI countdownText; // UI on screen to display time
    private string msgPrefix; // to display Time: 120s
    
    private int xPos; // to get position of enemy
    private int zPos; // enemy position
    private int enemycount; // to count the number of the enemies

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
    }

    // Update is called once per frame
    void Update()
    {
        current_time -= 1 * Time.deltaTime; // time updated each frame, which is subtracted by 1 second per frame
        countdownText.SetText(msgPrefix + (current_time));


        if (current_time <= 0)
        {
            current_time = 0;
            Time.timeScale = 0;
            SceneManager.LoadScene("Level-3 (simple city)");
        }
        



    }

    public void CollectedItem() // to see how many health boxes have been collected
    {
        itemscollected++;
    }

    float numItemsCollected()
    {
        return itemscollected;
    }

    IEnumerator EnemySpawn() // to place enemy spawn randomly around the placed enemy.
    {
        while (current_time > -1)
        {
             xPos = Random.Range(140, 21);
             zPos = Random.Range(140, 430);
            Instantiate(Enemy, new Vector3(xPos,1 , zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            enemycount += 1;


        }
        
    }
}
