using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillHazardCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        yield return new WaitforSeconds(6f);
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
