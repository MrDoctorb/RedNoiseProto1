using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int speed;
    [SerializeField] bool redPlayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float move = 0;
        if (redPlayer)
        {
            move = Input.GetAxis("Horizontal");

        }
        else
        {
            move = Input.GetAxis("Horizontal2");

        }
        if (move != 0)
        {
            rb.AddForce(new Vector2(move * Time.fixedDeltaTime * speed, 0));
        }
    }

    private void Update()
    {
        if(redPlayer)
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                rb.mass = 100;
            }
            else if(Input.GetKeyUp(KeyCode.S))
            {
                rb.mass = 1;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.mass = 100;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                rb.mass = 1;
            }
        }

    }
}
