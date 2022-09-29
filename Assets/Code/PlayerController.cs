using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool PlayerControlAllowed = true;

    [SerializeField] public int initialMoveSpeed = 4; // how fast the player moves
    public int moveSpeed = 4; // updates when sprinting
    [SerializeField] public int sprintSpeedMultiplier = 2;

    [SerializeField] AudioSource footstepsSound;
    [SerializeField] AudioSource sprintSound;

    [SerializeField] int jumpForce = 300; // ammount of force applied to create a jump
    Rigidbody _rigidbody;

    float xRotation;
    float lookSpeedY = 3;

    float yRotation;
    float lookSpeedX = 3;

    //The physics layers you want the player to be able to jump off of. Just dont include the layer the palyer is on.
    public LayerMask groundLayer;

    public Transform feetTrans; //Position of where the players feet touch the ground
    float groundCheckDist = .5f; //How far down to check for the ground. The radius of Physics.CheckSphere
    public bool grounded = false; //Is the player on the ground

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); // Using GetComponent is expensive. Always do it in start and chache it when you can.
    }

    void FixedUpdate()
    {
        if(PlayerControlAllowed){
        //Creates a movement vector local to the direction the player is facing.
        Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"); // Use GetAxisRaw for snappier but non-analogue  movement
        moveDir *= moveSpeed;
        moveDir.y = _rigidbody.velocity.y; // We dont want y so we replace y with that the _rigidbody.velocity.y already is.
        _rigidbody.velocity = moveDir; // Set the velocity to our movement vector

        //The sphere check draws a sphere like a ray cast and returns true if any collider is withing its radius.
        //grounded is set to true if a sphere at feetTrans.position with a radius of groundCheckDist detects any objects on groundLayer within it
        grounded = Physics.CheckSphere(feetTrans.position, groundCheckDist, groundLayer);
        }
    }

    void Update()
    {
        if(PlayerControlAllowed){
        yRotation += Input.GetAxis("Mouse X") * lookSpeedX;
        xRotation -= Input.GetAxis("Mouse Y") * lookSpeedY;
        xRotation = Mathf.Clamp(xRotation, -90, 90); //Keeps up/down head rotation realistic

        transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
        
        if (grounded && Input.GetButtonDown("Jump")) //if the player is on the ground and press Spacebar
        {
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0)); // Add a force jumpForce in the Y direction
        }

        if (grounded && Input.GetButton("Sprint"))
        {
            moveSpeed = initialMoveSpeed * sprintSpeedMultiplier;
        }
        else
        {
            moveSpeed = initialMoveSpeed;
        }

        if(grounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = true;
                sprintSound.enabled = false;
            }
        }
        else
        {
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }
        }

    }
}
