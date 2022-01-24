using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTest : MonoBehaviour
{
    public Canvas canvas;
    public Canvas FridgeCanvas;
    public Canvas IntercomCanvas;
    public Canvas LastDecisionCanvas;
    public Text text;
    public Material cleanedIntercom;
    public AudioClip normalBGM;
    public AudioClip radioBGM;
    private AudioSource audioSource;

    int tutorial_flag = 0;
    GameObject mainCamera;

    bool inLiving = true;
    bool openBedroomFirstTime = true;
    public static bool BedroomKey = false;

    bool checkFridgeFirstTime = true;
    bool fridgeHint = false;
    static bool fridgeSolved = false;
    
    public static bool BathroomKey = false;
    bool openBathroomFirstTime = true;

    bool inBathroom = false;
    bool inLaundryroom = false;
    public static bool Soap = false;
    bool cleanIntercomFirstTime = true;
    bool solveIntercomFirstTime = true;
    bool intercomHint = false;
    static bool intercomSolved = false;
    public static bool EntranceKey = false;

    public static bool isRadioPlaying = false;
    bool isCurtainOpen = false;

    bool lastDecision = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorial_flag = 0;
        inLiving = true;
        openBedroomFirstTime = true;
        BedroomKey = false;
        checkFridgeFirstTime = true;
        fridgeHint = false;
        fridgeSolved = false;
        BathroomKey = false;
        openBathroomFirstTime = true;
        inBathroom = false;
        inLaundryroom = false;
        Soap = false;
        cleanIntercomFirstTime = true;
        solveIntercomFirstTime = true;
        intercomHint = false;
        intercomSolved = false;
        EntranceKey = false;
        isRadioPlaying = false;
        isCurtainOpen = false;
        lastDecision = false;



        canvas.enabled = true;
        tutorial_flag = 1;
        mainCamera = Camera.main.gameObject;
        text.text = "-Action 1-\nArrow keys left/right (or A / D): rotate view\nArrow keys up/down (or W / S): adjust height";
        text.fontSize = 40;
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.enabled == true){
            Menu.isEventOngoing = true;
            if(Input.GetMouseButtonDown(0)){
                if(tutorial_flag == 1){
                    text.text = "-Action 2-\nLeft click: examine an object";
                    text.fontSize = 60;
                    tutorial_flag = 2;
                }
                else if(tutorial_flag == 2){
                    text.text = "-Action 3-\nTab key: open the menu";
                    tutorial_flag = 0;
                }
                else{
                    canvas.enabled = false;
                    Menu.isEventOngoing = false;
                }
            }
        }

        if(FridgeTrick.cannotSolveTrick_Fridge == true){
            giveFridgeHint();
        }

        if(FridgeTrick.missTrick_Fridge == true){
            tellYouMadeItWrong_Fridge();
        }

        if(FridgeTrick.solvedTrick_Fridge == true){
            tellYouMadeItWell_Fridge();
        }

        if(IntercomTrick.cannotSolveTrick_Intercom == true){
            giveIntercomHint();
        }

        if(IntercomTrick.missTrick_Intercom == true){
            tellYouMadeItWrong_Intercom();
        }

        if(IntercomTrick.solvedTrick_Intercom == true){
            tellYouMadeItWell_Intercom();
        }
        
    }

    public void onClickCone1(){
        Vector3 tmp = GameObject.Find("pos1").transform.position;
        mainCamera.transform.position = tmp;
        ControlCones.camera_flag = 1;
        ControlCones.flag1 = true;
    }

    public void onClickCone2(){
        Vector3 tmp = GameObject.Find("pos2").transform.position;
        mainCamera.transform.position = tmp;
        ControlCones.camera_flag = 2;
        ControlCones.flag2 = true;
    }

    public void onClickCone3(){
        Vector3 tmp = GameObject.Find("pos3").transform.position;
        mainCamera.transform.position = tmp;
        ControlCones.camera_flag = 3;
        ControlCones.flag3 = true;
    }

    //objects
    public void onClickEntranceDoor(){
        if(EntranceKey == false){
            canvas.enabled = true;
            text.text = "The front door. It's locked.";
        }
        else{
            if(lastDecision == false){
                canvas.enabled = true;
                text.text = "It seems that the front door was unlocked.";
                lastDecision = true;
            }
            else{
                LastDecisionCanvas.enabled = true;
            }
        }
    }

    public void onClickGardenDoor(){
        canvas.enabled = true;
        text.text = "The door leading to the garden. It's locked.";
    }

    public void onClickBedDoor(){
        if(BedroomKey == false){
            canvas.enabled = true;
            text.text = "The bedroom is just ahead, but this door is locked.";
        }
        else{
            if(openBedroomFirstTime == true){
                canvas.enabled = true;
                text.text = "You opened the bedroom door.";
                openBedroomFirstTime = false;
            }
            else{
                if(inLiving == true){
                    Vector3 tmp = GameObject.Find("pos4").transform.position;
                    mainCamera.transform.position = tmp;
                    inLiving = false;
                }
                else{
                    Vector3 tmp = GameObject.Find("pos1").transform.position;
                    mainCamera.transform.position = tmp;
                    ControlCones.camera_flag = 1;
                    ControlCones.flag1 = true;
                    inLiving = true;
                }
            }
        }
    }

    public void onClickBathDoor(){
        if(BathroomKey == false){
            canvas.enabled = true;
            text.text = "The bathroom is just ahead, but this door is locked.";
        }
        else{
            if(openBathroomFirstTime == true){
                canvas.enabled = true;
                text.text = "You opened the bathroom door.";
                openBathroomFirstTime = false;
            }
            else{
                if(inLiving == true){
                    Vector3 tmp = GameObject.Find("pos5").transform.position;
                    mainCamera.transform.position = tmp;
                    inLiving = false;
                }
                else{
                    Vector3 tmp = GameObject.Find("pos2").transform.position;
                    mainCamera.transform.position = tmp;
                    ControlCones.camera_flag = 2;
                    ControlCones.flag2 = true;
                    inLiving = true;
                }
            }
        }
    }

    public void onClickBathroomDoor(){
        if(inBathroom == false){
            Vector3 tmp = GameObject.Find("pos6").transform.position;
            mainCamera.transform.position = tmp;
            inBathroom = true;
        }
        else{
            Vector3 tmp = GameObject.Find("pos5").transform.position;
            mainCamera.transform.position = tmp;
            inBathroom = false;
        }
    }

    public void onClickLaundryDoor(){
        if(inLaundryroom == false){
            Vector3 tmp = GameObject.Find("pos7").transform.position;
            mainCamera.transform.position = tmp;
            inLaundryroom = true;
        }
        else{
            Vector3 tmp = GameObject.Find("pos5").transform.position;
            mainCamera.transform.position = tmp;
            inLaundryroom = false;
        }
    }

    public void onClickIntercom(){
        if(Soap == false){
            canvas.enabled = true;
            text.text = "Perhaps this is the intercom, but it's badly dirty.";
        }
        else{
            if(cleanIntercomFirstTime == true){
                canvas.enabled = true;
                text.text = "You cleaned the intercom with detergent.";
                GameObject intercom = GameObject.Find("Video intercomV1");
                intercom.GetComponent<Renderer>().material = cleanedIntercom;
                cleanIntercomFirstTime = false;
            }
            else{
                if(intercomSolved == false){
                    if(solveIntercomFirstTime == true){
                        canvas.enabled = true;
                        text.text = "Intercom. It has a few buttons on it.";
                        IntercomCanvas.enabled = true;
                        solveIntercomFirstTime = false;
                    }
                    else{
                        IntercomCanvas.enabled = true;
                    }

                }else{
                    canvas.enabled = true;
                    text.text = "You don't want to operate it poorly and have the door lock again.";
                }
            }
        }
    }

    public void giveIntercomHint(){
        IntercomTrick.cannotSolveTrick_Intercom = false;
        canvas.enabled = true;
        if(intercomHint == false){
            text.text = "This should be correct, but...";
            intercomHint = true;
        }
        else{
            text.text = "Does the N above stand for North? Or it could be Negitoro.";
        }
    }

    public void tellYouMadeItWrong_Intercom(){
        IntercomTrick.missTrick_Intercom = false;
        canvas.enabled = true;
        text.text = "The numbers don't seem to be correct.";
    }

    public void tellYouMadeItWell_Intercom(){
        intercomSolved = true;
        IntercomTrick.solvedTrick_Intercom = false;
        canvas.enabled = true;
        if(intercomSolved == true){
            text.text = "It seems that some door has been unlocked.";
            EntranceKey = true;
            IntercomTrick.closeCanvas_Intercom = true;
        }
    }

    public void onClickShoes(){
        canvas.enabled = true;
        text.text = "My shoes.";
    }
    
    public void onClickWatch(){
        canvas.enabled = true;
        text.text = "There is a clock. If often shifts in time and is hard to read, making it unreliable.";
    }

    public void onClickFridge(){
        if(fridgeSolved == false){
            if(checkFridgeFirstTime == true){
                canvas.enabled = true;
                text.text = "Refrigerator. You see some pictures and buttons on it.";
                FridgeCanvas.enabled = true;
                checkFridgeFirstTime = false;
            }
            else{
                FridgeCanvas.enabled = true;
            }

        }else{
            canvas.enabled = true;
            text.text = "There was nothing in it except the key.";
        }
    }

    public void giveFridgeHint(){
        FridgeTrick.cannotSolveTrick_Fridge = false;
        canvas.enabled = true;
        if(fridgeHint == false){
            text.text = "This should be correct, but...";
            fridgeHint = true;
        }
        else{
            text.text = "You remembered that there was one chair in the bathroom.";
        }
    }

    public void tellYouMadeItWrong_Fridge(){
        FridgeTrick.missTrick_Fridge = false;
        canvas.enabled = true;
        text.text = "The numbers don't seem to be correct.";
    }

    public void tellYouMadeItWell_Fridge(){
        fridgeSolved = true;
        FridgeTrick.solvedTrick_Fridge = false;
        canvas.enabled = true;
        if(fridgeSolved == true){
            text.text = "You opened the refrigerator and got the bathroom key.";
            BathroomKey = true;
            FridgeTrick.closeCanvas_Fridge = true;
        }
    }

    public void onClickPlant(){
        canvas.enabled = true;
        text.text = "A house plant.";
    }

    public void onClickMadoriPic(){
        canvas.enabled = true;
        text.text = "The picture looks like a floor plan of a house.";        
    }

    public void onClickGrapefruit(){
        canvas.enabled = true;
        text.text = "After looking the painting closely, you found it not a painting, but a grapefruit.";
    }

    public void onClickScenaryPic(){
        canvas.enabled = true;
        text.text = "Landscape painting.";
    }

    public void onClickGraphPic(){
        canvas.enabled = true;
        text.text = "The picture like an xy-plane.";
    }

    public void onClickAbstractPic(){
        canvas.enabled = true;
        text.text = "It's an abstract picture. You're not sure what it represents.";
    }

    public void onClickTomatoPic(){
        canvas.enabled = true;
        text.text = "This is not a real tomato.. but a picture of a tomato.";
    }

    public void onClickEggplantPic(){
        canvas.enabled = true;
        text.text = "This is a picture of an aubergine.. not a that of an egg plant.";
    }

    public void onClickBreakoutPic(){
        canvas.enabled = true;
        text.text = "Is it a picture of a block breaker? Very well done.";
    }

    public void onClickLivePic(){
        canvas.enabled = true;
        text.text = "Is it a painting of a concert? You see penlights in the foreground.";
    }

    public void onClickKPic(){
        canvas.enabled = true;
        text.text = "You feel a powerful will from this painting.";
    }

    public void onClickWindows(){
        canvas.enabled = true;
        text.text = "This window is closed.";
    }

    public void onClickCurtain(){
        if(isCurtainOpen == false){
            canvas.enabled = true;
            text.text = "You opened the curtain.";
            isCurtainOpen = true;
        }
    }

    public void onClickRadio(){
        audioSource = gameObject.GetComponent<AudioSource>();
        if(isRadioPlaying == false){
            canvas.enabled = true;
            text.text = "You turned on the power.";
            audioSource.volume = 0.2f;
            audioSource.clip = radioBGM;
            
            audioSource.Play();
            isRadioPlaying = true;
        }
        else{
            canvas.enabled = true;
            text.text = "You turned off the power.";
            audioSource.volume = 1.0f;
            audioSource.clip = normalBGM;
            audioSource.Play();
            isRadioPlaying = false;
        }
    }

    public void onClickHeadboard(){
        canvas.enabled = true;
        text.text = "There is a note inside with the word \"North\" written on it. You don't usually pay much " +
                    "attention to directions.";
    }

    public void onClickPiano()
    {
        canvas.enabled = true;
        text.text = "Piano. I can't play.";
    }

    public void onclickPianoChair()
    {
        canvas.enabled = true;
        text.text = "A chair for piano. Not that comfortable.";
    }

    public void onClickTable()
    {
        canvas.enabled = true;
        text.text = "A table used as a dining table.";
    }

    public void onClickDiningChair()
    {
        canvas.enabled = true;
        text.text = "Seating comfort is okay.";
    }

    public void onClickWhiteChair()
    {
        canvas.enabled = true;
        text.text = "It's a very comfortable seat. Mainly used for reading.";
    }

    public void onClickSoccerBall()
    {
        canvas.enabled = true;
        text.text = "Soccer ball. It hasn't been used for a while, so It's become soft and airless.";
    }

    public void onClickBook1()
    {
        canvas.enabled = true;
        text.text = "The October issue of \"The Ends of the World\". It's up to them to define where the end of the world is.";
    }
    
    public void onClickBook2()
    {
        canvas.enabled = true;
        text.text = "The second edition of the Dictionary of Abusive Language. Knowing what not to say make you more careful with your words.";
    }
    
    public void onClickBook3()
    {
        canvas.enabled = true;
        text.text = "It's a book about the difference between Pants and Trousers. It's too complicated to understand.";
    }
    
    public void onClickBook4()
    {
        canvas.enabled = true;
        text.text = "\"Charlie Potter and the Chamber of Chocolates\". It's a well-known bestseller You bought recently.";
    }
    
    public void onClickBook5()
    {
        canvas.enabled = true;
        text.text = "There is a book on game theory. If you read it, you will be able to play the game better.";
    }
    
    public void onClickBook6()
    {
        canvas.enabled = true;
        text.text = "You don't recognize this book. Maybe it's not the one you bought.";
    }
    
    public void onClickBook7()
    {
        canvas.enabled = true;
        text.text = "It's a book about the difference in pronunciation between read and read. You understood it well.";
    }
    
    public void onClickBook8()
    {
        canvas.enabled = true;
        text.text = "The manga you used to read when you were in junior high school.";
    }

    public void onClickVase()
    {
        canvas.enabled = true;
        text.text = "It looks like expensive ceramics. You don't know the real price.";
    }

    public void onClickUpperCabinet()
    {
        canvas.enabled = true;
        text.text = "It contains a variety of dishes and cooking utensils.";
    }

    public void onClickLowerCabinet()
    {
        canvas.enabled = true;
        text.text = "Nothing particularly interesting.";
    }

    public void onClickSink()
    {
        canvas.enabled = true;
        text.text = "You always wondered if it wasn't too small.";
    }

    public void onClickBedroomTable()
    {
        canvas.enabled = true;
        text.text = "Study desk. You can concentrate better than studying in the living room.";
    }

    public void onClickBedroomChair()
    {
        canvas.enabled = true;
        text.text = "It's the same chair that's at the dining table.";
    }

    public void onClickBedroomBook()
    {
        canvas.enabled = true;
        text.text = "You regularly bring books from the bookshelf over here to read.";
    }

    public void onClickBed1()
    {
        canvas.enabled = true;
        text.text = "Basically, it functions as a bed for visitors.";
    }

    public void onClickBed2()
    {
        canvas.enabled = true;
        text.text = "You usually use this bed. It's not too bad.";
    }

    public void onClickBedroomDashboard()
    {
        canvas.enabled = true;
        text.text = "There might be something in there, but you don't want to walk all the way over to it.";
    }

    public void onClickBedroomLamp()
    {
        canvas.enabled = true;
        text.text = "Desk lamp. It illuminates with a moderate brightness.";
    }

    public void onClickToilet()
    {
        canvas.enabled = true;
        text.text = "You noticed that there is no toilet paper.";
    }

    public void onClickMirror()
    {
        canvas.enabled = true;
        text.text = "It's not so clean and polished that you can't see yourself in it.";
    }

    public void onClickTowel()
    {
        canvas.enabled = true;
        text.text = "A towel to wipe your hands. A little Dirty.";
    }

    public void onClickWashbasin()
    {
        canvas.enabled = true;
        text.text = "There are refill pack of shampoos and conditioners as well as drainpipes running through it.";
    }

    public void onClickTissue()
    {
        canvas.enabled = true;
        text.text = "Combination of tissues and lotion.";
    }

    public void onClickBathroomChair()
    {
        canvas.enabled = true;
        text.text = "If you don't brush it regularly, it will soon become covered with grime.";
    }

    public void onClickBottles()
    {
        canvas.enabled = true;
        text.text = "There are shampoos, conditioners, and other things You don't understand.";
    }

    public void onClickShowerKnob()
    {
        canvas.enabled = true;
        text.text = "No need to flush now. You're not even undressing.";
    }

    public void onClickShower()
    {
        canvas.enabled = true;
        text.text = "It flushes with just the right amount of strength, not too strong and not too weak.";
    }

    public void onClickBathtub()
    {
        canvas.enabled = true;
        text.text = "There is no hot water.";
    }

    public void onClickBasket()
    {
        canvas.enabled = true;
        text.text = "Laundry basket. The capacity is a little small, which is a little problem.";
    }
    
    public void onClickLaundryMachine()
    {
        canvas.enabled = true;
        text.text = "Drum-type washing machine. Probably the best appliance in the house.";
    }
    
    public void onClickBleachBottle()
    {
        canvas.enabled = true;
        text.text = "Bleach. Don't mix with other chemicals.";
    }

    public void onClickFabricSoftener()
    {
        canvas.enabled = true;
        text.text = "Fabric softener. You bought it because it has a reputation for smelling pretty good.";
    }
    
    //items
    public void onClickBedroomKey(){
        canvas.enabled = true;
        text.text = "You got the bedroom key.";
        BedroomKey = true;
        GameObject.Find("BedroomKey").transform.localScale = new Vector3(0, 0, 0);
    }

    public void onClickDetergent(){
        canvas.enabled = true;
        text.text = "You got the detergent.";
        Soap = true;
    }

}
