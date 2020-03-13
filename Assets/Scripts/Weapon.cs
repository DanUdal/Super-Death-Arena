using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float hitStun;
    [SerializeField] float attackSpeed;
    [SerializeField] int damage;

    void Update()
    {
        if (hitStun > 0)
        {
            hitStun -= Time.deltaTime;
        }
    }


    void OnTriggerEnter(Collider col)
    {
        

        AI aiRef = col.gameObject.GetComponent<AI>();
        if (aiRef != null)
        {
            aiRef.HP -= Player.damage;
            hitStun = Player.attackSpeed;
            Debug.Log("Die Orc");
        }
        
    }
}
