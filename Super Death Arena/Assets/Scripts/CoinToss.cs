using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToss : MonoBehaviour
{
    [SerializeField] int coinDamage;
    [SerializeField] float slowPercent;
    [SerializeField] float slowDuration;
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
        AI aiRef = other.gameObject.GetComponent<AI>();
        if (aiRef != null)
        {
            aiRef.HP -= coinDamage;
            StartCoroutine(aiRef.slowEnemy(slowPercent, slowDuration));
        }
    }
}
