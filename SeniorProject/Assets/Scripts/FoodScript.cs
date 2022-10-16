using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private GameScript gScript; // for the player in the gameobject reference 
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider player) // destroy the food object as soon as the player goes thru it
    {
        gScript = player.GetComponent<GameScript>();
        if (gScript != null)
        {
            gScript.CollectedItem();
            Destroy(gameObject);
        }
    }
}
