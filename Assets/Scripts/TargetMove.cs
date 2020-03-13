using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    float xMove;
    float yMove;
    CharacterController character;
    // Start is called before the first frame update
    void Start()
    {
        xMove = 0.0f;
        yMove = 0.0f;
        character = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("AimingX");
        yMove = Input.GetAxis("AimingY");
        Vector3 velocity = new Vector3(xMove, 0.0f, yMove) * 0.4f;
        character.Move(velocity);
    }
}
