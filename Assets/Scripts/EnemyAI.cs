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
    public GameObject deadText;
    public GameObject walkSound;

    private bool isAttackPlayerState = false;
    private NavMeshAgent agent;
    private Collider enemyCollider;

    public static int playerHealth = 100;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyCollider = GetComponent<Collider>();
        StartCoroutine(SwitchStateCoroutine());
        deadText.SetActive(false);
        walkSound.SetActive(false);
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

            yield return new WaitForSeconds(20);

            // Attack Player state
            isAttackPlayerState = true;
            SetObjectVisibility(true);
            enemyCollider.enabled = true;
            agent.speed = attackSpeed;
            enemyAnimator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(30);
        }
    }

    private void Update()
    {
        if (isAttackPlayerState)
        {
            // Move towards the player
            agent.SetDestination(player.position);
            walkSound.SetActive(true);
        }
        else
        {
            // Randomly move around rooms while exploring the environment
            Vector3 randomDirection = Random.insideUnitSphere * randomWalkRadius;
            randomDirection += GetRandomRoomPosition();
            agent.SetDestination(randomDirection);walkSound.SetActive(false);
            walkSound.SetActive(false);
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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            deadText.SetActive(true);
            walkSound.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
