using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [Header("Player Velocity")]
    private float inputDirection;
    private Vector3 moveVector;
    public Vector3 conveyorVector;
    private Vector3 velocity;
    private Vector3 trueVelocity;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float fallForce = -10.0f;
    [SerializeField] private float terminalVelocity = -50.0f;
    //Set this to public so it's accessible through other scripts.
    public CharacterController characterController;
    //reference to player audio sfx script
    private Audio_PlayerSFX playerSFX;
    //reference to the black screen for dying
    private GameObject blackScreen;
    private FadeToBlack blackScreenScript;

    [Header("Player Controls")]
    //isActive determines if the player can move at all. Use it to freeze the player.
    public bool isActive = true;
    private bool isWallJumping = false;
    public bool isWallSliding = false;
    private float wallDirection;
    public float playerSpeed = 10.0f;
    public float turnSpeed = 0.0f;
    public float jumpForce = 10.0f;
    public bool doubleJumpEnabled = false;
    [SerializeField] private bool canDoubleJump = false;
    private bool hasSprung = false;
    private bool isReversed = false;

    //These are used to check if the player is standing on anything in the "Ground" Layer.
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public bool isMoving;

    //Player Animations
    Animator animator;

    [Header("Respawn System")]
    //Handles variables for the player's respawn point.
    public Vector3 currentRespawnLocation;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerSFX = GetComponent<Audio_PlayerSFX>();
        blackScreen = GameObject.FindGameObjectWithTag("BlackScreen");
        blackScreenScript = blackScreen.GetComponent<FadeToBlack>();

        //Sets the player's respawn point to their starting location.
        //Used for level design and debugging.
        currentRespawnLocation = characterController.transform.position;
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
        
        if(velocity.y < terminalVelocity)
        {
            velocity.y = terminalVelocity;
        }
        
        if(isActive && !isWallJumping)
        //If the player is allowed to move, use InputDirection to go left and right.
        {
            inputDirection = Input.GetAxis("Horizontal");
            //moveVector = new Vector3(inputDirection, 0f, 0f);
        }
        
        if (!isActive)
        //If this is false, don't allow the player to move.
        {
            //moveVector = new Vector3(0, 0, 0);
            inputDirection = 0;
        }

        //moveVector = new Vector3(inputDirection, 0f, 0f);

        moveVector = transform.right * -inputDirection;

        //Combines the player's movement with that of a conveyor belt (If they're standing on one).
        moveVector += conveyorVector;

        //Applies horizontal forces to the player.
        characterController.Move(moveVector * playerSpeed * Time.deltaTime);

        //Rotates the player relative to their movement
        if (inputDirection > 0)
        {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }
        else if (inputDirection < 0)
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }

        //This causes the player to jump when standing on the ground.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isActive)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            CheckForDoubleJumpPermisson();

            //play jump sound
            playerSFX.jump1.Play();
        }

        //This causes a double jump if the player is not on the ground but has a reserved double jump.
        if(Input.GetKeyDown(KeyCode.Space) && !isGrounded && canDoubleJump && isActive)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            canDoubleJump = false;

            //play jump sound 2
            playerSFX.jump2.Play();
        }

        //If the player lets go of the jump button before they reach the peak of their jump, they will instead
        //prematurely end their jump (Basically allows short jumps).
        if(velocity.y > 0 && !Input.GetKey(KeyCode.Space) && !hasSprung && isActive)
        {
            velocity.y += fallForce * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isWallSliding && !isGrounded)
        //If the player presses jump while wall sliding...
        {
            Debug.Log("Tried to wall jump");
            //They perform a wall jump and reenable their double jump.
            velocity.y = Mathf.Sqrt((jumpForce / 1.5f) * -2.0f * gravity);

            inputDirection = wallDirection;
            isWallJumping = true;
            isWallSliding = false;
            StartCoroutine(WallJumpCoroutine());
            //Previously this function was done inside OnControllerColliderHit. I left a comment
            //detailing why it was moved here.

            //play jump sound
            playerSFX.jump1.Play();
        }

        //This pulls the player downwards.
        velocity.y += gravity * Time.deltaTime;

        if(isReversed)
        //When the player's gravity is reversed, invert their velocity.
        {
            trueVelocity = -velocity;
        }
        else
        {
            trueVelocity = velocity;
        }

        AnimationHandler();

        //Applies vertical forces to the player.
        characterController.Move(trueVelocity * Time.deltaTime);
    }

    private void AnimationHandler()
    //Handles the animations. Leave this alone or risk breaking everything!
    //Zack G. - I am using this to also handle player SFX
    {
        //Declaration of variables within the Animator Controller.
        bool isWalkingRight = animator.GetBool("isWalkingRight");
        bool isWalkingLeft = animator.GetBool("isWalkingLeft");

        //Updates velocity float in the animator.
        animator.SetFloat("playerVelocity", velocity.y);

        //Updates the isPlayerGrounded bool in the animator.
        if(isGrounded)
        {
            animator.SetBool("isPlayerGrounded", true);
        }
        else
        {
            animator.SetBool("isPlayerGrounded", false);
        }

        //Determines the direction the player is moving, or if they're not moving at all.
        if(inputDirection > 0.1 && !isWalkingRight)
        {
            animator.SetBool("isWalkingRight", true);
            animator.SetBool("isWalkingLeft", false);
            isMoving = true;
            //Debug.Log("Right");
        }
        else if(inputDirection < -0.1 && !isWalkingLeft)
        {
            animator.SetBool("isWalkingLeft", true);
            animator.SetBool("isWalkingRight", false);
            isMoving = true;
            //Debug.Log("Left");
        }
        else if (inputDirection == 0 && (isWalkingRight || isWalkingLeft))
        {
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
            isMoving = false;
            //Debug.Log("Neither");
        }

        if (velocity.y < -10.0f)
        //Used to determine if the player has let go of a wall without wall jumping.
        {
            isWallSliding = false;
        }

        if (velocity.y > 0)
        //If the player has postive velocity when touching a wall, prevent them from triggering
        //the wall sliding animation.
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            animator.SetBool("isPlayerWallSliding", true);
        }
        else
        {
            animator.SetBool("isPlayerWallSliding", false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    //This handles events for colliding with other objects.
    //Use this for solid collisions (I.E. objects that the player cannot pass through).
    {
        if (!isGrounded && hit.normal.y < 0.001f && hit.normal.y > -0.001f)
        //If the player is touching a wall and they're not on the ground...
        {
            //Debug.DrawRay(hit.point, hit.normal, Color.red, 2.0f);
            if (velocity.y < 0)
            //Check if the player has negative velocity and set it to -5 so they slide down walls.
            {
                velocity.y = -5.0f;
                isWallSliding = true;
                wallDirection = hit.normal.x;
                //wallDirection is used to ensure that the player performs a wall jump every time they
                //press jump. Previously the input was done here, but it was moved because OnControllerColliderHit
                //doesn't always run on every frame.
            }
        }

        if (!characterController.isGrounded && ((hit.normal.y == -1.0f && !isReversed) || (hit.normal.y == 1.0f && isReversed)))
        //If the player hits a ceiling, remove all vertical velocity and start falling.
        {
            Debug.DrawRay(hit.point, hit.normal, Color.red, 2.0f);
            velocity.y = -2.5f;
        }

        //Ghost platform detection
        if (isGrounded && hit.transform.tag == "GhostPlat")
        {
            hit.transform.SendMessage("StartAnim", SendMessageOptions.DontRequireReceiver);
        }
        //Falling platform detection
        if (isGrounded && hit.transform.tag == "FallPlat")
        {
            hit.transform.SendMessage("StartDrop", SendMessageOptions.DontRequireReceiver);
        }
        //Spring Detection
        if(hit.transform.tag == "Spring")
        {
            StartCoroutine(SpringCoroutine());
            velocity.y = 30;

            //play jump sound 2
            playerSFX.jump2.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    //Handles events for triggers. Use this for non-solid collisions (I.E. objects the player passes through).
    {
        if (other.gameObject.tag == "Hazard_Fall" || other.gameObject.tag == "BOSS")
        {
            Debug.Log("Player fell to their death.");
            isActive = false;
            characterController.enabled = false;
            blackScreenScript.DeathScreen();//fade to black and back
            StartCoroutine(RespawnPlayer());
            gameObject.GetComponent<EventManager>().ResetObjects();           

            //play sfx
            playerSFX.death1.Play();
        }
        //Reverse Gravity Dectection
        if (other.gameObject.CompareTag("Reverse"))
        {
            isReversed = isReversed ? false : true;
            ReversePlayerGravity();

            //play sfx
            playerSFX.gravity1.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Upward")
        //Forces the player to move up. Used for upward transitions to prevent the camera
        //from rapidly switching back & forth during vertical transitions.
        {
            velocity.y = 15.0f;
        }
    }

    private void ReversePlayerGravity()
    {
        velocity.y = 0;
        if(isReversed)
        //When gravity switches, the player falls upwards.
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        //Restores normal gravity.
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator RespawnPlayer()
    //If the player dies, this respawns them at the most recent respawn point.
    {
        conveyorVector = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = currentRespawnLocation;
        transform.rotation = Quaternion.Euler(0, 180, 0); //reset player back to default rotation
        characterController.enabled = true;
        isActive = true;
    }

    IEnumerator WallJumpCoroutine()
    //Freezes the player for a brief moment to allow the wall jump to push them back.
    {
        yield return new WaitForSeconds(0.3f);
        isWallJumping = false;
    }

    IEnumerator SpringCoroutine()
    //Allows the player to bounce on a spring without having to hold the jump button.
    {
        hasSprung = true;
        yield return new WaitForSeconds(0.5f);
        hasSprung = false;
    }

    private void CheckForDoubleJumpPermisson()
    {
        if (doubleJumpEnabled)
        {
            canDoubleJump = true;
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(groundCheck.position, groundDistance);
    //}
}