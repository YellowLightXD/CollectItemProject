using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player; // Reference to the player’s transform
    public float detectionRadius = 10f; // Radius within which the enemy will detect the player

    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing!");
        }
        if (animator == null)
        {
            Debug.LogError("Animator component is missing!");
        }
    }

    void Update()
    {
        // Calculate distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Set the destination of the NavMeshAgent to the player’s position
            agent.SetDestination(player.position);
            
            // Play the animation
            if (!animator.GetBool("IsWalking"))
            {
                animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            // Stop the animation
            if (animator.GetBool("IsWalking"))
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }
}
