using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{
    public Animator animCont;
    public PlayerMovement playerRef;
    public NavMeshAgent agent;
    public float HP;
    public bool dead;


    public float attackThreshold;
    private bool attacking;

    public Vector3 destination;

    void Update()
    {

        dead = HP <= 0;
        animCont.SetBool("Dead", dead);
        agent.enabled = !dead;
        destination = playerRef.gameObject.transform.position;
        if (agent.enabled = true)
        {
            agent.SetDestination(destination);
        }
        attacking = ((destination - agent.transform.position).magnitude <= attackThreshold);
        animCont.SetBool("Attacking", attacking);
        agent.enabled = !attacking;


        if (dead)
        {
            Destroy(gameObject, 2f);
        }

    }


}

