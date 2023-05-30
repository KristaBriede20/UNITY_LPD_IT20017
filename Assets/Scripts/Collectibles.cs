using System;
using UnityEngine;

public class Coll : MonoBehaviour
{
    public GameObject nextBall;

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextBall.SetActive(true);
            CollCaunt.count++;
            Destroy(gameObject);
        }
    }
}
