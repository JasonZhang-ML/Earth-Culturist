using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private float[] unit = {50f, 50f, 50f, 50f, 50f};
=======
    private float[] unit = {5f, 5f, 5f, 5f, 5f};
>>>>>>> e0d0c05... Version 1.0 with load scene bug
=======
    private float[] unit = {5f, 5f, 5f, 5f, 5f}; // earn 0.02 earn 0.01
>>>>>>> 59a7e27... Earth Cultrist v1.1.0
    private float[] score = new float[5];
=======
    public float S1, S2, S3, S4, S5 = 0f;
    private float unit_1,unit_2,unit_3,unit_4,unit_5 = 40f; 
>>>>>>> 7f542d1... Connect with the earth
=======
    private float[] unit = {40f, 40f, 40f, 40f, 40f};
=======
    private float[] unit = {50f, 50f, 50f, 50f, 50f};
>>>>>>> 7022726... implement game score system and slider dectaction
    private float[] score = new float[5];
>>>>>>> 15b27fb... fixed socre system
=======
    private float[] unit = {50f, 50f, 50f, 50f, 50f};
    private float[] score = new float[5];
>>>>>>> 2a80022... Add Music 'Fade'
    public string eventID;
    public float inverseFPS = 0.025f;  // FPS = 40
    public static float earthRadius = 51f; 
    public static float laneRadius = 66f; 
    public static int trackNum = 5; 
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    // public static int sliderIndex = 0; 
=======
    public static int sliderIndex = 0; 
>>>>>>> 7022726... implement game score system and slider dectaction

<<<<<<< HEAD
<<<<<<< HEAD
=======
    // public static int sliderIndex = 0; 

>>>>>>> 2a80022... Add Music 'Fade'
    public static float sliderLength = 1.5f;
    public static float trackLength = 84f;
<<<<<<< HEAD
    public static float sliderSpeed = -0.6f;  // x position unity per frame
    public static float targetLowerBound = 4220f;  // Sqr value, 64.25+100
    public static float targetUpperBound = 4895.6f; // Sqr value, 69.25^2+100  
<<<<<<< HEAD
=======
    // public static int sliderIndex = 0; 
>>>>>>> d4f12ee...  	ap_effect Connect with Controller and provide single click feature.

    static float arriveTimeConstant = (trackLength - 2 * sliderLength) / (-sliderSpeed);
    static float leaveTimeConstant = (trackLength + sliderLength) / (-sliderSpeed);
=======
    public static float sliderLength = 1.09f;
=======
    public static float sliderLength = 1.5f;
>>>>>>> 15b27fb... fixed socre system
    public static float trackLength = 84f;
    public static float sliderSpeed = -0.6f;  // x position unity per frame
<<<<<<< HEAD
    public static float targetLowerBound = 4220f;  // Sqr value, 64.25+100
    public static float targetUpperBound = 4895.6f; // Sqr value, 69.25^2+100  

<<<<<<< HEAD
    public static float sliderSpeed = -0.5f;  // x position unity per frame

<<<<<<< HEAD
    static float arriveTimeConstant = (trackLength - 2 * sliderLength) / sliderSpeed;
    static float leaveTimeConstant = (trackLength + sliderLength) / sliderSpeed;
>>>>>>> 5960d4d... implement Earth demo
=======
    static float arriveTimeConstant = (trackLength - 2 * sliderLength) / (-1f*sliderSpeed);
    static float leaveTimeConstant = (trackLength + sliderLength) / (-1f*sliderSpeed);
>>>>>>> 15b27fb... fixed socre system
=======
    static float arriveTimeConstant = (trackLength - 2 * sliderLength) / (-sliderSpeed);
    static float leaveTimeConstant = (trackLength + sliderLength) / (-sliderSpeed);
>>>>>>> 7022726... implement game score system and slider dectaction
=======
=======
    public static float sliderSpeed = -0.3f;  // x position unity per frame
=======
>>>>>>> 59a7e27... Earth Cultrist v1.1.0
    public static float targetLowerBound = 3900f;  // Sqr value, 64.25+100 // 63 
    public static float targetUpperBound = 4900f; // Sqr value, 69.25^2+100  // 70
>>>>>>> e0d0c05... Version 1.0 with load scene bug

    static float arriveTimeConstant = (trackLength - 2 * sliderLength) / (-sliderSpeed);
    static float leaveTimeConstant = (trackLength + sliderLength) / (-sliderSpeed);
