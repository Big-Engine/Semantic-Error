using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [Header("Player Velocity")]
    private float inputDirection;
    private Vector3 moveVector;
    private Vector3 velocity;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float fallForce = -10.0f;
    private CharacterController characterController;

    [Header("Player Controls")]
    //isActive determines if the player can move at all. Use it to freeze the player.
    public bool isActive = true;
    [SerializeField] private bool isWallJumping = false;
    public float playerSpeed = 10.0f;
    public float jumpForce = 10.0f;
    public bool doubleJumpEnabled = false;
    [SerializeField] private bool canDoubleJump = false;

    //These are used to check if the player is standing on anything in the "Ground" Layer.
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField] private bool isGrounded;

    //Player Animations
    Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //This casts a sphere at the bottom of the player. If they're on anything in the Ground layer, this becomes true.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        //This resets the player's downward velocity to -5.0f so they fall quickly when walking off ledges.
        {
            velocity.y = -5.0f;
            CheckForDoubleJumpPermisson();
        }
        


        
        if(isActive && !isWallJumping)
        //If the player is allowed to move, use InputDirection to go left and right.
        {
            inputDirection = Input.GetAxis("Horizontal");
            //moveVector = new Vector3(inputDirection, 0f, 0f);
        }
        
        if (!isActive)
        //Don't allow the player to move.
        {
            //moveVector = new Vector3(0, 0, 0);
            inputDirection = 0;
        }

        moveVector = new Vector3(inputDirection, 0f, 0f);

        //Applies horizontal forces to the player.
        characterController.Move(moveVector * playerSpeed * Time.deltaTime);

        //This causes the player to jump when standing on the ground.
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && isActive)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            CheckForDoubleJumpPermisson();
        }

        //This causes a double jump if the player is not on the ground but has a reserved double jump.
        if(Input.GetKeyDown(KeyCode.Space) && !isGrounded && canDoubleJump && isActive)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            canDoubleJump = false;
        }

        //If the player lets go of the jump button before they reach the peak of their jump, they will instead
        //prematurely end their jump (Basically allows short jumps).
        if(velocity.y > 0 && !Input.GetKey(KeyCode.Space) && isActive)
        {
            velocity.y += fallForce * Time.deltaTime;
        }

        //This pulls the player downwards.
        velocity.y += gravity * Time.deltaTime;

        AnimationHandler();
        //Applies vertical forces to the player.
        characterController.Move(velocity * Time.deltaTime);
    }

    private void AnimationHandler()
    //Handles the animations. Leave this alone or risk breaking everything!
    {
        //Declaration of variables within the Animator Controller.
        bool isWalkingRight = animator.GetBool("isWalkingRight");
        bool isWalkingLeft = animator.GetBool("isWalkingLeft");
        bool isPlayerGrounded = animator.GetBool("isPlayerGrounded");

        //Updates velocity float in the animator.
        animator.SetFloat("playerVelocity", velocity.y);

        animator.SetBool("isPlayerGrounded", true);
        if(isGrounded)
        {
            animator.SetBool("isPlayerGrounded", true);
        }
        else
        {
            animator.SetBool("isPlayerGrounded", false);
        }

        if(inputDirection > 0.1 && !isWalkingRight && isPlayerGrounded)
        {
            animator.SetBool("isWalkingRight", true);
            animator.SetBool("isWalkingLeft", false);
            //Debug.Log("Right");
        }
        else if(inputDirection < -0.1 && !isWalkingLeft && isPlayerGrounded)
        {
            animator.SetBool("isWalkingLeft", true);
            animator.SetBool("isWalkingRight", false);
            //Debug.Log("Left");
        }
        else if (inputDirection == 0 && (isWalkingRight || isWalkingLeft))
        {
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
            //Debug.Log("Neither");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    //This handles events for colliding with other objects.
    {
        if (!characterController.isGrounded && hit.normal.y < 0.1f)
        //If the player is touching a wall and they're not on the ground...
        {
            if(velocity.y < 0)
            //Check if the player has negative velocity and set it to -5 so they slide down walls.
            {
                velocity.y = -5.0f;
            }

            if(Input.GetKeyDown(KeyCode.Space))
            //And if they press jump...
            {
                //They perform a wall jump and reenable their double jump.
                velocity.y = Mathf.Sqrt((jumpForce/2) * -2.0f * gravity);

                inputDirection = hit.normal.x;
                isWallJumping = true;
                StartCoroutine(WallJumpCoroutine());
            }
        }
    }

    IEnumerator WallJumpCoroutine()
    //Freezes the player for a brief moment to allow the wall jump to push them back.
    {
        yield return new WaitForSeconds(0.3f);
        isWallJumping = false;
    }

    private void CheckForDoubleJumpPermisson()
    {
        if(doubleJumpEnabled)
        {
            canDoubleJump = true;
        }
    }
}
