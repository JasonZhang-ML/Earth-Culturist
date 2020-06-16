using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_test : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform TreeTransform;
    public Vector3 scaleChange;
    void Start()
    {
        TreeTransform = GetComponentInChildren<Transform>();
        scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        // TreeTransform.TransformDirection();
        TreeTransform.transform.localScale += scaleChange;
        
    }
}
