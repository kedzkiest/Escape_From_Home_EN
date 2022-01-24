using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Menu : MonoBehaviour
{
    public Canvas canvas;
    public Text item_text, time_text;
    public static float totalTime;
    public static bool isEventOngoing;

    // Start is called before the first frame update
    void Start()
    {
        isEventOngoing = true;
        totalTime = 0;
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        time_text.text = "Elapsed time\n\n" + string.Format("{0:f3}", totalTime) + "s";

        item_text.text = "Items\n\n";
        if(ClickTest.BedroomKey == true){
            string addBedroomKey = "Bedroom key\n";
            item_text.text = String.Concat(item_text.text, addBedroomKey);
        }
        if(ClickTest.BathroomKey == true){
            string addBathroomKey = "Bathroom key\n";
            item_text.text = String.Concat(item_text.text, addBathroomKey);
        }
        if(ClickTest.Soap == true){
            string addSoap = "Detergent\n";
            item_text.text = String.Concat(item_text.text, addSoap);
        }

        if(isEventOngoing == false){
            if(Input.GetKeyDown(KeyCode.Tab)){
                if(canvas.enabled == false){
                    canvas.enabled = true;
                }
                else{
                    canvas.enabled = false;
                }
            }
        }
    }
}
