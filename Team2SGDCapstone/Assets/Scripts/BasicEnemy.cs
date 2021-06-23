using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public GameObject position1;
    private Vector3 position1Location;
    public GameObject position2;
    private Vector3 position2Location;
    private Vector3 initialPosition;

    [SerializeField] float speed;
    [SerializeField] float resetTime;
    Vector3 target;

    public GameObject snake;

    void OnEnable()
    {
        EventManager.OnReset += ResetPosition;
    }

    void OnDisable()
    {
        EventManager.OnReset -= ResetPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        position1Location = position1.transform.position;
        position2Location = position2.transform.position;
        target = position1Location;
        ChangeTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void ChangeTarget()
    {

        if (Vector3.Distance(transform.position, target) < 2f)
        {
            if (target == position1Location)
            {
                target = position2Location;
                snake.transform.localScale = new Vector3((float)0.01f, (float)0.01f, (float)-0.01f);
            }
            else
            {
                target = position1Location;
                snake.transform.localScale = new Vector3((float)0.01f, (float)0.01f, (float)0.01f);
            }
        }
        Invoke("ChangeTarget", resetTime);
    }

    void ResetPosition()
    {
        CancelInvoke();
        ChangeTarget();
        transform.position = initialPosition;
        transform.localScale = new Vector3((float)0.01f, (float)0.01f, (float)0.01f);
        target = position1Location;
    }
}
