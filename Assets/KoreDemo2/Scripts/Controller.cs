using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour
{
    public float S1, S2, S3, S4, S5 = 0f;
    private float unit_1,unit_2,unit_3,unit_4,unit_5 = 40f; 
    public string eventID;
    public static int trackNum = 5; 

    public static float sliderLength = 1.09f;
    public static float trackLength = 84f;

    public static float sliderSpeed = 0.5f;  // x position unity per frame

    static float arriveTimeConstant = (trackLength - 2 * sliderLength) / sliderSpeed;
    static float leaveTimeConstant = (trackLength + sliderLength) / sliderSpeed;
    int noteNo = 0;
    float frameCounter = 0f; 

    public class SliderTiming {
        float arriveTime = 0f;  // arrive time
        float leaveTime = 0f;  // leave time

        public SliderTiming(float aT, float eT) {
            arriveTime = aT;
            leaveTime = eT; 
        }

        public float getArriveTiming() {
            return arriveTime;
        }

        public float getLeaveTiming() {
            return leaveTime;
        }
    }

    GameObject[] tracks = new GameObject[trackNum];
    GameObject[] targets = new GameObject[trackNum];
    //MeshRenderer[] trackRenders = new MeshRenderer[trackNum];
    MeshRenderer[] targetRenders = new MeshRenderer[trackNum];
    Vector3[] slocation = new Vector3[trackNum];
    //public Vector3[] targetPosition = new Vector3[trackNum];
    Quaternion[] srotation = new Quaternion[trackNum];
    Slider slider; 
    List<SliderTiming> TimingSheet_NotePair1 = new List<SliderTiming>();
    List<SliderTiming> TimingSheet_NotePair2 = new List<SliderTiming>();
    List<SliderTiming> TimingSheet_NoteSpace = new List<SliderTiming>();


    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 40; 
        MusicGameInit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        // slider moving speed test
        Vector3 postion = tracks[0].transform.position;
        Debug.Log("sPos:" + postion.y);
        tracks[0].transform.Translate(Vector3.down*0.02f, Space.World);
        postion = tracks[0].transform.position;
        Debug.Log("ePos:" + postion.y);
        */
        
        frameCounter+= 0.01f;  // Recording current time (frame)
        KeybordDection();
    }

    private void EarnPoint(int targetType) {
        Color targetColor = new Color(255f, 255f, 255f, 0.8f);
        targetRenders[targetType].material.color = targetColor;
        Invoke("TargetReset", 0.1f);
        Debug.Log("Hit");
        switch (targetType)
        {
            case 0: S1 += unit_1 * 0.01f; break;
            case 1: S2 += unit_2 * 0.01f; break;
            case 2: S3 += unit_3 * 0.01f; break;
            case 3: S4 += unit_4 * 0.01f; break;
            case 4: S5 += unit_5 * 0.01f; break;
            default: break;
        }
        Update_Scores(S1, S2, S3, S4, S5);
    }

    void Update_Scores(float S1,float S2,float S3,float S4,float S5)
    {        
        Earth_Color._instance.ground_score = S1;
        Earth_Color._instance.water_score = S2;
        Forest_Change._instance.forest_score = S3;
        Animal_Scaling._instance.animal_score = S4;
        City_Change._instance.city_score = S5;
    }

    private void LosePoint(int targetType) {
        Debug.Log("Loss: "+ targetType);
    }

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

        slocation[0] = new Vector3(-114.91f, 96.42f, 8f);
        slocation[1] = new Vector3(-63.39f, 135.95f, 8f);
        slocation[2] = new Vector3(0f, 150f, 8f);
        slocation[3] = new Vector3(63.39f, 135.95f, 8f);
        slocation[4] = new Vector3(114.91f, 96.42f, 8f);

        srotation[0] = Quaternion.Euler(0f, 0f, -40.779f);
        srotation[1] = Quaternion.Euler(0f, 0f, 114.228f);
        srotation[2] = Quaternion.Euler(0f, 0f, 90f);
        srotation[3] = Quaternion.Euler(0f, 0f, -114.228f);
        srotation[4] = Quaternion.Euler(0f, 0f, 40.779f);

        Koreographer.Instance.RegisterForEvents(eventID, TrackEvent);
    }

    private void KeybordDection() {
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
            }
        }

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

        // Pair1: D
        if(TimingSheet_NotePair1!=null && !isKeyPressed[0]) {
            foreach (SliderTiming stime in TimingSheet_NotePair1) {
                // If currently a slider leaves but no related key pressed
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    LosePoint(0);  // lose point in area 0
                    break;
                } 
            }
        }

        // Pair1: K
        if(TimingSheet_NotePair1!=null && !isKeyPressed[4]) {
            foreach (SliderTiming stime in TimingSheet_NotePair1) {
                // If currently a slider arrives but no related key pressed
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    LosePoint(4);  // lose point in area 4
                    break;
                } 
            }
        }

        // Pair2: F
        if(TimingSheet_NotePair2!=null && !isKeyPressed[1]) {
            foreach (SliderTiming stime in TimingSheet_NotePair2) {
                // If currently a slider arrives but no related key pressed
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    LosePoint(1);  // lose point in area 1
                    break;
                } 
            }
        }

        // Pair2: J
        if(TimingSheet_NotePair2!=null && !isKeyPressed[3]) {
            foreach (SliderTiming stime in TimingSheet_NotePair2) {
                // If currently a slider arrives but no related key pressed
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    LosePoint(3);  // lose point in area 3
                    break;
                } 
            }
        }

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
        
        noteNo = Random.Range(0, 3);
        //Debug.Log("note: "+noteNo);
        //noteNo = 0;
        switch(noteNo) {
            case 0:
                slider.GenerateSlider(0, slocation[0], srotation[0]);
                slider.GenerateSlider(4, slocation[4], srotation[4]);
                TimingSheet_NotePair1.Add(new SliderTiming(aTime, eTime));
                break;
            case 1:
                slider.GenerateSlider(1, slocation[1], srotation[1]);
                slider.GenerateSlider(3, slocation[3], srotation[3]);
                TimingSheet_NotePair2.Add(new SliderTiming(aTime, eTime));
                break;
            case 2:
                slider.GenerateSlider(2, slocation[2], srotation[2]);
                TimingSheet_NoteSpace.Add(new SliderTiming(aTime, eTime));
                break;
        }

        //slider.GenerateSlider(noteNo, slocation[noteNo], srotation);

        /*
        Color trackColor = new Color(255f, 255f, 255f, 0.3f);
        trackRenders[0].material.color = trackColor;
        Invoke("TrackReset", 0.2f);
        */
    }

    private void TargetReset() {
        //Debug.Log("Reset");
        Color targetColor = new Color(0f, 0f, 0f, 1f);
        foreach (MeshRenderer target in targetRenders) {
            target.material.color = targetColor;
        }
        
    }

}