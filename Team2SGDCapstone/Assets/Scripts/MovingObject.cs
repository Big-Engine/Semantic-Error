using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    //This script is for moving an object between two positions repeatedly

    public GameObject position1;
    Vector3 position1Location;
    public GameObject position2;
    Vector3 position2Location;

    [SerializeField] float speed;
    [SerializeField] float resetTime;
    Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        position1Location = position1.transform.position;
        position2Location = position2.transform.position;
        target = position1Location;
        ChangeTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    void ChangeTarget()
    {

        if (Vector3.Distance(transform.position, target) < 2f)
        {
            if (target == position1Location)
            {
                target = position2Location;
            }
            else
            {
                target = position1Location;
            }
        }
        Invoke("ChangeTarget", resetTime);
    }
}
