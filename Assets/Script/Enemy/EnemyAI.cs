using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    public float waitTimeAtPoint = 2f;

    [Header("Chase Settings")]
    public Transform player;
    public float chaseSpeed = 4f;
    public float detectionRange = 10f;

    [Header("Game Over Settings")]
    public GameObject gameOverCanvas;

    public float stoppingDistance = 1f;

    private int currentPatrolIndex = 0;
    private float waitTimer = 0f;
    private bool isChasing = false;

    private void Start()
    {
        // Pastikan Canvas Game Over tidak aktif saat game dimulai
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Game Over Canvas is not assigned in the inspector!");
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Start chasing if player is in range
            isChasing = true;
        }
        else if (distanceToPlayer > detectionRange * 1.2f) // Add a buffer to avoid constant switching
        {
            // Stop chasing if player is out of range
            isChasing = false;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);

        // Move towards the current patrol point
        if (distanceToTarget > stoppingDistance)
        {
            MoveTowards(targetPoint.position, patrolSpeed);
        }
        else
        {
            // Wait at the patrol point before moving to the next one
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTimeAtPoint)
            {
                waitTimer = 0f;
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            }
        }
    }

    private void ChasePlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            MoveTowards(player.position, chaseSpeed);
        }
    }

    private void MoveTowards(Vector3 target, float speed)
    {
        // Calculate direction and move the enemy
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Face the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger with Player detected!");
            GameOver();
        }
    }


    private void GameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize detection range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
