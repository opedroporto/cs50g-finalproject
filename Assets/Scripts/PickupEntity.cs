using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEntity : MonoBehaviour
{
    bool isCarrying;
    GameObject carriedObject;

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
            if (Input.GetKeyDown("c")) {
                carriedObject.GetComponent<RagdollController>().LeaveCarryState();
                carriedObject.transform.parent = null;
                carriedObject = null;
                isCarrying = false;
            }
        } else {
            Pickup();
        }
    }

    void Carry(GameObject obj) {
        obj.GetComponent<RagdollController>().ToCarryState();
        
        obj.transform.parent = transform;
        // obj.transform.position = GetComponent<Camera>().transform.position + GetComponent<Camera>().transform.forward * 1.5f;
    }

    void Pickup() {
        if (Input.GetKeyDown("c")) {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

            // Debug
            // Debug.DrawRay(transform.position, new Vector3(x, y), Color.green);

            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.transform.root.gameObject.tag == "Enemy" &&
                    hit.collider.transform.root.gameObject.GetComponent<Enemy>().isDead &&
                    Vector3.Distance(hit.collider.transform.position, transform.position) <= 3f) {
                    isCarrying = true;
                    carriedObject = hit.collider.transform.root.gameObject;
                }
            }
        }
    }
}
