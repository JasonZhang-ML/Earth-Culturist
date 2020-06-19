using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public GameObject[] sliderPrefab = new GameObject[Controller.trackNum]; 
    //GameObject[] sliderModel; 
    List<GameObject> sliderModel = new List<GameObject>();
    List<int> sliderType = new List<int>();
    //int sliderNum = 0; 

    private void Awake() {

    }

    private void FixedUpdate() {
        //Debug.Log("Moving");
        SliderMove();
    }

    public void GenerateSlider(int type, Vector3 location, Quaternion rotation) {
        sliderModel.Add(Instantiate(sliderPrefab[type], location, rotation) as GameObject);
        sliderType.Add(type);
        //sliderNum++;
    }

    private void SliderMove() {
        if(sliderModel!=null) {
            /*
            foreach (GameObject slider in sliderModel) {
                //slider.transform.localRotation = Quaternion.Euler(0, -25f, 0);
                //slider.transform.Translate(Vector3.forward*Controller.sliderSpeed, Space.World);
                slider.transform.position = Vector3.MoveTowards(slider.transform.position,
                                                                new Vector3(-48.96f, 44.29f, 8f), 
                                                                Controller.sliderSpeed);
            }
            */
            //Debug.Log("counter:" + sliderModel.Count);
            for(int i=0; i<sliderModel.Count; i++) {
                if(sliderModel[i]!=null) {
                    switch(sliderType[i]) {
                        case 0: 
                            sliderModel[i].transform.position = Vector3.MoveTowards(sliderModel[i].transform.position,
                                                                                    new Vector3(-48.96f, 44.29f, 8f), 
                                                                                    Controller.sliderSpeed);
                            // destroy slider when it hits the target                                                       
                            if(sliderModel[i].transform.position == new Vector3(-48.96f, 44.29f, 8f))
                                GameObject.Destroy(sliderModel[i], 0.001f);
                            break;
                        case 1: 
                            sliderModel[i].transform.position = Vector3.MoveTowards(sliderModel[i].transform.position,
                                                                                    new Vector3(-26.9f, 60.38f, 8f), 
                                                                                    Controller.sliderSpeed);
                            // destroy slider when it hits the target
                            if(sliderModel[i].transform.position == new Vector3(-26.9f, 60.38f, 8f))
                                GameObject.Destroy(sliderModel[i], 0.001f);
                            break;
                        case 2: 
                            sliderModel[i].transform.position = Vector3.MoveTowards(sliderModel[i].transform.position,
                                                                                    new Vector3(0f, 66f, 8f), 
                                                                                    Controller.sliderSpeed);
                            // destroy slider when it hits the target
                            if(sliderModel[i].transform.position == new Vector3(0f, 66f, 8f))
                                GameObject.Destroy(sliderModel[i], 0.001f);
                            break;
                        case 3: 
                            sliderModel[i].transform.position = Vector3.MoveTowards(sliderModel[i].transform.position,
                                                                                    new Vector3(26.9f, 60.38f, 8f), 
                                                                                    Controller.sliderSpeed);
                            // destroy slider when it hits the target                                                        
                            if(sliderModel[i].transform.position == new Vector3(26.9f, 60.38f, 8f))
                                GameObject.Destroy(sliderModel[i], 0.001f);
                            break;
                        case 4: 
                            sliderModel[i].transform.position = Vector3.MoveTowards(sliderModel[i].transform.position,
                                                                                    new Vector3(48.96f, 44.29f, 8f), 
                                                                                    Controller.sliderSpeed);
                            // destroy slider when it hits the target                                                       
                            if(sliderModel[i].transform.position == new Vector3(48.96f, 44.29f, 8f))
                                GameObject.Destroy(sliderModel[i], 0.001f);
                            break;
                    }
                }
            }
        }
    }
}