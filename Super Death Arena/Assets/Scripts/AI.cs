using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{
    [SerializeField] Animator animCont;
    [SerializeField] PlayerMovement playerRef;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] public int HP = 10;
    [SerializeField] float speed = 0.2f;
    WeaponHitbox weapon;
    [SerializeField] bool dead;
    [SerializeField] GameObject experienceOrb;


    [SerializeField] float attackThreshold;
    bool attacking;

    [SerializeField] Vector3 destination;

    void Start()
    {
        weapon = gameObject.GetComponent<WeaponHitbox>();
    }

    void Update()
    {

        dead = HP <= 0;
        animCont.SetBool("Dead", dead);
        agent.enabled = !dead;
        destination = playerRef.gameObject.transform.position;
        agent.speed = speed;
        if (agent.enabled == true)
        {
            agent.SetDestination(destination);
        }
        attacking = ((destination - agent.transform.position).magnitude <= attackThreshold);
        animCont.SetBool("Attacking", attacking);
        agent.enabled = !attacking;


        if (dead)
        {
            Instantiate(experienceOrb, gameObject.transform);
            Destroy(gameObject, 2f);
        }

    }

    public void increaseStats(float bonusAttackSpeed, int bonusDamage, int bonusHealth, float bonusSpeed)
    {
        HP += bonusHealth;
        speed *= bonusSpeed;
        weapon.attackSpeed *= bonusAttackSpeed;
        weapon.damage += bonusDamage;
    }

    public IEnumerator slowEnemy(float slowPercent, float timeDelay)
    {
        speed *= slowPercent;
        yield return new WaitForSeconds(timeDelay);
        speed /= slowPercent;
    }
}

