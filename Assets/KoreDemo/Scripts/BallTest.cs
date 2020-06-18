using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class BallTest : MonoBehaviour
{
    public string eventID;
    public GameObject ball;
    public MeshRenderer ballRender;
    public Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Sphere");
        ballRender = ball.GetComponent<MeshRenderer>();
        Koreographer.Instance.RegisterForEvents(eventID, BallEvent);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BallEvent(KoreographyEvent koreographyEvent) {
        Color ballColor = new Color(123f, 100f, 233f, 0.3f);
        ballRender.material.color = ballColor;
        Invoke("BallReset", 0.2f);
    }

    private void BallReset() {
        Color ballColor = new Color(0f, 0f, 0f, 0.3f);
        ballRender.material.color = ballColor;
    }

}
