using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsPlayer, whatIsGround;

    // Attacks
    public float attackSpeed;
    bool attacked;
    public GameObject projectile;
    public Transform attackPoint;

    // Dashing
    public float dashForce;

    // States
    public float attackRange;
    public bool playerInAttackRange;

    private bool dashing;

    private void Awake()
    {
        if (gameObject.name != "Boss1" && gameObject.name != "Boss2")
        {
            GetComponent<NavMeshAgent>().enabled = true;
            player = GameObject.Find("Player").transform;
            agent = GetComponent<NavMeshAgent>();
            gameObject.GetComponent<BossAI>().enabled = true;
            dashing = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange)
        {
            ChasePlayer();
        }
        else
        {
            AttackPlayer();
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        if(gameObject.name == "Boss2(Clone)")
        {
            Animator anim = gameObject.GetComponent<Animator>();
            anim.SetTrigger("WalkForward");
        }

    }

    private void AttackPlayer()
    {
        if (gameObject.name == "Boss1(Clone)")
        {
            agent.SetDestination(transform.position);
        }

        transform.LookAt(player, transform.up);


        if (!attacked)
        {
            if (gameObject.name == "Boss1(Clone)")
            {
                GameObject currentBullet = Instantiate(projectile, attackPoint.position, Quaternion.identity);
                Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
                if (gameObject.name == "Boss1(Clone)")
                {
                    rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                }
                attacked = true;
                if (dashing == false)
                {
                    Invoke(nameof(Dash), 0.5f);
                }
                Invoke(nameof(ResetAttack), attackSpeed);
            }

            if (dashing == false)
            {
                Invoke(nameof(Dash), 0.5f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !attacked)
        {
            collision.gameObject.GetComponent<Health>().ChangeHealth(-40);
            attacked = true;
            Debug.Log("COLLIDED WITH BEAR");
            Invoke(nameof(ResetAttack), attackSpeed);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }

    private void Dash()
    {
        dashing = true;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        int rand = Random.Range(0, 2);

        if (gameObject.name == "Boss1(Clone)")
        {
            if (rand == 0)
            {
                rb.AddForce(-transform.right * dashForce, ForceMode.Impulse);

            }
            else
            {
                rb.AddForce(transform.right * dashForce, ForceMode.Impulse);


            }

        } else if (gameObject.name == "Boss2(Clone)")
        {
            rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
            Animator anim = gameObject.GetComponent<Animator>();
            anim.SetTrigger("Attack3");
        }

        Invoke(nameof(DashReset), 2f);
    }

    private void DashReset()
    {
        dashing = false;
    }

    public void GrantStats()
    {
        if (gameObject.name == "Boss1(Clone)")
        {
            player.GetComponent<PlayerStats>().grantExperience(5);
            player.GetComponent<PlayerStats>().grantMoney(25);
        } else if (gameObject.name == "Boss2(Clone)")
        {
            player.GetComponent<PlayerStats>().grantExperience(10);
            player.GetComponent<PlayerStats>().grantMoney(50);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
