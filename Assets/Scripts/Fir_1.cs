using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fir_1 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public Transform TreeTransform;
    public Vector3 scaleChange;
    void Start()
    {
        player = GameObject.FindWithTag("Trees");
        // Debug.Log(player);
        // TreeTransform = GetComponent<Transform>();
        scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.deltaTime);
        // transform.Translate(Vector3.forward*Time.deltaTime);
        // transform.localScale += scaleChange;
        
    }
}
