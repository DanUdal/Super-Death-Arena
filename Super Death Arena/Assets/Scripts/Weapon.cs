using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float hitStun;

    void Update()
    {
        if (hitStun > 0)
        {
            hitStun -= Time.deltaTime;
        }
    }


    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Die Orc");

        AI aiRef = col.GetComponent<AI>();
        if ((col.gameObject.tag == "Weapon") && (hitStun < 0.05) && (aiRef != null))
        {
            aiRef.HP -= Player.damage;
            hitStun = Player.attackSpeed;
        }
        
    }
}
