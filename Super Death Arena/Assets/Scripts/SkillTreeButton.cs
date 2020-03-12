using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeButton : MonoBehaviour
{
    [SerializeField] int damageIncrease;
    [SerializeField] float attackSpeedBoost;
    [SerializeField] float speedBoost;
    [SerializeField] int healthIncrease;
    [SerializeField] SkillTree.actives activeUnlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseDamage()
    {
        Player.damage += damageIncrease; //flat addition to damage
    }

    public void increaseAttackSpeed()
    {
        Player.attackSpeed *= attackSpeedBoost; //multiplicative attack speed increase
    }

    public void increaseSpeed()
    {
        PlayerMovement.speed *= speedBoost; //multiplicative speed incerase. movement speed
    }

    public void increaseHealth()
    {
        Player.health += healthIncrease; //additive health increase
    }

    public void unlockActive()
    {
        Player.unlockedActives.Add(activeUnlock); //select the ability you want from the list
    }
}
