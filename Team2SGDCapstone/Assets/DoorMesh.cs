using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMesh : MonoBehaviour
{
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent == null)
        {
            transform.SetParent(parent, worldPositionStays: true);
        }
    }
}
