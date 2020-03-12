using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float damage = 10;
    public float damageMulti = 1;




    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Die Orc");

        AI aiRef = col.GetComponent<AI>();
        if (aiRef != null)
        {
            aiRef.HP -= (damage * damageMulti);
        }
        
    }
}
