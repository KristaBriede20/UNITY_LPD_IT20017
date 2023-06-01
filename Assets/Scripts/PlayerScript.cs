using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;
    public float jumpHeight = 4f;
    bool isGrounded;

    public AudioClip jumpSound; 
    private AudioSource jumpAudioSource; 

    Vector3 velocity;

    void Start()
    {
        
        GameObject jumpAudioObject = new GameObject("JumpAudio");
        jumpAudioObject.transform.parent = transform; 
        jumpAudioSource = jumpAudioObject.AddComponent<AudioSource>();

        jumpAudioSource.clip = jumpSound; 
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

           
            jumpAudioSource.PlayOneShot(jumpSound);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}