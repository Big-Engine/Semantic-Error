using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;
    private Vector3 velocity;
    private bool platformMovingBack;
    [SerializeField] private float fallDuration = 3;
    [SerializeField] private float terminalVelocity = -50.0f;

    void OnEnable()
    {
        EventManager.OnReset += ResetPosition;
    }

    void OnDisable()
    {
        EventManager.OnReset -= ResetPosition;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if(rb.velocity.y < terminalVelocity)
        {
            velocity.y = terminalVelocity;
        }
    }
    void FixedUpdate()
    {
        if(platformMovingBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, 20f * Time.deltaTime);
        }

        if(transform.position.y == initialPosition.y)
        {
            platformMovingBack = false;
        }
    }

    public void StartDrop()
        //called from player controller, invokes platform drop
    {
        Invoke("DropPlatform", 0.5f);
    }

    void DropPlatform()
        //enables gravity for platform, invokes MovePlatformBack function
    {
        rb.isKinematic = false;
        Invoke("MovePlatformBack", fallDuration);
    }

    void MovePlatformBack()
        //allows the platform to return back to start point. Disables gravity
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        platformMovingBack = true;
    }

    void ResetPosition()
    {
        transform.position = initialPosition;
        rb.isKinematic = true;
        platformMovingBack = false;
    }
}
