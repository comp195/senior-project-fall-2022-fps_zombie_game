using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowlvl2 : MonoBehaviour
{
    public NavMeshAgent enemy;

    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        enemy.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
