using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isDead;
    public int maxHp;
    int hp;

    // Start is called before the first frame update
    void Start() {
        hp = maxHp;
        isDead = false;
    }

    public void TakeDamage(int damage) {
        hp -= damage;
        // die
        if (hp <= 0) {
            GetComponent<RagdollController>().EnableRagdoll();
            isDead = true;
        }
    }

    // public void Carry(GameObject carrier) {
    //     isBeingCarried = true;
    //     // transform.parent = carrier.transform;
    //     // Debug.Log("Carry");
    // }

}
