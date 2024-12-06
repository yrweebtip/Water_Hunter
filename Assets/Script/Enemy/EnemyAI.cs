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

    

    public float stoppingDistance = 1f;

    private int currentPatrolIndex = 0;
    private float waitTimer = 0f;
    private bool isChasing = false;

    private void Start()
    {
        // Pastikan Canvas Game Over tidak aktif saat game dimulai
       
      
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            
            isChasing = true;
        }
        else if (distanceToPlayer > detectionRange * 1.2f) 
        {
            
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

        
        if (distanceToTarget > stoppingDistance)
        {
            MoveTowards(targetPoint.position, patrolSpeed);
        }
        else
        {
            
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
        
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }

   

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
