using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int jumpForce = 5000;
    [SerializeField] int speed;
    //[SerializeField] int gravity = 100;
    [SerializeField] int tugForce;
    [SerializeField] int attackForce;
    [SerializeField] float tugCooldown;
    [SerializeField] float maxSpeed;
    [SerializeField] bool redPlayer;
    [SerializeField] Rigidbody2D endOfCord;
    public List<GameObject> allCordJoints = new List<GameObject>();
    Rigidbody2D rb;
    PlayerController otherPlayer;
    bool canTug = true;
    bool grounded;
    [SerializeField] LayerMask ground;
    [SerializeField] SpriteShapeRenderer ropeSprite;
    /// <summary>
    /// Declare local variables
    /// </summary>
    private void Start()
    {
        canTug = true;
        rb = GetComponent<Rigidbody2D>();

        //Find the player that isn't us
        foreach (PlayerController player in FindObjectsOfType<PlayerController>())
        {
            if (player != this)
            {
                otherPlayer = player;
                break;
            }
        }
        
        if(redPlayer)
        {
            endOfCord = allCordJoints[allCordJoints.Count - 1].GetComponent<Rigidbody2D>();
        }
        else
        {
            endOfCord = allCordJoints[0].GetComponent<Rigidbody2D>();
        }
    }

    /// <summary>
    /// Physics movement
    /// </summary>
    void FixedUpdate()
    {
        grounded = Physics2D.Raycast((Vector2)transform.position, Vector2.down, 1.25f, ground);

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

        //Cap max speed
       rb.velocity = rb.velocity.normalized * Mathf.Clamp(rb.velocity.magnitude, 0, maxSpeed);
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
            if (Input.GetKeyDown(KeyCode.W) && grounded)
            {
                if(Connected())
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    //rb.velocity += Vector2.up * jumpForce;
                }
                else
                {

                    rb.AddForce(Vector2.up * jumpForce / 2, ForceMode2D.Impulse);
                    //rb.velocity += Vector2.up * jumpForce * 2;
                }
            }

            //Get heavier on press
            if (Input.GetKeyDown(KeyCode.S) && grounded)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            //Lighter on lift up
            else if (Input.GetKeyUp(KeyCode.S))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            //Attack
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Attack();
            }
            //Tug
            if(Input.GetKeyDown(KeyCode.LeftShift) && canTug)
            {
                Tug();
            }
        }

        //Blue Stuff
        else
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                if (Connected())
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    //rb.velocity += Vector2.up * jumpForce;
                }
                else
                {

                    rb.AddForce(Vector2.up * jumpForce * 2, ForceMode2D.Impulse);
                    //rb.velocity += Vector2.up * jumpForce * 2;
                }
            }
            //Get heavier on press
            if (Input.GetKeyDown(KeyCode.DownArrow) && grounded)
            {

                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            //Lighter on lift up
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            //Attack
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Attack();
            }
            //Tug
            if (Input.GetKeyDown(KeyCode.RightShift) && canTug)
            {
                Tug();
            }
        }

       /* if(!grounded)
        {
            rb.AddRelativeForce(new Vector2(rb.velocity.x, 0));
            Invoke("Gravity", 0.01f);
        }*/
    }

    /*void Gravity()
    {
        //Constant Gravity Modifier
        rb.velocity += new Vector2(0, -gravity * Time.deltaTime);
    }*/

    void Tug()
    {
        Vector2 direction = transform.position - endOfCord.transform.position;
        direction = direction.normalized;
        endOfCord.AddForce(direction * tugForce);
        canTug = false;
        StartCoroutine(TugCooldown());
    }

    IEnumerator TugCooldown()
    {
        yield return new WaitForSeconds(tugCooldown);
        canTug = true;
    }

    /// <summary>
    /// While connected, this disconnects the players
    /// While seperate this can be used to attack, or reconnect the players
    /// </summary>
    void Attack()
    {
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
        PlayerController blue = this;
        if (redPlayer)
        {
            blue = otherPlayer;
        }

        //Reactivate objects going from red -> blue
        //Has to be done in this order otherwise the cord will break
        foreach (GameObject obj in blue.otherPlayer.allCordJoints)
        {
            obj.transform.position = blue.otherPlayer.transform.position;
            obj.SetActive(true);
        }

        foreach (GameObject obj in blue.allCordJoints)
        {
            obj.transform.position = blue.transform.position;
            obj.SetActive(true);
        }

        blue.GetComponent<HingeJoint2D>().enabled = true;

        ropeSprite.enabled = true;


       // blue.otherPlayer.allCordJoints[0].transform.position = blue.otherPlayer.transform.position + new Vector3(.5f, 0);

        //If we end up physically splitting the cord this code will be needed

        //partToConnect.GetComponent<HingeJoint2D>().enabled = true;

    }

    void Disconnect()
    {

        //Figure out who is blue
        PlayerController blue = this;
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
        ropeSprite.enabled = false;
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