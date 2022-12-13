using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;

    public Transform Player; // Update is called once per frame
    private float Health = 100f;
    [SerializeField] private TextMeshProUGUI HealthText;

    public void Update()
    {
        EnemyChase();

    }

    private void EnemyChase()
    {
        enemy.SetDestination(Player.position);
    }

    

}