using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
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
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        character.Move((new Vector3(xMove, 0.0f, yMove)) * speed);
    }
}
