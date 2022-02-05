using UnityEngine.InputSystem;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{

    private InputActionScript inputScript;
    private Rigidbody2D rb;
    private Vector2 move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputScript = new InputActionScript();
        inputScript.PlayerControl.Enable();

        inputScript.PlayerControl.Jump.performed += OnJump;
        inputScript.PlayerControl.Tug.performed += OnTug;
        inputScript.PlayerControl.Connect.performed += OnConnnect;
        inputScript.PlayerControl.Disconnect.performed += OnDisconnect;
        inputScript.PlayerControl.Stick.performed += OnStick;
    }


    private void FixedUpdate()
    {
        move = inputScript.PlayerControl.Movement.ReadValue<Vector2>();
        rb.AddForce(new Vector2(move.x * Time.fixedDeltaTime * 4500, 0));

        //Cap max speed
        float xCap = Mathf.Clamp(Mathf.Abs(rb.velocity.x), 0, 25);
        rb.velocity = new Vector2(xCap * Mathf.Sign(rb.velocity.x), rb.velocity.y);
    }


    public void OnJump(InputAction.CallbackContext context)
    {
       print("jump" + context.phase);
        rb.AddForce(Vector2.up * 75, ForceMode2D.Impulse);
    }

    public void OnTug(InputAction.CallbackContext context)
    {
        print("Tug" + context.phase);
    }

    public void OnConnnect(InputAction.CallbackContext context)
    {
        print("Connect" + context.phase);
    }
    public void OnDisconnect(InputAction.CallbackContext context)
    {
        print("Disconnect" + context.phase);
    }
    public void OnStick(InputAction.CallbackContext context)
    {
        print("Stick" + context.phase);
    }

}
