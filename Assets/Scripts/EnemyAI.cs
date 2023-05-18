using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float randomWalkRadius = 20f;
    public float randomWalkSpeed = 10f;
    public float attackSpeed = 3f;
    public float minDistanceFromPlayer = 10f;
    public Transform player;
    public Animator enemyAnimator;
    public Renderer[] objectRenderers;

    private bool isAttackPlayerState = false;
    private NavMeshAgent agent;
    private Collider enemyCollider;

    public static int playerHealth = 100;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyCollider = GetComponent<Collider>();
        StartCoroutine(SwitchStateCoroutine());
    }

    private IEnumerator SwitchStateCoroutine()
    {
        while (true)
        {
            // Random Walk state
            isAttackPlayerState = false;
            SetObjectVisibility(false);
            enemyCollider.enabled = false;
            agent.speed = randomWalkSpeed;
            enemyAnimator.SetBool("isAttacking", false);

            // Generate a new random destination
            Vector3 randomDirection = GetRandomRoomPosition();
            agent.SetDestination(randomDirection);

            yield return new WaitForSeconds(10);

            // Attack Player state
            isAttackPlayerState = true;
            SetObjectVisibility(true);
            enemyCollider.enabled = true;
            agent.speed = attackSpeed;
            enemyAnimator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(10);
        }
    }

    private void Update()
    {
        if (isAttackPlayerState)
        {
            // Move towards the player
            agent.SetDestination(player.position);
        }
        else
        {
            // Randomly move around rooms while exploring the environment
            Vector3 randomDirection = Random.insideUnitSphere * randomWalkRadius;
            randomDirection += GetRandomRoomPosition();
            agent.SetDestination(randomDirection);
        }
    }

    private Vector3 GetRandomRoomPosition()
    {
        // Replace this method with your own logic to get a random position in the room or environment
        Vector3 randomPosition = new Vector3(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
        return randomPosition;
    }

    private void SetObjectVisibility(bool isVisible)
    {
        foreach (Renderer renderer in objectRenderers)
        {
            renderer.enabled = isVisible;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("dead");
        }
    }
}