>>>>>>> 2a80022... Add Music 'Fade'
    int noteNo = 0;
    float frameCounter = 0f; 

    GameObject[] tracks = new GameObject[trackNum];
    GameObject[] targets = new GameObject[trackNum];
    MeshRenderer[] targetRenders = new MeshRenderer[trackNum];
    Vector3[] slocation = new Vector3[trackNum];
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
    //public Vector3[] targetPosition = new Vector3[trackNum];
>>>>>>> 5960d4d... implement Earth demo
=======
>>>>>>> 7022726... implement game score system and slider dectaction
=======
>>>>>>> 2a80022... Add Music 'Fade'
    Quaternion[] srotation = new Quaternion[trackNum];
    Slider slider; 


    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 40; 
        MusicGameInit();
    }

    // Update is called once per frame
    void FixedUpdate()
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    {    
=======
    {
        /*
        // slider moving speed test
        Vector3 postion = tracks[0].transform.position;
        Debug.Log("sPos:" + postion.y);
        tracks[0].transform.Translate(Vector3.down*0.02f, Space.World);
        postion = tracks[0].transform.position;
        Debug.Log("ePos:" + postion.y);
        */
        
>>>>>>> 5960d4d... implement Earth demo
=======
    {    
>>>>>>> 7022726... implement game score system and slider dectaction
=======
    {    
>>>>>>> 2a80022... Add Music 'Fade'
        frameCounter+= 0.01f;  // Recording current time (frame)
        Game_run();
    }

    private void EarnPoint(int targetType) {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======

        GameObject.Destroy(Slider.sliderModel[sliderIndex], 0f);
        sliderIndex++;

>>>>>>> 7022726... implement game score system and slider dectaction
=======
>>>>>>> d4f12ee...  	ap_effect Connect with Controller and provide single click feature.
=======
>>>>>>> 2a80022... Add Music 'Fade'
        /*
        Color targetColor = new Color(255f, 255f, 255f, 0.8f);
        targetRenders[targetType].material.color = targetColor;
        Invoke("TargetReset", 0.1f);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 2a80022... Add Music 'Fade'
        */

        Debug.Log("Hit" + targetType);

        score[targetType] += unit[targetType] * 0.02f;
        // setup score upper bound
        if(score[targetType] > 1.0f)
            score[targetType] = 1.0f; 
        
        Update_Scores(score[0], score[1], score[2], score[3], score[4]);
    }

    private void LosePoint(int targetType) {
        Debug.Log("Loss: "+ targetType);

        score[targetType] -= unit[targetType] * 0.01f;
        // setup score lower bound
        if(score[targetType] < 0.0f) 
            score[targetType] = 0.0f; 

        Update_Scores(score[0], score[1], score[2], score[3], score[4]);
    }

    void Update_Scores(float S1,float S2,float S3,float S4,float S5)
    {        
        Earth_Color._instance.ground_score = S1;
        Earth_Color._instance.water_score = S2;
        Forest_Change._instance.forest_score = S3;
        Animal_Scaling._instance.animal_score = S4;
        City_Change._instance.city_score = S5;
<<<<<<< HEAD
=======
        Debug.Log("Hit");
=======
        Debug.Log("Hit" + targetType);

        score[targetType] += unit[targetType] * 0.01f;
        /*
>>>>>>> 15b27fb... fixed socre system
        switch (targetType)
        {
            case 0: S1 += unit_1 * 0.01f; break;
            case 1: S2 += unit_2 * 0.01f; break;
            case 2: S3 += unit_3 * 0.01f; break;
            case 3: S4 += unit_4 * 0.01f; break;
            case 4: S5 += unit_5 * 0.01f; break;
            default: break;
        }
        */
=======
        */

        Debug.Log("Hit" + targetType);

        score[targetType] += unit[targetType] * 0.02f;
        // setup score upper bound
        if(score[targetType] > 1.0f)
            score[targetType] = 1.0f; 
        
        Update_Scores(score[0], score[1], score[2], score[3], score[4]);
    }

    private void LosePoint(int targetType) {
        Debug.Log("Loss: "+ targetType);

        score[targetType] -= unit[targetType] * 0.01f;
        // setup score lower bound
        if(score[targetType] < 0.0f) 
            score[targetType] = 0.0f; 

>>>>>>> 7022726... implement game score system and slider dectaction
        Update_Scores(score[0], score[1], score[2], score[3], score[4]);
    }

    void Update_Scores(float S1,float S2,float S3,float S4,float S5)
    {        
        Earth_Color._instance.ground_score = S1;
        Earth_Color._instance.water_score = S2;
        Forest_Change._instance.forest_score = S3;
        Animal_Scaling._instance.animal_score = S4;
        City_Change._instance.city_score = S5;
    }

<<<<<<< HEAD
    private void LosePoint(int targetType) {
<<<<<<< HEAD
        Debug.Log("Loss: "+ targetType);
>>>>>>> 5960d4d... implement Earth demo
=======
        // Debug.Log("Loss: "+ targetType);
>>>>>>> a5b4d00... Adjust the movement direction and simplify Sliders.cs
    }

=======
>>>>>>> 7022726... implement game score system and slider dectaction
=======
    }

>>>>>>> 2a80022... Add Music 'Fade'
    private void MusicGameInit() {
        /* Init tracks*/
        for (int index=0; index<5; index++) {
            string trackName = "Track" + (index+1).ToString();
            string targetName = "Target" + (index+1).ToString();
            tracks[index] = GameObject.Find(trackName);
            targets[index] = GameObject.Find(targetName);
            targetRenders[index] = targets[index].GetComponent<MeshRenderer>();
        }

        /* Init slider*/
        slider = GetComponent<Slider>();

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> a5b4d00... Adjust the movement direction and simplify Sliders.cs
=======
>>>>>>> 2a80022... Add Music 'Fade'
        slocation[0] = new Vector3(-114.91f, 96.42f, 10f);
        slocation[1] = new Vector3(-63.39f, 135.95f, 10f);
        slocation[2] = new Vector3(0f, 150f, 10f);
        slocation[3] = new Vector3(63.39f, 135.95f, 10f);
        slocation[4] = new Vector3(114.91f, 96.42f, 10f);
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 2a80022... Add Music 'Fade'

        srotation[0] = Quaternion.Euler(0f, 0f, 140f);
        srotation[1] = Quaternion.Euler(0f, 0f, 115f);
        srotation[2] = Quaternion.Euler(0f, 0f, 90f);
        srotation[3] = Quaternion.Euler(0f, 0f, 65f);
        srotation[4] = Quaternion.Euler(0f, 0f, 40f);
<<<<<<< HEAD
=======
        slocation[0] = new Vector3(-114.91f, 96.42f, 8f);
        slocation[1] = new Vector3(-63.39f, 135.95f, 8f);
        slocation[2] = new Vector3(0f, 150f, 8f);
        slocation[3] = new Vector3(63.39f, 135.95f, 8f);
        slocation[4] = new Vector3(114.91f, 96.42f, 8f);
=======
>>>>>>> a5b4d00... Adjust the movement direction and simplify Sliders.cs

        srotation[0] = Quaternion.Euler(0f, 0f, 140f);
        srotation[1] = Quaternion.Euler(0f, 0f, 115f);
        srotation[2] = Quaternion.Euler(0f, 0f, 90f);
<<<<<<< HEAD
        srotation[3] = Quaternion.Euler(0f, 0f, -114.228f);
        srotation[4] = Quaternion.Euler(0f, 0f, 40.779f);
>>>>>>> 5960d4d... implement Earth demo
=======
        srotation[3] = Quaternion.Euler(0f, 0f, 65f);
        srotation[4] = Quaternion.Euler(0f, 0f, 40f);
>>>>>>> a5b4d00... Adjust the movement direction and simplify Sliders.cs
=======
>>>>>>> 2a80022... Add Music 'Fade'

        Koreographer.Instance.RegisterForEvents(eventID, TrackEvent);
    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

    void Hited_success(int sliderIndex) {
        GameObject.Destroy(Slider.sliderModel[sliderIndex], 0f);
        EarnPoint(Slider.sliderType[sliderIndex]);
    }
    private void Game_run() {
        int sliderIndex = 0;
        while(sliderIndex < Slider.sliderModel.Count){
            // hited
            if(Slider.sliderModel[sliderIndex] != null
            && Slider.sliderModel[sliderIndex].transform.position.sqrMagnitude>=targetLowerBound
            && Slider.sliderModel[sliderIndex].transform.position.sqrMagnitude<=targetUpperBound)
            {
                // which TracK?
                for (int i =0;i<5;i++)
                {
                    if (Slider.sliderType[sliderIndex] == i && Tap_Effect._instance.taps[i] == true)
                    {
                        Hited_success(sliderIndex);
                    }
                }
            }
            else if(Slider.sliderModel[sliderIndex] != null && Slider.sliderModel[sliderIndex].transform.position.sqrMagnitude < targetLowerBound)
            {
                int type = Slider.sliderType[sliderIndex];
                StartCoroutine(Crash(type));  // lose point when slider crashes
=======
    private void KeybordDection() {
<<<<<<< HEAD
        float currentTime = frameCounter * 100;
        bool[] isKeyPressed = {false, false, false, false, false};

        // detect key D (Note pair 1)
        if(TimingSheet_NotePair1!=null && Input.GetKeyDown(KeyCode.D)) {
            //Debug.Log("current time:" + currentTime);
            isKeyPressed[0] = true;
            bool isHit = false; 
            foreach (SliderTiming stime in TimingSheet_NotePair1) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(0);
                    isHit = true;
                    break;
                } 
            }
            // miss
            if(!isHit) {
                LosePoint(0);
            }
        }

        // detect key K (Note pair 1)
        if(TimingSheet_NotePair1!=null && Input.GetKeyDown(KeyCode.K)) {
            isKeyPressed[4] = true;
            bool isHit = false; 
            foreach (SliderTiming stime in TimingSheet_NotePair1) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(4);
                    isHit = true; 
                    break;
                } 
            }
            // miss
            if(!isHit) {
                LosePoint(4);
            }
        }

        // detect key F (Note pair 2)
        if(TimingSheet_NotePair2!=null && Input.GetKeyDown(KeyCode.F)) {
            isKeyPressed[1] = true;
            bool isHit = false;
            foreach (SliderTiming stime in TimingSheet_NotePair2) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(1);
                    isHit = true; 
                    break;
                } 
            }
            // miss
            if(!isHit) {
                LosePoint(1);
            }
        }

        // detect key J (Note pair 2)
        if(TimingSheet_NotePair2!=null && Input.GetKeyDown(KeyCode.J)) {
            isKeyPressed[3] = true;
            bool isHit = false;
            foreach (SliderTiming stime in TimingSheet_NotePair2) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(3);
                    isHit = true;
                    break;
                } 
            }
            // miss
            if(!isHit) {
                LosePoint(3);
>>>>>>> 5960d4d... implement Earth demo
            }
            ++sliderIndex;
        }
    }

