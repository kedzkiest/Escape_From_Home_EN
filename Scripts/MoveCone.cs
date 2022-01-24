using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCone : MonoBehaviour
{
    private float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += 0.1f;
        if (t > 1000000) t = 0;
        
        this.transform.Translate(0, 0.3f * Mathf.Sin(t * 0.5f) * Time.deltaTime, 0);
    }
}
