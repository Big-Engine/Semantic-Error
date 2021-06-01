using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject destination;
    bool canPickUp = false;
    bool hasObject = false;

    private GameObject gameObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(canPickUp == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && hasObject == false)
            {
                gameObj.GetComponent<Rigidbody>().isKinematic = true;
                gameObj.transform.position = destination.transform.position;
                gameObj.transform.parent = destination.transform;
                hasObject = true;
                Debug.Log("hasObj true");
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && hasObject == true)
        {
            gameObj.GetComponent<Rigidbody>().isKinematic = false;
            gameObj.transform.parent = null;
            hasObject = false;
            Debug.Log("hasObj false");
        }
    }

    private void OnTriggerEnter(Collider other)//when in range of obj
    {
        if(other.gameObject.tag == "object")
        {
            canPickUp = true;
            Debug.Log("canPickUp true");
            gameObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)//when exit range on obj
    {
        canPickUp = false;
        Debug.Log("canPickUp false");
    }
}
