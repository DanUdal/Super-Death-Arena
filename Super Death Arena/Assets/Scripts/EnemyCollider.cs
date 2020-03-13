using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    int health;
    float hitStun;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitStun > 0)
        {
            hitStun -= Time.deltaTime;
        }
        if (health <= 0)
        {
            //kill this enemy. put any death animation here
             //repeat this line of code for each experience orb and change their transform
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Weapon") && (hitStun < 0.05))
        {
            takeDamage(Player.damage);
            hitStun = Player.attackSpeed;
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    
}
