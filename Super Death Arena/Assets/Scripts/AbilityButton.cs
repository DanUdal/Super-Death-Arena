using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] SkillTree.actives active = SkillTree.actives.piano;
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
                //add listeners here
            }
        }
        if (ability == 2)
        {
            switch (active)
            {
                //add listeners here
            }
        }
        if (ability == 3)
        {
            switch (active)
            {
                //add listeners here
            }
        }
    }
}
