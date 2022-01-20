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
        float move;
        if(redPlayer)
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
}
