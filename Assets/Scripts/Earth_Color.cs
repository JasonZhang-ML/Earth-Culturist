using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Color : MonoBehaviour
{
    // Eanble other scripts call
    public static Earth_Color _instance;
    private void Awake()
    {
        _instance = this;
    }
    public float ground_score;
    public float water_score;

    // Ground color change from brown to green
    Color brown = new Color(0.553f, 0.364f, 0.086f, 1f);
    Color green = new Color(0.086f, 0.553f, 0.114f, 1f);

    // Water color from yellow to blue
    Color yellow = new Color(0.705f, 1f, 0f, 1f);
    Color blue = new Color(0f, 0.694f, 1f, 1f);
    Color Normalization_inverse(Color a, Color b, float score)
    {
        float R = score * (b.r - a.r) + a.r;
        float G = score * (b.g - a.g) + a.g;
        float B = score * (b.b - a.b) + a.b;

        return new Color(R,G,B,1f);
    }

    void set_color_score(float ground, float water){
        ground_score = ground;
        water_score = water;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Color ground_change = Normalization_inverse(brown, green, ground_score);
        Color water_change = Normalization_inverse(yellow, blue, water_score);

        Color e = GetComponent<MeshRenderer>().materials[1].color;
        Color w = GetComponent<MeshRenderer>().materials[0].color;

        GetComponent<MeshRenderer>().materials[1].color = Color.Lerp(e, ground_change, Time.deltaTime * 0.5f);           
        GetComponent<MeshRenderer>().materials[0].color = Color.Lerp(w, water_change, Time.deltaTime * 0.5f); 
    }

}
