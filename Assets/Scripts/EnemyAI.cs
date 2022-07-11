using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    // Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    Animator animator;
    int isIdleHash;
    int isWalkingHash;
    int isAttackingHash;

    bool isPlayerColliding;

    private void Awake() {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isAttackingHash = Animator.StringToHash("isAttacking");
        isIdleHash = Animator.StringToHash("isIdle");
        
        isPlayerColliding = false;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    private void Update() {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling() {
        // animation
        bool isIdle = animator.GetBool(isIdleHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isAttacking = animator.GetBool(isAttackingHash);
        animator.SetBool(isIdleHash, false);
        animator.SetBool(isWalkingHash, true);
        animator.SetBool(isAttackingHash, false);

        if (!walkPointSet) SearchWalkPoint();
        
        if (walkPointSet) {
            FacePoint(walkPoint);
            // transform.LookAt(walkPoint);
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint() {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer() {
        // animation
        bool isIdle = animator.GetBool(isIdleHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isAttacking = animator.GetBool(isAttackingHash);
        animator.SetBool(isIdleHash, false);
        animator.SetBool(isWalkingHash, true);
        animator.SetBool(isAttackingHash, false);
        
        if (player.position.y != transform.position.y) {
            agent.SetDestination(player.position);
        }
    }

    private void AttackPlayer() {
        // animation
        bool isIdle = animator.GetBool(isIdleHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isAttacking = animator.GetBool(isAttackingHash);
        if (isWalking) {
            animator.SetBool(isWalkingHash, false);
        }

        agent.SetDestination(transform.position);
        FacePlayer();

        if (!alreadyAttacked) {
            // Attack player
            animator.SetBool(isIdleHash, false);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isAttackingHash, true);
            
            // play enemy roar sound
            string[] soundNames = {"Roar1", "Roar2"};
            FindObjectOfType<AudioManager>().Play(soundNames[Random.Range(1, soundNames.Length)]);

            StartCoroutine(DamagePlayer(0.33f));

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            alreadyAttacked = true;
        }
    }

    IEnumerator DamagePlayer(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        if (isPlayerColliding) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().TakeDamage(1);
        }
    }

    private void FacePlayer() {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void FacePoint(Vector3 target) {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void ResetAttack() {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            isPlayerColliding = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            isPlayerColliding = false;
        }
    }

    // Start is called before the first frame update
    // void Start() {
    //     animator = GetComponent<Animator>();
    //     isWalkingHash = Animator.StringToHash("isWalking");
    // }

    // // Update is called once per frame
    // void Update() {
    //     bool isWalking = animator.GetBool(isWalkingHash);
    //     bool forwardPressed = Input.GetKey("w");

    //     if (!isWalking && forwardPressed) {
    //         animator.SetBool(isWalkingHash, true);
    //     }
    //     if (isWalking && !forwardPressed) {
    //         animator.SetBool(isWalkingHash, false);
    //     }
    // }
}
