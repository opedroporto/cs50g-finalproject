using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryEntity : MonoBehaviour
{
    bool isCarrying;
    GameObject carriedObject;

    // public float distance;

    // Start is called before the first frame update
    void Start()
    {
        isCarrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCarrying) {
            Carry(carriedObject);
            if (Input.GetKeyDown("v")) {
                carriedObject.GetComponent<RagdollController>().LeaveCarryState();
                carriedObject.transform.parent = null;
                carriedObject = null;
                isCarrying = false;
            }
        }
    }

    void Carry(GameObject obj) {
        obj.GetComponent<RagdollController>().ToCarryState();
        obj.transform.parent = transform;
    }
    
    void OnTriggerStay(Collider other) {
        if (!isCarrying && Input.GetKeyDown("c")) {
            if (other.transform.root.gameObject.tag == "Enemy" && other.transform.root.gameObject.GetComponent<Enemy>().isDead) {
                isCarrying = true;
                carriedObject = other.transform.root.gameObject;
            }
        }
    }
}
