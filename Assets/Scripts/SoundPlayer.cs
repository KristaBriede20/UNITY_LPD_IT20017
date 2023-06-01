using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopSound();
        }
    }

    private void PlaySound()
    {
        audioSource.clip = soundClip;
        audioSource.Play();
    }

    private void StopSound()
    {
        audioSource.Stop();
    }
}