<<<<<<< HEAD
    IEnumerator Crash(int sliderType) {
        // calculate timing of slider crashes on the earth, lose score
        float crashTiming = inverseFPS * (laneRadius - earthRadius) / (-sliderSpeed);
        Debug.Log(crashTiming);
        yield return new WaitForSeconds(crashTiming);
        LosePoint(sliderType);
        //Debug.Log("crash");
=======
        // detect key J (Note pair 2)
        if(TimingSheet_NoteSpace!=null && Input.GetKeyDown(KeyCode.Space)) {
            isKeyPressed[2] = true;
            bool isHit = false;
            foreach (SliderTiming stime in TimingSheet_NoteSpace) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(2);
                    isHit = true; 
                    break;
                } 
            }
            // miss
            if(!isHit) {
                LosePoint(2);
            }
        }

        /* If no key pressed, dectecting miss*/
=======
        //float currentTime = frameCounter * 100;
        HitDetermine();
        MissDetermine();
    }
>>>>>>> 7022726... implement game score system and slider dectaction
=======
>>>>>>> d4f12ee...  	ap_effect Connect with Controller and provide single click feature.
=======
>>>>>>> 2a80022... Add Music 'Fade'

    void Hited_success(int sliderIndex) {
        GameObject.Destroy(Slider.sliderModel[sliderIndex], 0f);
        EarnPoint(Slider.sliderType[sliderIndex]);
    }
    private void Game_run() {
        int sliderIndex = 0;
        while(sliderIndex < Slider.sliderModel.Count){
            // hited
            if(Slider.sliderModel[sliderIndex] != null
            && Slider.sliderModel[sliderIndex].transform.position.sqrMagnitude>=targetLowerBound
            && Slider.sliderModel[sliderIndex].transform.position.sqrMagnitude<=targetUpperBound)
            {
                // which TracK?
                for (int i =0;i<5;i++)
                {
                    if (Slider.sliderType[sliderIndex] == i && Tap_Effect._instance.taps[i] == true)
                    {
                        Hited_success(sliderIndex);
                        // Hited 
                        Tap_Audio_Effect._instance.Tap_Music_Effect();
                        // Tap_Effect._instance.Target_Change_Color_a(i);
                        // Tap_Effect._instance.Lane_Change_Color_a();
                    }
                    else {
                        // Tap_Effect._instance.Lane_Reset_Color_a();
                        // Tap_Effect._instance.Target_Reset_Color_a(i);
                    }
                }
            }
            else if(Slider.sliderModel[sliderIndex] != null && Slider.sliderModel[sliderIndex].transform.position.sqrMagnitude < targetLowerBound)
            {
                int type = Slider.sliderType[sliderIndex];
                StartCoroutine(Crash(type));  // lose point when slider crashes

                // Tap_Effect._instance.Lane_Reset_Color_a();
            }
            ++sliderIndex;
        }
    }

    IEnumerator Crash(int sliderType) {
        // calculate timing of slider crashes on the earth, lose score
        float crashTiming = inverseFPS * (laneRadius - earthRadius) / (-sliderSpeed);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

<<<<<<< HEAD
        // Space
        if(TimingSheet_NoteSpace!=null && !isKeyPressed[2]) {
            foreach (SliderTiming stime in TimingSheet_NoteSpace) {
                // If currently a slider arrives but no related key pressed
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    LosePoint(2);  // lose point in area 2
                    break;
                } 
            }
        }
