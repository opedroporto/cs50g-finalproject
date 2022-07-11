using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other) {
        // colliding with enemy and player is attacking
        if (other.gameObject.tag == "Enemy" && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isAttacking) {
            // enemy takes damage
            other.gameObject.GetComponent<Enemy>().TakeDamage(1);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isAttacking = false;
        }
    }
}
