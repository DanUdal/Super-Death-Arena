using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoMove : MonoBehaviour
{
    Transform target;
    Rigidbody rigidbody;
    [SerializeField] int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target").GetComponent<Transform>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = gameObject.transform.position - target.position;
        rigidbody.AddForce(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyCollider enemy = other.gameObject.GetComponent<EnemyCollider>();
            enemy.takeDamage(damage); //change value to whatever you want the damage to be
        }
        //perform destruction animation
        Destroy(gameObject);
    }
}
