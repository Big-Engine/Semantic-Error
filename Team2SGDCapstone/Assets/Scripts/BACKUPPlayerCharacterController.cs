using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BACKUPPlayerCharacterController : MonoBehaviour
{
    [Header("CharacterControls")]
    [SerializeField] public bool canMove;
    private CharacterController characterController;
    private Vector3 moveVector;
    private float inputDirection;
    private float verticalVelocity;
    private float gravity = 25.0f;
    private float playerSpeed = 10.0f;
    private float jumpForce = 10.0f;
    public float jumpTimer;
    private bool canDoubleJump = false;
    private Vector3 movementOffSet;



    Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        jumpTimer -= Time.deltaTime;
        inputDirection = Input.GetAxis("Horizontal") * playerSpeed;

        if (transform.position.z != 0)
        {
            movementOffSet.z = (0 - transform.position.z) * 0.05f;
        }
        characterController.Move(movementOffSet);

        if (IsPlayerGrounded())
        {
            if (jumpTimer <= 0)
            {
                verticalVelocity = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("should jump");
                jumpTimer = 0.2f;
                characterController.transform.position = characterController.transform.position + new Vector3(0, 10, 0);
                verticalVelocity = jumpForce;
                canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                verticalVelocity = jumpForce;
                canDoubleJump = false;
            }
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //if (canMove)
        //{
        //    moveVector = new Vector3(inputDirection, verticalVelocity, 0);
        //}
        //else
        //{
        //    moveVector = new Vector3(0, 0, 0);
        //}
        characterController.Move(moveVector * Time.deltaTime);
    }

    private bool IsPlayerGrounded()
    {
        bool returnBool = false;
        Vector3 leftRayStart;
        Vector3 rightRayStart;

        leftRayStart = characterController.bounds.center;
        leftRayStart.x -= characterController.bounds.extents.x;

        rightRayStart = characterController.bounds.center;
        rightRayStart.x += characterController.bounds.extents.x;

        if (Physics.Raycast(leftRayStart, Vector3.down, (characterController.height / 2) + 0.1f))
        {
            Debug.Log("LeftGround");
            returnBool = true;
        }
        else if (Physics.Raycast(rightRayStart, Vector3.down, (characterController.height / 2) + 0.1f))
        {
            Debug.Log("RightGround");
            returnBool = true;
        }

        Debug.Log("No Ground");
        return returnBool;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (characterController.collisionFlags == CollisionFlags.Sides)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveVector = hit.normal * playerSpeed;
                moveVector.y = jumpForce;
                canDoubleJump = true;
            }
        }
    }
}
