using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class BallTest : MonoBehaviour
{
    public string eventID;
    public Transform ballTransform;
    public Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = GetComponentInChildren<Transform>();
        scaleChange = new Vector3(2f, 2f, 2f);
        Koreographer.Instance.RegisterForEvents(eventID, BallEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BallEvent(KoreographyEvent koreographyEvent) {
        BallUp();
        //Invoke("BallDown", 0.4f);
    }

    private void BallUp() {
        ballTransform.transform.localScale += scaleChange;
    }

    private void BallDown() {
        ballTransform.transform.localScale -= scaleChange;
    }

    
}
