using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Manager_Random : MonoBehaviour
{
    public float ground_score;
    public float water_score;
    public float forest_score;
    public float animal_score;
    public float city_score;

    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("random_score", 3, 3);
        // Invoke("random_score", 5f);
    }

    // Update is called once per frame  
    void Update()
    {
        // random 
        // InvokeRepeating("random_score", 5f, 5f);
        // Invoke("random_score", 5f);
    }
    public void random_score(){
        float ground_score = Random.Range(0.0f, 1.0f);
        float water_score = Random.Range(0.0f, 1.0f);
        float forest_score = Random.Range(0.0f, 1.0f);
        float animal_score = Random.Range(0.0f, 1.0f);
        float city_score = Random.Range(0.0f, 1.0f);

        Earth_Color._instance.ground_score = ground_score;
        Earth_Color._instance.water_score = water_score;
        Forest_Change._instance.forest_score = forest_score;
        Animal_Scaling._instance.animal_score = animal_score;
        City_Change._instance.city_score = city_score;
    } 

}
