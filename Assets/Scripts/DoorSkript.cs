using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSkript : MonoBehaviour
{
    Animator animator;
    public bool isOpen, isClosed, inReach;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inReach = true;
            Debug.Log("enter");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inReach = false;
            Debug.Log("exit");
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact") && isClosed)
        {
            isClosed = false;
            isOpen = true;
            animator.SetBool("open", true);
            Debug.Log("open");
        }

        else if (inReach && Input.GetButtonDown("Interact") && isOpen)
        {
            isClosed = true;
            isOpen = false;
            animator.SetBool("open", false);
            Debug.Log("close");
        }
    }
}
