using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollCaunt : MonoBehaviour
{
    public Text ballCount;
    public static int count;

    void Awake()
    {
        count = 0;
        ballCount.text = "Balls found: " + count;
    }
    
    void Update()
    {
        ballCount.text = "Balls found " + count + " of 9";
    }
}
