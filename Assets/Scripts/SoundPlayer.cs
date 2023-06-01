using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        audioSource.clip = soundClip;
        audioSource.Play();
    }
}
