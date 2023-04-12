using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_try : MonoBehaviour

{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        cube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "capsula")
        {
            cube.SetActive(true);
        }
    }
}
