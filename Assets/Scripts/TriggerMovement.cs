using UnityEngine;

public class TriggerMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float movementDuration = 1f;
    public AudioClip movementSound;

    private bool isMoving = false;
    private bool isTriggered = false;
    private float movementTimer = 0f;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.CompareTag("Player"))
        {
            isTriggered = true;
            isMoving = true;
            movementTimer = 0f;
            GetComponent<Collider>().enabled = false; // Disable the trigger collider

            if (movementSound != null)
            {
                audioSource.clip = movementSound;
                audioSource.Play();
            }
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            movementTimer += Time.deltaTime;
            float t = movementTimer / movementDuration;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);

            if (movementTimer >= movementDuration)
            {
                isMoving = false;
            }
        }
    }
}
