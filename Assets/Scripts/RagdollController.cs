using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollController : MonoBehaviour
{
    private Rigidbody[] rigidbodies;
    private Collider[] colliders;

    private CapsuleCollider entityCapsulleCollider;
    private BoxCollider entityBoxCollider;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private EnemyAI entityAI;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        entityCapsulleCollider = GetComponent<CapsuleCollider>();
        entityBoxCollider = GetComponent<BoxCollider>();
        entityAI = GetComponent<EnemyAI>();

        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();

        DisableRagdoll();
    }

    public void DisableRagdoll() {
        foreach (Collider col in colliders) {
            col.enabled = false;
        }
        foreach (Rigidbody rb in rigidbodies) {
            rb.isKinematic = true;
        }
        entityCapsulleCollider.enabled = false;
        entityCapsulleCollider.isTrigger = false;
        entityBoxCollider.enabled = true;
        entityAI.enabled = true;
        animator.enabled = true;
        navMeshAgent.enabled = true;
    }

    public void EnableRagdoll() {
        foreach (Collider col in colliders) {
            col.enabled = true;
        }
        foreach (Rigidbody rb in rigidbodies) {
            rb.isKinematic = false;
        }

        entityCapsulleCollider.enabled = false;
        entityBoxCollider.enabled = false;
        entityAI.enabled = false;
        animator.enabled = false;
        navMeshAgent.enabled = false;
    }

    public void ToCarryState() {
        foreach (Collider col in colliders) {
            col.enabled = false;
        }
        foreach (Rigidbody rb in rigidbodies) {
            rb.isKinematic = true;
        }

        entityCapsulleCollider.enabled = false;
        entityBoxCollider.enabled = false;
    }

    public void LeaveCarryState() {
        foreach (Collider col in colliders) {
            col.enabled = true;
        }
        foreach (Rigidbody rb in rigidbodies) {
            rb.isKinematic = false;
        }

        entityCapsulleCollider.enabled = false;
        entityBoxCollider.enabled = false;
    }

    // public Animator anim;
    // public Rigidbody playerRb;
    // public CapsuleCollider capsuleCollider;

    // private Rigidbody[] rigidbodies;
    // private Collider[] colliders;

    // private void Awake() {
    //     rigidbodies = GetComponentsInChildren<Rigidbody>();
    //     colliders = GetComponentsInChildren<Collider>();
    // }

    // private void SetCollidersEnabled(bool enabled) {
    //     foreach (Collider col in colliders) {
    //         col.enabled = enabled;
    //     }
    // }

    // private void SetRigidbodiesKinematic (bool kinematic) {
    //     foreach (Rigidbody rb in rigidbodies) {
    //         rb.isKinematic = kinematic;
    //     }
    // }

    // private void ActivateRagdoll() {
    //     capsuleCollider.enabled = false;
    //     playerRb.isKinematic = true;
    //     anim.enabled = false;

    //     SetCollidersEnabled(true);
    //     SetRigidbodiesKinematic(false);
    // }
}
