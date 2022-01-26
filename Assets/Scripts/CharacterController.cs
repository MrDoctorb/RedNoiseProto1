using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] int jumpForce = 1000;
    [SerializeField] int speed;
    [SerializeField] int tugForce;
    [SerializeField] int attackForce;
    [SerializeField] bool redPlayer;
    public Rigidbody2D endOfCord;
    [SerializeField] GameObject[] allCordJoints;
    Rigidbody2D rb;
    CharacterController otherPlayer;
    [SerializeField] LayerMask ground;
    /// <summary>
    /// Declare local variables
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Find the player that isn't us
        foreach (CharacterController player in FindObjectsOfType<CharacterController>())
        {
            if (player != this)
            {
                otherPlayer = player;
                break;
            }
        }
    }

    /// <summary>
    /// Physics movement
    /// </summary>
    void FixedUpdate()
    {
        //Uses different controls to differentiate characters
        float move = 0;
        if (redPlayer)
        {
            move = Input.GetAxis("Horizontal");

        }
        else
        {
            move = Input.GetAxis("Horizontal2");

        }

        //As long as there is some input, move
        if (move != 0)
        {
            rb.AddForce(new Vector2(move * Time.fixedDeltaTime * speed, 0));
        }
    }

    /// <summary>
    /// Single Button Press input
    /// </summary>
    private void Update()
    {
        //Red Stuff
        if (redPlayer)
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.W) && Physics2D.Raycast((Vector2)transform.position, Vector2.down, 2, ground))
            {
                if(Connected())
                {
                    rb.AddForce(Vector2.up * jumpForce);
                }
                else
                {

                    rb.AddForce(Vector2.up * jumpForce/4);
                }
            }

            //Get heavier on press
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.mass = 100;
            }
            //Lighter on lift up
            else if (Input.GetKeyUp(KeyCode.S))
            {
                rb.mass = 1;
            }
            //Attack
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Attack();
            }
            //Tug
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                Tug();
            }
        }

        //Blue Stuff
        else
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.UpArrow) && Physics2D.Raycast((Vector2)transform.position, Vector2.down, 2, ground))
            {
                if (Connected())
                {
                    rb.AddForce(Vector2.up * jumpForce);
                }
                else
                {

                    rb.AddForce(Vector2.up * jumpForce / 4);
                }
            }
            //Get heavier on press
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.mass = 100;
            }
            //Lighter on lift up
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                rb.mass = 1;
            }
            //Attack
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Attack();
            }
            //Tug
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Tug();
            }
        }

    }

    void Tug()
    {
        Vector2 direction = transform.position - endOfCord.transform.position;
        direction = direction.normalized;
        endOfCord.AddForce(direction * tugForce);
    }


    /// <summary>
    /// While connected, this disconnects the players
    /// While seperate this can be used to attack, or reconnect the players
    /// </summary>
    void Attack()
    {
        print(Connected());
        //If connected, disconnect
        if (Connected())
        {
            Disconnect();
        }


        else
        {
            //Attack Logic
            //TODO add attack logic
            int dir = (int)Mathf.Sign(rb.velocity.x);
            //DO a circle cast in a direction?

            //If both players are holding the attack button and are close to eachother, connect
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightControl)
                && Vector2.Distance(transform.position, otherPlayer.transform.position) <= 3)
            {
                Connect();
            }
        }
    }

    void Connect()
    {
        //Figure out who is blue
        CharacterController blue = this;
        if (redPlayer)
        {
            blue = otherPlayer;
        }

        //Reactivate objects going from red -> blue
        //Has to be done in this order otherwise the cord will break
        foreach (GameObject obj in blue.otherPlayer.allCordJoints)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in blue.allCordJoints)
        {
            obj.SetActive(true);
        }

        blue.GetComponent<HingeJoint2D>().enabled = true;

        //If we end up physically splitting the cord this code will be needed

        //partToConnect.GetComponent<HingeJoint2D>().enabled = true;

    }

    void Disconnect()
    {

        //Figure out who is blue
        CharacterController blue = this;
        if (redPlayer)
        {
            blue = otherPlayer;
        }

        //Use this code if we end up physically splitting the code
        
        //partToDisconnect.GetComponent<HingeJoint2D>().enabled = false;


        //Turn off all cord joins, order doesn't matter
        foreach (GameObject obj in allCordJoints)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in otherPlayer.allCordJoints)
        {
            obj.SetActive(false);
        }

        blue.GetComponent<HingeJoint2D>().enabled = false;
    }

    bool Connected()
    {
        //Check to see if the end of blue's cord is connected or active
        Rigidbody2D partToCheck = endOfCord;
        if (redPlayer)
        {
            partToCheck = otherPlayer.endOfCord;
        }
        return partToCheck.GetComponent<HingeJoint2D>().isActiveAndEnabled;
    }
}