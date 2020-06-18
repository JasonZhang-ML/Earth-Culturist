using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public GameObject[] sliderPrefab = new GameObject[Controller.trackNum]; 
    //GameObject[] sliderModel; 
    List<GameObject> sliderModel = new List<GameObject>();
    //int sliderNum = 0; 

    private void Awake() {

    }

    private void Update() {
        //Debug.Log("Moving");
        SliderMove();
    }

    public void GenerateSlider(int type, Vector3 location, Quaternion rotation) {
        sliderModel.Add(Instantiate(sliderPrefab[type], location, rotation) as GameObject);
        //sliderNum++;
    }

    private void SliderMove() {
        foreach (GameObject slider in sliderModel) {
            if (slider != null)
                slider.transform.Translate(Vector3.down*Controller.sliderSpeed, Space.World);
        }
    }
}