using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour
{
    public string eventID;
    public static int trackNum = 5; 

    public static float sliderLength = 0.2f;
    public static float trackLength = 4f;

    public static float sliderSpeed = 0.05f;  // x position unity per frame

    static float arriveTimeConstant = (trackLength - 2 * sliderLength) / sliderSpeed;
    static float leaveTimeConstant = trackLength / sliderSpeed;
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
    Quaternion srotation = Quaternion.Euler(0f, 0f, -90f);
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
    void Update()
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
        //Debug.Log("Hit");
    }

    private void LosePoint() {

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

        slocation[0] = new Vector3(2f, 5.9f, 1.4f);
        slocation[1] = new Vector3(3.5f, 5.9f, 1.4f);
        slocation[2] = new Vector3(5f, 5.9f, 1.4f);
        slocation[3] = new Vector3(6.5f, 5.9f, 1.4f);
        slocation[4] = new Vector3(8f, 5.9f, 1.4f);

        Koreographer.Instance.RegisterForEvents(eventID, TrackEvent);
    }

    private void KeybordDection() {
        float currentTime = frameCounter * 100;

        // detect key D (Note pair 1)
        if(TimingSheet_NotePair1!=null && Input.GetKeyDown(KeyCode.D)) {
            //Debug.Log("current time:" + currentTime);
            foreach (SliderTiming stime in TimingSheet_NotePair1) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(0);
                }
            }
        }

        // detect key K (Note pair 1)
        if(TimingSheet_NotePair1!=null && Input.GetKeyDown(KeyCode.K)) {
            foreach (SliderTiming stime in TimingSheet_NotePair1) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(4);
                }
            }
        }

        // detect key F (Note pair 2)
        if(TimingSheet_NotePair2!=null && Input.GetKeyDown(KeyCode.F)) {
            foreach (SliderTiming stime in TimingSheet_NotePair2) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(1);
                }
            }
        }

        // detect key J (Note pair 2)
        if(TimingSheet_NotePair2!=null && Input.GetKeyDown(KeyCode.J)) {
            foreach (SliderTiming stime in TimingSheet_NotePair2) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(3);
                }
            }
        }

        // detect key J (Note pair 2)
        if(TimingSheet_NoteSpace!=null && Input.GetKeyDown(KeyCode.Space)) {
            foreach (SliderTiming stime in TimingSheet_NoteSpace) {
                // hit
                if (currentTime >= stime.getArriveTiming() && currentTime <= stime.getLeaveTiming()) {
                    EarnPoint(2);
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
                slider.GenerateSlider(0, slocation[0], srotation);
                slider.GenerateSlider(4, slocation[4], srotation);
                TimingSheet_NotePair1.Add(new SliderTiming(aTime, eTime));
                break;
            case 1:
                slider.GenerateSlider(1, slocation[1], srotation);
                slider.GenerateSlider(3, slocation[3], srotation);
                TimingSheet_NotePair2.Add(new SliderTiming(aTime, eTime));
                break;
            case 2:
                slider.GenerateSlider(2, slocation[2], srotation);
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