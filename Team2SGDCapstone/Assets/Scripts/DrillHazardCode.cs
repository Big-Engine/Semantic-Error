using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillHazardCode : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;
    [SerializeField] private float fallSpeed = 5;
    [SerializeField] private float fallDuration = 2;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        Invoke("ResetPosition", fallDuration);
    }

    void Update()
        //move drill down
        //drill rotation is handled by an animation
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
    }

    void ResetPosition()
        //drill returns to start point, invokes this function again
    {
        transform.position = initialPosition;
        Invoke("ResetPosition", fallDuration);
    }
}
