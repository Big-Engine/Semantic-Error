using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider boxCollider;
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpForce = 20;
    private float distToGround;
    private int jumpsRemain = 1;//for double/wall jumping

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        //isGrounded = true;
        distToGround = boxCollider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Move left/right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation = new Quaternion(0f, -180f, 0f, 0f);
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded() || jumpsRemain > 0))
        {
            rb.velocity = new Vector3 (0, jumpForce, 0);
            jumpsRemain--;
            //Debug.Log(jumpsRemain);
        }

        if(isGrounded())
        {
            jumpsRemain = 1;
            //Debug.Log(jumpsRemain);
        }
    }

    private void FixedUpdate()//gravity
    {
        rb.AddForce(Physics.gravity * 2f, ForceMode.Acceleration);
    }

    private bool isGrounded()//check if player is on the ground
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.5f);
    }

    private void OnTriggerEnter(Collider other)//walljump
    {
        if(other.tag == "wall")
        {
            jumpsRemain++;
            //Debug.Log(jumpsRemain);
        }
    }

}
