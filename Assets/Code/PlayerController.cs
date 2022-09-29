using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public int initialMoveSpeed = 4; // how fast the player moves
    public int moveSpeed = 4; // updates when sprinting
    [SerializeField] public int sprintSpeedMultiplier = 2;

    public int score = 0;

    [SerializeField] public int max_stamina = 5000;
    int stamina;
    int sprint_cooldown = 0;
    int stamina_wait = 0;

    public Slider staminaBar;

    [SerializeField] AudioSource footstepsSound;
    [SerializeField] AudioSource sprintSound;
    [SerializeField] AudioSource outOfBreathSound;
    //[SerializeField] public AudioSource pickupSound;
    [SerializeField] AudioSource jumpSound;
    

    [SerializeField] int jumpForce = 300; // ammount of force applied to create a jump
    Rigidbody _rigidbody;

    //float xRotation;
    //float lookSpeedY = 3;

    float yRotationForMovement;
    float lookSpeedX = 3;

    //The physics layers you want the player to be able to jump off of. Just dont include the layer the palyer is on.
    public LayerMask groundLayer;

    public Transform feetTrans; //Position of where the players feet touch the ground
    float groundCheckDist = .5f; //How far down to check for the ground. The radius of Physics.CheckSphere
    public bool grounded = false; //Is the player on the ground

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); // Using GetComponent is expensive. Always do it in start and chache it when you can.
        stamina = max_stamina;
    }

    void FixedUpdate()
    {
        //Creates a movement vector local to the direction the player is facing.
        Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"); // Use GetAxisRaw for snappier but non-analogue  movement
        moveDir *= moveSpeed;
        moveDir.y = _rigidbody.velocity.y; // We dont want y so we replace y with that the _rigidbody.velocity.y already is.
        if (grounded) {_rigidbody.velocity = moveDir;} // Set the velocity to our movement vector

        //The sphere check draws a sphere like a ray cast and returns true if any collider is withing its radius.
        //grounded is set to true if a sphere at feetTrans.position with a radius of groundCheckDist detects any objects on groundLayer within it
        grounded = Physics.CheckSphere(feetTrans.position, groundCheckDist, groundLayer);
    }

    void Update()
    {
        yRotationForMovement += Input.GetAxis("Mouse X") * lookSpeedX;
        //xRotation -= Input.GetAxis("Mouse Y") * lookSpeedY;

        transform.eulerAngles = new Vector3(0, yRotationForMovement, 0);

        //this.Page1.Canvas.text = score;
        
        if (grounded && Input.GetButtonDown("Jump")) //if the player is on the ground and press Spacebar
        {
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0)); // Add a force jumpForce in the Y direction
            stamina -= 500;
            jumpSound.Play();
        }

        staminaBar.value = (float) stamina/max_stamina;

        if (grounded && Input.GetButton("Sprint") && stamina > 0 && sprint_cooldown == 0)
        {
            moveSpeed = initialMoveSpeed * sprintSpeedMultiplier;
            stamina --;
            stamina_wait = 500;
        }
        else 
        {
            if(grounded) {moveSpeed = initialMoveSpeed;}
            if (stamina_wait > 0) {stamina_wait--;}
        }

        if (grounded && stamina < max_stamina && !Input.GetButton("Sprint") && sprint_cooldown <= 750 && stamina_wait == 0)
        {
            stamina ++;
        }

        if (stamina == 0 && sprint_cooldown == 0) {sprint_cooldown = 2000;}
        
        if (sprint_cooldown > 0)
        {
            sprint_cooldown --;
            outOfBreathSound.enabled = true;
        }
        else {outOfBreathSound.enabled = false;}

        if(grounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.LeftShift) && sprint_cooldown == 0)
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