>>>>>>> 5960d4d... implement Earth demo
=======
=======
        Debug.Log(crashTiming);
>>>>>>> d241e49... adjust target area
=======
        // Debug.Log(crashTiming);
>>>>>>> 59a7e27... Earth Cultrist v1.1.0
        yield return new WaitForSeconds(crashTiming);
        LosePoint(sliderType);
        // Tap_Audio_Effect._instance.Miss_Effect();
        //Debug.Log("crash");
>>>>>>> 7022726... implement game score system and slider dectaction
=======
        Debug.Log(crashTiming);
        yield return new WaitForSeconds(crashTiming);
        LosePoint(sliderType);
        //Debug.Log("crash");
>>>>>>> 2a80022... Add Music 'Fade'
    }

    private void TrackEvent(KoreographyEvent koreographyEvent) { 
        //Debug.Log(trackNo);
        /*
            Slider arrive time = fixed time constant + current time (frame)
            Slider leave time = fixed time constant + current time (frame)
        */
        float aTime = arriveTimeConstant + frameCounter*100;
        float eTime = leaveTimeConstant + frameCounter*100;
        //Debug.Log("aTime:" + aTime);
        //Debug.Log("eTime:" + eTime);
        
        noteNo = Random.Range(0, trackNum);
        //noteNo = 1;
        slider.GenerateSlider(noteNo, slocation[noteNo], srotation[noteNo]);
        //Debug.Log("note: "+noteNo);
        //noteNo = 0;
        /*
        noteNo = Random.Range(0, 3);
        switch(noteNo) {
            case 0:
                slider.GenerateSlider(0, slocation[0], srotation[0]);
                slider.GenerateSlider(4, slocation[4], srotation[4]);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
                TimingSheet_NotePair1.Add(new SliderTiming(aTime, eTime));
>>>>>>> 5960d4d... implement Earth demo
=======
>>>>>>> 7022726... implement game score system and slider dectaction
=======
>>>>>>> 2a80022... Add Music 'Fade'
                break;
            case 1:
                slider.GenerateSlider(1, slocation[1], srotation[1]);
                slider.GenerateSlider(3, slocation[3], srotation[3]);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                break;
            case 2:
                slider.GenerateSlider(2, slocation[2], srotation[2]);
=======
                TimingSheet_NotePair2.Add(new SliderTiming(aTime, eTime));
                break;
            case 2:
                slider.GenerateSlider(2, slocation[2], srotation[2]);
                TimingSheet_NoteSpace.Add(new SliderTiming(aTime, eTime));
>>>>>>> 5960d4d... implement Earth demo
                break;
        }
        */
=======
=======
>>>>>>> 2a80022... Add Music 'Fade'
                break;
            case 2:
                slider.GenerateSlider(2, slocation[2], srotation[2]);
                break;
        }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 7022726... implement game score system and slider dectaction
=======
        */
>>>>>>> d241e49... adjust target area
=======
        */
>>>>>>> 2a80022... Add Music 'Fade'
    }

    private void TargetReset() {
        //Debug.Log("Reset");
        Color targetColor = new Color(0f, 0f, 0f, 1f);
        foreach (MeshRenderer target in targetRenders) {
            target.material.color = targetColor;
        }
        
    }

}