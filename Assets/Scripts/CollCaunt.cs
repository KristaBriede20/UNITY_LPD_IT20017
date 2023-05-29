using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollCaunt : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void OnEnable() => Coll.OnCollected += OnCollectibleCollected;
    void OnDisable() => Coll.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        text.text = (++count).ToString();
    }

}
