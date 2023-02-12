using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.score >= 1)
        {
            // Debug.Log("Disappear");
            Destroy(gameObject);
        }
    }
}
