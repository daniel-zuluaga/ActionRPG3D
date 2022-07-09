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
        if (Vector3.Distance(transform.position, player.transform.position) <= AttackDistance)
        {
            agent.isStopped = true;

            // isAttacking will be disabled 2.66 seconds after each attack.

            if (!isAttacking)
                Attack();
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }

    }

    void Attack()
    {
        isAttacking = true;

        Invoke("TryDamage", 1.3f);

        Invoke("DisableIsAttacking", 2.66f);
    }

    void TryDamage()
    {

        if (Vector3.Distance(transform.position, player.transform.position) <= AttackDistance)
        {
            player.TakeDamage(damage);
        }
    }

    void DisableIsAttacking()
    {
        isAttacking = false;
    }

}
