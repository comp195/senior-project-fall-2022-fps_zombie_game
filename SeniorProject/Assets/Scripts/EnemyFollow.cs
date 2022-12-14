using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject enemy;

    private NavMeshAgent agent;
    [SerializeField] private GameObject Pl;

    private float origSpeed;
    // Start is called before the first frame update
    private float maxAttackDistance = 2.0f;
    private  bool caughtPlayer;
    
    //PlayerHealth
    private float Health = 100f;
    private float curr_health;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        caughtPlayer = false;
        origSpeed = agent.speed;
        curr_health = Health;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(player.position);
        Vector3 distToPlayer = player.position - transform.position;
        if (distToPlayer.magnitude < maxAttackDistance && !caughtPlayer)
        {
            caughtPlayer = true;
            curr_health -= 1;
            if (curr_health <= 0)
            {
                Debug.Log("you loose");//
                
            }
        }
    }
}