using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] public float MaxHealthPoint = 100;
    private float HealthPoint;
    [SerializeField] public float Itime = 2;
    private float nextTimeGetAttack;
    private bool collding = false;

    [SerializeField] public float damage = 30;

    [SerializeField] public Slider healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        nextTimeGetAttack = Time.time;
        HealthPoint = MaxHealthPoint;
        healthbar.maxValue = MaxHealthPoint;
        healthbar.value = HealthPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (collding == true && Time.time >= nextTimeGetAttack)
        {
            collding = false;
        }
        
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (collding == false && enemy.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HealthPoint -= damage;
            healthbar.value = HealthPoint;
            Debug.Log(HealthPoint);
            collding = true;
            nextTimeGetAttack = Itime + Time.time;
        }

        if (IsPlayerDead())
        {
            GameOver();
            Debug.Log("dead");
        }
    }

    private bool IsPlayerDead()
    {
        if (HealthPoint <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GameOver()
    {
        //add gameover scene here
    }
}
