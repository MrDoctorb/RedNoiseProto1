using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int jumpForce = 5000;
    [SerializeField] int speed;
    [SerializeField] int gravity = 100;
    [SerializeField] int tugForce;
    [SerializeField] int attackForce;
    [SerializeField] float reelSpeed;
    [SerializeField] float tugCooldown;
    [SerializeField] float maxSpeed;
    [Range(0f, 1f)] [SerializeField] float slowdownRate;
    public bool redPlayer;
    [SerializeField] Rigidbody2D endOfCord;
    [SerializeField] GameObject plug;
    public List<GameObject> allCordJoints = new List<GameObject>();
    Rigidbody2D rb;
    PlayerController otherPlayer;
    bool canTug = true;
    bool grounded;
    Vector2 stickPos;
    [SerializeField] LayerMask ground;
    [SerializeField] SpriteShapeRenderer ropeSprite;
    [SerializeField] GameObject spawn;
    /// <summary>
    /// Declare local variables
    /// </summary>
    /// 

    public void JumpTest()
    {
        print("jump");
    }

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

        endOfCord = allCordJoints[allCordJoints.Count - 1].GetComponent<Rigidbody2D>();

        if (redPlayer)
        {
            GameObject end = Instantiate(plug, endOfCord.transform.position, endOfCord.transform.rotation);
            end.transform.SetParent(endOfCord.transform);
        }
        else
        {
            GameObject end = Instantiate(plug, endOfCord.transform.position, endOfCord.transform.rotation);
            end.transform.SetParent(endOfCord.transform);
        }

        if(!redPlayer)
        {
            DistanceJoint2D connector = endOfCord.gameObject.AddComponent<DistanceJoint2D>();
            connector.autoConfigureDistance = false;
            connector.connectedBody = otherPlayer.endOfCord;
            connector.distance = 0;
            connector.enabled = false;
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
            if (Connected())
            {
                rb.AddForce(new Vector2(move * Time.fixedDeltaTime * speed, 0));
            }
            else
            {
                rb.AddForce(new Vector2(move * Time.fixedDeltaTime * (speed / 2), 0));
            }

            //Cap max speed
            float xCap = Mathf.Clamp(Mathf.Abs(rb.velocity.x), 0, maxSpeed);
            rb.velocity = new Vector2(xCap * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, slowdownRate), rb.velocity.y);
        }

        //Keep players in the camera
        Vector2 boundingPos = transform.position;
        Vector2 cameraPos = Camera.main.transform.position;
        float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        boundingPos.x = Mathf.Clamp(boundingPos.x, cameraPos.x - halfWidth, cameraPos.x + halfWidth);
        boundingPos.y = Mathf.Clamp(boundingPos.y, cameraPos.y - Camera.main.orthographicSize, cameraPos.y + Camera.main.orthographicSize);

        transform.position = boundingPos;

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
                if (Connected())
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
                stickPos = transform.position;
            }
            else if(Input.GetKey(KeyCode.S) && grounded)
            {
                transform.position = stickPos;
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
            if (Input.GetKeyDown(KeyCode.LeftShift) && canTug)
            {
                Tug();
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                Reel();
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

                    rb.AddForce(Vector2.up * jumpForce / 2, ForceMode2D.Impulse);
                    //rb.velocity += Vector2.up * jumpForce * 2;
                }
            }
            //Get heavier on press
            if (Input.GetKeyDown(KeyCode.DownArrow) && grounded)
            {

                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                stickPos = transform.position;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && grounded)
            {
                transform.position = stickPos;
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
            else if(Input.GetKey(KeyCode.RightShift))
            {
                Reel();
            }
        }

        if (!grounded)
        {
            Invoke("Gravity", 0.01f);
        }
    }

    void Gravity()
    {
        //Constant Gravity Modifier
        rb.velocity += new Vector2(0, -gravity * Time.deltaTime);
    }

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

    void Reel()
    {
        Vector2 direction = transform.position - endOfCord.transform.position;
        direction = direction.normalized;
        endOfCord.AddForce(direction * reelSpeed * Time.deltaTime);
        rb.AddForce(-direction * reelSpeed * Time.deltaTime);
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
                && Vector2.Distance(transform.position, otherPlayer.transform.position) <= 5)
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
        /*foreach (GameObject obj in blue.otherPlayer.allCordJoints)
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

        ropeSprite.enabled = true;*/


        // blue.otherPlayer.allCordJoints[0].transform.position = blue.otherPlayer.transform.position + new Vector3(.5f, 0);

        //If we end up physically splitting the cord this code will be needed

        blue.endOfCord.GetComponent<DistanceJoint2D>().enabled = true;
        blue.endOfCord.GetComponent<DistanceJoint2D>().connectedBody = blue.otherPlayer.endOfCord;
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

        blue.endOfCord.GetComponent<DistanceJoint2D>().enabled = false;


        //Turn off all cord joins, order doesn't matter
       /* foreach (GameObject obj in allCordJoints)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in otherPlayer.allCordJoints)
        {
            obj.SetActive(false);
        }

        blue.GetComponent<HingeJoint2D>().enabled = false;
        ropeSprite.enabled = false;*/
    }

    bool Connected()
    {
        //Check to see if the end of blue's cord is connected or active
        Rigidbody2D partToCheck = endOfCord;
        if (redPlayer)
        {
            partToCheck = otherPlayer.endOfCord;
        }
        return partToCheck.GetComponent<DistanceJoint2D>().isActiveAndEnabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            gameObject.transform.position = spawn.transform.position;
        }
    }
}