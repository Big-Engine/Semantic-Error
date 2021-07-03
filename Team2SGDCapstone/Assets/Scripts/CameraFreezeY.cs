using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreezeY : MonoBehaviour
{
    private float currentY;
    private float y;

    private void Start()
    {
        currentY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        y = Mathf.Clamp(transform.position.y, currentY - 0.01f, currentY + 0.01f);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
