using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_CameraRotate : MonoBehaviour
{
    private float camRotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, camRotationSpeed * Time.deltaTime, 0);
    }
}
