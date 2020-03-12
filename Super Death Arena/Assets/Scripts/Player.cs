using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //handle player stats and behaviours here
{
    public static int health = 100;
    public static float attackSpeed;
    public static int damage;
    public static List<SkillTree.actives> unlockedActives;
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
            //end the game here
            //go to death screen
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        WeaponHitbox enemy = other.gameObject.GetComponent<WeaponHitbox>();
        if ((other.gameObject.tag == "Weapon") && (hitStun <= 0.05) && (enemy != null))
        {
            health -= enemy.damage;
            hitStun = enemy.attackSpeed;
        }
    }
}
