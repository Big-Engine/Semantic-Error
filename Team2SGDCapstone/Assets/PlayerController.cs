using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool isGrounded;

    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //speed = 5f;
        //jumpForce = 10f;
        isGrounded = true;
        Debug.Log("isGrounded = true");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("isGrounded = false");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        Debug.Log("isGrounded = true");
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        Debug.Log("isGrounded = false");
    }

    //private bool isGrounded()
    //{
    //    RaycastHit hitInfo = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1f, Mathf.Infinity, groundLayer);

    //    bool isGrounded = false;

    //    if (hitInfo.collider != null)
    //    {
    //        isGrounded = true;
    //    }

    //    return isGrounded;
    //}
}
