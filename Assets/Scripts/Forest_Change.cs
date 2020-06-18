using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_Change : MonoBehaviour
{
    // Start is called before the first frame update
    public static Forest_Change _instance;
    private void Awake()
    {
        _instance = this;
    }

    public float forest_score; 
    Vector3 increment;
    // Start is called before the first frame update
    void Start()
    {
        increment = new Vector3(0.01f, 0.01f, 0.01f);
    }
    Vector3 Normalization(Vector3 max, Vector3 min, float score)
    {
        float R = score * (max.x - min.x) + min.x;
        return new Vector3(R,R,R);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ScaleMax = new Vector3(1.7f,1.7f,1.7f);
        Vector3 ScaleMin = new Vector3(0.7f,0.7f,0.7f);
        Vector3 ScaleChange =  Normalization(ScaleMax, ScaleMin, forest_score);

        // Debug.Log(ScaleMax.sqrMagnitude);
        foreach (Transform child in transform)
        {
            if (child.localScale.sqrMagnitude - ScaleChange.sqrMagnitude < 0.05){
                child.localScale += increment;
            }
            else if (child.localScale.sqrMagnitude - ScaleChange.sqrMagnitude >= 0.05) {
                child.localScale -= increment;

            }
        }       
        
    }
}
