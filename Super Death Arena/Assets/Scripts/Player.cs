using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //handle player stats and behaviours here
{
    public static int health = 100;
    public static float attackSpeed = 0.5f;
    public static int damage = 5;
    public static List<SkillTree.actives> unlockedActives;
    float hitStun;
    public static int experience = 0;
    int levelUp = 100;
    public static int skillPoints = 0;

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
            PlayerPrefs.DeleteAll(); //deletes any saved data between menu scenes like skill points
            //end the game here
            //go to death screen
        }
        if (experience >= levelUp)
        {
            experience -= levelUp;
            skillPoints++;
            levelUp *= 2;
            
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
