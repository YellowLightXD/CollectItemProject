using UnityEngine;
using UnityEngine.AI;

public class DynamicVolumeAI : MonoBehaviour
{
    public Transform player; // Reference to the player’s transform
    public float detectionRadius = 10f; // Radius within which the AI will detect the player
    public AudioClip alertClip; // The audio clip to play when the player is detected

    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        
        // Check if AudioSource and AudioClip are assigned
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
        if (alertClip == null)
        {
            Debug.LogError("AlertClip is not assigned!");
        }
        
        // Initialize audio
        audioSource.clip = alertClip;
        audioSource.loop = true; // Make sure the audio is looped if needed
    }

    void Update()
    {
        // Calculate distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Set the destination of the NavMeshAgent to the player’s position
            agent.SetDestination(player.position);

            // Calculate volume based on distance
            float volume = 5 / distanceToPlayer;

            // Set the volume of the AudioSource
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            audioSource.volume = volume;

            // Rotate to face the player
            Vector3 direction = player.position - transform.position ;
            float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ;
            transform.rotation = Quaternion.Euler(0, rotationAngle - 45, 0); // Adjust for correct facing direction
        }
        else
        {
            // Stop the audio if the player is out of range
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}