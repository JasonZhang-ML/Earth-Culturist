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
    public float destroy_radius_sqr = 2600f;

    private void Awake() {

    }

    private void FixedUpdate() {
        //Debug.Log("Moving");
        SliderMove_Destroy();
    }

    public void GenerateSlider(int type, Vector3 location, Quaternion rotation) {
        sliderModel.Add(Instantiate(sliderPrefab[type], location, rotation) as GameObject);
        sliderType.Add(type);
        //sliderNum++;
    }

    private void SliderMove_Destroy() {
        if(sliderModel!=null) {
            for(int i=0; i<sliderModel.Count; i++) {
                if(sliderModel[i]!=null) {
                    sliderModel[i].transform.Translate(Vector3.right * Time.deltaTime * Controller.sliderSpeed, Space.Self);
                    // destroy slider when it out of hit the earth                                                       
                    if(sliderModel[i].transform.position.sqrMagnitude <= destroy_radius_sqr)
                        GameObject.Destroy(sliderModel[i], 0.001f);
                }
            }
        }
    }
}