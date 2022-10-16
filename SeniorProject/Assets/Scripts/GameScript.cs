using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{

    [SerializeField] public GameObject StartScreen; // startscreen 

    [SerializeField] private GameObject Food;

    private int totalFood; //Total food remaining
    private float itemscollected;
    

    // Start is called before the first frame update
    void Start()
    {
        itemscollected = 0;
        totalFood = Food.transform.childCount;
        StartScreen.SetActive(true);
        Time.timeScale=0; // game paused
    }

    // Update is called once per frame
    void Update()
    {
        
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
