using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public Player player;
    public float AttackDistance;
    public int damage;
    public int health;

    private bool isAttacking;
    private bool isDead;

    public NavMeshAgent agent;

    void Update()
    {
        if (isDead)
            return;

        if(Vector3.Distance(transform.position, player.transform.position) <= AttackDistance)
        {
            agent.isStopped = false;
            // Attack code

        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }

    }

}
