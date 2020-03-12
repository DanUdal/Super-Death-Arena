using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillTree : MonoBehaviour
{
    // Start is called before the first frame update

    public enum actives { piano, coinToss };
    public static UnityEvent ability1;
    public static UnityEvent ability2;
    public static UnityEvent ability3;
    [SerializeField] GameObject target;
    [SerializeField] GameObject piano;

    void Start()
    {
        if (ability1 == null)
        {
            ability1 = new UnityEvent();
        }
        if (ability2 == null)
        {
            ability2 = new UnityEvent();
        }
        if (ability3 == null)
        {
            ability3 = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            ability1.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            ability2.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            ability3.Invoke();
        }
    }

    public void throwPiano()
    {
        Instantiate(target, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(piano, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}
