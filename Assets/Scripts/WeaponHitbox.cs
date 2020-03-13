using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    public int damage = 20;
    public float attackSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player playerRef = other.gameObject.GetComponent<Player>();
        if (playerRef != null)
        {
            Player.health -= damage;
            Debug.Log("Player hit");
        }
    }
}
