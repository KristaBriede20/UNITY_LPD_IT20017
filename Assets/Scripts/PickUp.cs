using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 3f;
    public float pickUpSpeed = 5f;

    private Transform player;
    private Rigidbody rb;
    private bool isPickedUp = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPickedUp)
            {
                Drop();
            }
            else if (IsInRange())
            {
                PickUpObject();
            }
        }

        if (isPickedUp)
        {
            RotateObject();
        }
    }
    void PickUpObject()
    {
        rb.isKinematic = true;
        transform.SetParent(player);

        // Set position and rotation relative to the camera's forward direction
        transform.localPosition = new Vector3(0, 0, pickUpRange);
        transform.localRotation = Quaternion.identity;

        isPickedUp = true;
    }

    void Drop()
    {
        rb.isKinematic = false;
        transform.SetParent(null);
        isPickedUp = false;
    }

    bool IsInRange()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= pickUpRange;
    }

    void RotateObject()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X") * pickUpSpeed;
        float rotateVertical = Input.GetAxis("Mouse Y") * pickUpSpeed;
        transform.Rotate(new Vector3(-rotateVertical, rotateHorizontal, 0));
    }
}