using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{
    [SerializeField] Animator animCont;
    [SerializeField] PlayerMovement playerRef;
    GameObject player;
    Transform position;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] public int HP = 10;
    [SerializeField] float speed = 0.2f;
    [SerializeField] WeaponHitbox weapon;
    [SerializeField] bool dead;
    [SerializeField] GameObject experienceOrb;
    bool spawnedCoin = false;


    [SerializeField] float attackThreshold = 8f;
    bool attacking;

    [SerializeField] Vector3 destination;

    void Start()
    {
        
        player = GameObject.Find("footman_Blue_Polyart");
        playerRef = player.GetComponent<PlayerMovement>();
        position = gameObject.GetComponent<Transform>();
        speed = 0.5f;
        attackThreshold = 5f;
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
            if (!spawnedCoin)
            {
                spawnedCoin = true;
                Instantiate(experienceOrb, gameObject.transform);
            }
            Destroy(gameObject, 2f);
            EnemySpawner.enemies--;
        }
        if (gameObject.transform.position.y < 12.5)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 12.5f, gameObject.transform.position.z);
        }

    }

    public void increaseStats(float bonusAttackSpeed, int bonusDamage, int bonusHealth, float bonusSpeed)
    {
        //weapon = gameObject.GetComponent<WeaponHitbox>();
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

