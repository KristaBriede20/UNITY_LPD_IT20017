using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollCaunt : MonoBehaviour
{
    public Text ballCount;
    public static int count;
    public GameObject winText;


    void Awake()
    {
        count = 0;
        ballCount.text = "Balls found: " + count;
        winText.SetActive(false);
    }
    
    void Update()
    {
        ballCount.text = "Balls found " + count + " of 9";
        if(count == 9)
        {
            winText.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
}
