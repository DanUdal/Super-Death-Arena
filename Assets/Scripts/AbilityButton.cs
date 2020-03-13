using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] SkillTree.actives active;
    SkillTree skills;
    public static int ability = 1;
    UnityAction skillFunction;

    // Start is called before the first frame update
    void Start()
    {
        switch (active)
        {
            case SkillTree.actives.piano:
                skillFunction += skills.throwPiano;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        if (ability == 1)
        {
            SkillTree.ability1.AddListener(skillFunction);
        }
        if (ability == 2)
        {
            SkillTree.ability2.AddListener(skillFunction);
        }
        if (ability == 3)
        {
            SkillTree.ability3.AddListener(skillFunction);
        }
    }
}
