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
    [SerializeField] int maxPoints;
    int points;

    // Start is called before the first frame update
    void Start()
    {
        points = PlayerPrefs.GetInt(gameObject.name, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(gameObject.name, points);
    }

    public void increaseDamage()
    {
        if (points < maxPoints)
        {
            Player.damage += damageIncrease; //flat addition to damage
            points++;
            Player.skillPoints--;
        }
    }

    public void increaseAttackSpeed()
    {
        if ((points < maxPoints) && (Player.skillPoints > 0))
        {
            Player.attackSpeed *= attackSpeedBoost; //multiplicative attack speed increase
            points++;
            Player.skillPoints--;
        }
    }

    public void increaseSpeed()
    {
        if ((points < maxPoints) && (Player.skillPoints > 0))
        {
            PlayerMovement.speed *= speedBoost; //multiplicative speed incerase. movement speed
            points++;
            Player.skillPoints--;
        }
    }

    public void increaseHealth()
    {
        if ((points < maxPoints) && (Player.skillPoints > 0))
        {
            Player.health += healthIncrease; //additive health increase
            points++;
            Player.skillPoints--;
        }
    }

    public void unlockActive()
    {
        if ((points < maxPoints) && (Player.skillPoints > 0))
        {
            Player.unlockedActives.Add(activeUnlock); //select the ability you want from the list
            points++;
            Player.skillPoints--;
        }
    }
}
