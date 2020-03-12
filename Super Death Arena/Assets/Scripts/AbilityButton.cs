using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] SkillTree.actives active;
    SkillTree skills;
    public static int ability = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        if (ability == 1)
        {
            switch(active)
            {
                case SkillTree.actives.piano:
                    SkillTree.ability1.AddListener(skills.throwPiano);
                    break;
            }
        }
        if (ability == 2)
        {
            switch (active)
            {
                case SkillTree.actives.piano:
                    SkillTree.ability2.AddListener(skills.throwPiano);
                    break;
            }
        }
        if (ability == 3)
        {
            switch (active)
            {
                case SkillTree.actives.piano:
                    SkillTree.ability3.AddListener(skills.throwPiano);
                    break;
            }
        }
    }
}
