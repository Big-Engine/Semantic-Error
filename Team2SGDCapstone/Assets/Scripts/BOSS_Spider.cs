using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Spider : MonoBehaviour
{
    public Vector3 endPosition;
    private Vector3 lastPosition;
    [SerializeField] float speed;

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
        lastPosition = transform.position;//initial position
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
    }

    void ResetPosition()
    {

    }
}
