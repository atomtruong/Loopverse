using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsPlayer, whatIsGround;

    // Attacks
    public float attackSpeed;
    bool attacked;
    public GameObject projectile;
    public Transform attackPoint;

    // States
    public float attackRange;
    public bool playerInAttackRange;

    private void Awake()
    {
        if (gameObject.name != "Enemy1")
        {
            GetComponent<NavMeshAgent>().enabled = true;
            player = GameObject.Find("Player").transform;
            agent = GetComponent<NavMeshAgent>();
            gameObject.GetComponent<EnemyAI>().enabled = true;
        }
    }

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange)
        {
            ChasePlayer();
        } else
        {
            AttackPlayer();
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player, transform.up);

        if (!attacked)
        {
            GameObject currentBullet = Instantiate(projectile, attackPoint.position, Quaternion.identity);
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();

            if (gameObject.name == "Enemy1(Clone)")
            {
                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 4f, ForceMode.Impulse);
            } else if (gameObject.name == "Boss1(Clone)")
            {
                rb.AddForce(transform.forward * 16f, ForceMode.Impulse);
            }

            attacked = true;
            Invoke(nameof(ResetAttack), attackSpeed);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }

    public void GrantStats()
    {
        if (gameObject.name == "Enemy1(Clone)")
            {
            player.GetComponent<PlayerStats>().grantExperience(1);
            player.GetComponent<PlayerStats>().grantMoney(5);
            }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
