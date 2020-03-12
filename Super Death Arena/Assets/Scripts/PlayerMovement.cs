using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    float xMove;
    float yMove;
    CharacterController character;

    public bool dead;
    public float health = 100;
    public float maxHealth = 100;
    public Weapon weapon;


    public Animator animCont;

    // Start is called before the first frame update
    void Start()
    {
        xMove = 0.0f;
        yMove = 0.0f;
        character = gameObject.GetComponent<CharacterController>();

        weapon.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        dead = (health / maxHealth) <= 0;
        animCont.SetBool("Dead", dead);
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(xMove, 0.0f, yMove) * speed;
        animCont.SetFloat("Blend", velocity.magnitude);
        character.Move(velocity);
        weapon.gameObject.GetComponent<BoxCollider>().enabled = animCont.GetBool("Attacking");





        // This is for testing purposes. Could easily substitute the actual controllers later
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");
            animCont.SetBool("Blocking", false);
            animCont.SetBool("Attacking", true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Block");
            animCont.SetBool("Attacking", false);
            animCont.SetBool("Blocking", true);

        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            //open pause menu with open scene
        }

    }
    //Animation events to prevent looping
    public void endAttack()
    {
        Debug.Log("End of attack");
        animCont.SetBool("Attacking", false);
    }


    public void endBlock()
    {
        Debug.Log("End Block");
        animCont.SetBool("Blocking", false);
    }
}
