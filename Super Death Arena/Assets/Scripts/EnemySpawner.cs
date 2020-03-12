using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Transform transform;
    GameObject enemy;
    public static List<GameObject> enemies;
    float attackSpeed = 0;
    float speed = 0;
    int damage = 0;
    int health = 0;
    int number = 3;
    [SerializeField] float speedMult = 1.1f;
    [SerializeField] float attackSpeedMult = 1.1f; //do not make less than 1
    [SerializeField] int damageIncrease = 1;
    [SerializeField] int healthIncrease = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0)
        {
            //instantiate some next wave button that calls the spawn enemies function when clicked
        }
    }

    public void spawnEnemies()
    {
        GameObject currentEnemy;
        EnemyCollider collider;
        for (int i = 0; i < number; i++)
        {
            currentEnemy = Instantiate(enemy, transform);
            enemies.Add(currentEnemy);
            collider = currentEnemy.GetComponent<EnemyCollider>();
            collider.increaseStats(attackSpeed, damage, health, speed);
        }
    }

    public void waveEnd()
    {
        attackSpeed *= attackSpeedMult;
        speed *= speedMult;
        health += healthIncrease;
        damage += damageIncrease;
        number++;
    }
}
