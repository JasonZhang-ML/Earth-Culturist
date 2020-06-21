using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour
{
    private float[] unit = {50f, 50f, 50f, 50f, 50f};
    private float[] score = new float[5];
    public string eventID;
    public float inverseFPS = 0.025f;  // FPS = 40
    public static float earthRadius = 51f; 
    public static float laneRadius = 66f; 
    public static int trackNum = 5; 
    // public static int sliderIndex = 0; 

    public static float sliderLength = 1.5f;
    public static float trackLength = 84f;
    public static float sliderSpeed = -0.6f;  // x position unity per frame
    public static float targetLowerBound = 4220f;  // Sqr value, 64.25+100
    public static float targetUpperBound = 4895.6f; // Sqr value, 69.25^2+100  

    static float arriveTimeConstant = (trackLength - 2 * sliderLength) / (-sliderSpeed);
    static float leaveTimeConstant = (trackLength + sliderLength) / (-sliderSpeed);
    int noteNo = 0;
    float frameCounter = 0f; 

    GameObject[] tracks = new GameObject[trackNum];
    GameObject[] targets = new GameObject[trackNum];
    MeshRenderer[] targetRenders = new MeshRenderer[trackNum];
    Vector3[] slocation = new Vector3[trackNum];
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
    {    
        frameCounter+= 0.01f;  // Recording current time (frame)
        Game_run();
    }

    private void EarnPoint(int targetType) {
        /*
        Color targetColor = new Color(255f, 255f, 255f, 0.8f);
        targetRenders[targetType].material.color = targetColor;
        Invoke("TargetReset", 0.1f);
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

        slocation[0] = new Vector3(-114.91f, 96.42f, 10f);
        slocation[1] = new Vector3(-63.39f, 135.95f, 10f);
        slocation[2] = new Vector3(0f, 150f, 10f);
        slocation[3] = new Vector3(63.39f, 135.95f, 10f);
        slocation[4] = new Vector3(114.91f, 96.42f, 10f);

        srotation[0] = Quaternion.Euler(0f, 0f, 140f);
        srotation[1] = Quaternion.Euler(0f, 0f, 115f);
        srotation[2] = Quaternion.Euler(0f, 0f, 90f);
        srotation[3] = Quaternion.Euler(0f, 0f, 65f);
        srotation[4] = Quaternion.Euler(0f, 0f, 40f);

        Koreographer.Instance.RegisterForEvents(eventID, TrackEvent);
    }


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
            }
            ++sliderIndex;
        }
    }

    IEnumerator Crash(int sliderType) {
        // calculate timing of slider crashes on the earth, lose score
        float crashTiming = inverseFPS * (laneRadius - earthRadius) / (-sliderSpeed);
        Debug.Log(crashTiming);
        yield return new WaitForSeconds(crashTiming);
        LosePoint(sliderType);
        //Debug.Log("crash");
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
                break;
            case 1:
                slider.GenerateSlider(1, slocation[1], srotation[1]);
                slider.GenerateSlider(3, slocation[3], srotation[3]);
                break;
            case 2:
                slider.GenerateSlider(2, slocation[2], srotation[2]);
                break;
        }
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