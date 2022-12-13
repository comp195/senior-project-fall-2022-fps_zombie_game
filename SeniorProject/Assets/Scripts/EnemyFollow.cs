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

    private float origSpeed;
    // Start is called before the first frame update
    private float maxAttackDistance = 2.0f;
    private  bool caughtPlayer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        caughtPlayer = false;
        origSpeed = agent.speed;
    }

    private void Update()
    {
        agent.SetDestination(player.position);
        Vector3 distToPlayer = player.position - transform.position;
        if (distToPlayer.magnitude < maxAttackDistance && !caughtPlayer)
        {
            caughtPlayer = true;
            agent.speed = 0;
            Time.timeScale = 0;
        }
    }
}