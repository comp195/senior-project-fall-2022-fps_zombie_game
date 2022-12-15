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
    private NavMeshAgent agent;
    private float origSpeed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        origSpeed = agent.speed;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(player.position);
    }
}