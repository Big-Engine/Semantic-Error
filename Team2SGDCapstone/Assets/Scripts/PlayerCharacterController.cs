using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    private float inputDirection;
    private Vector3 moveVector;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -9.81f;
    public float playerSpeed = 10.0f;
    public float jumpForce = 10.0f;
    private bool canDoubleJump = false;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    private CharacterController characterController;
    Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -5.0f;
            canDoubleJump = true;
        }
        
        inputDirection = Input.GetAxis("Horizontal");
        moveVector = new Vector3(inputDirection, 0f, 0f);
        characterController.Move(moveVector * playerSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            canDoubleJump = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isGrounded && canDoubleJump)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            canDoubleJump = false;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (characterController.collisionFlags == CollisionFlags.Sides)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            moveVector = hit.normal * playerSpeed;
    //            moveVector.y = jumpForce;
    //            canDoubleJump = true;
    //        }
    //    }
    //}
}
