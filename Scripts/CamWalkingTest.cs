using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamWalkingTest : MonoBehaviour
{
    public float camRotationSpeed = 100.0f;

    public float updownSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = GameObject.Find("Main Camera").transform.position;

        //camera can look around
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            this.transform.Rotate (0.0f,-camRotationSpeed * Time.deltaTime,0.0f);
        }
        
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            this.transform.Rotate (0.0f,camRotationSpeed * Time.deltaTime,0.0f);
        }
        
        if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            if(tmp.y <= 1.3f){
                this.transform.Translate (0.0f,updownSpeed * Time.deltaTime,0.0f);
            }
        }
        
        if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            if(tmp.y >= 0.2f){
                this.transform.Translate (0.0f,-updownSpeed * Time.deltaTime,0.0f);
            }
        }
       

    }
}
