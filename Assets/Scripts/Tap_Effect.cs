using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static Tap_Effect _instance;
    private void Awake()
    {
        _instance = this;
    }


    BoxCollider[]  Tracks_Boxes  = new BoxCollider[5];

    public bool[] taps = new bool[5];

    void Start()
    {
        for (int track_id = 1; track_id<= 5; track_id++){
            GameObject go = GameObject.Find("Track" + track_id.ToString());
            Tracks_Boxes[track_id-1] = go.GetComponent<BoxCollider>();
        }
    }

    // public int IsOnTap()
    // {

    // }

    // Update is called once per frame
    void Update()
    {

        // int i = 0;
        // while(i < Input.touchCount){
        //     Touch t = Input.GetTouch(i);
        //     if(t.phase == TouchPhase.Began){
        //         Debug.Log("touch began");
        //         touches.Add(new touchLocation(t.fingerId, createCircle(t)));
        //     }else if(t.phase == TouchPhase.Ended){
        //         Debug.Log("touch ended");
        //         touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
        //         Destroy(thisTouch.circle);
        //         touches.RemoveAt(touches.IndexOf(thisTouch));
        //     }else if(t.phase == TouchPhase.Moved){
        //         Debug.Log("touch is moving");
        //         touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
        //         thisTouch.circle.transform.position = getTouchPosition(t.position);
        //     }
        //     ++i;
        // }
        Vector2 pos = Input.mousePosition;
        bool[] result_on_track = WhichTrackOnTap(pos);
        KeyCode[] Keys = new KeyCode[5]{KeyCode.D, KeyCode.F, KeyCode.Space, KeyCode.J, KeyCode.K};

        for (int i = 0; i <=4; i++)
        {
            if ((Input.GetMouseButton(0) == true && result_on_track[i] == true) || Input.GetKey(Keys[i]) == true)
            {
                Track_Change_Color_a(i);
            }
            else{
                Track_Reset_Color_a(i);
            }
        }


        for (int i = 0; i <=4; i++)
        {
            if ((Input.GetMouseButtonDown(0) == true && result_on_track[i] == true) || Input.GetKeyDown(Keys[i]) == true)
            {
                taps[i] = true;
            }
            else{
                taps[i] = false;
            }
        }
        Tap_Effect._instance.Lane_Reset_Color_a();
    }
    Vector3[] GetBoxColliderVertexPositions (BoxCollider boxcollider) 
    {
        var vertices = new Vector3[4];
        // Down side to the earth ground y = -0.33333f * 0.5f , left and right
        vertices[0] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, -0.33333f, boxcollider.size.z) * 0.5f);
        vertices[1] = boxcollider.transform.TransformPoint( boxcollider.center + new Vector3(-boxcollider.size.x, -0.33333f, boxcollider.size.z) * 0.5f);
        // Up side left and right
        vertices[2] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
        vertices[3] = boxcollider.transform.TransformPoint( boxcollider.center + new Vector3(-boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
        return vertices;
    } 

    bool PointinTriangle(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
    {
        Vector2 v0 = C - A ;
        Vector2 v1 = B - A ;
        Vector2 v2 = P - A ;
        
        float dot00 = Vector2.Dot(v0, v0);
        float dot01 = Vector2.Dot(v0, v1);
        float dot02 = Vector2.Dot(v0, v2);
        float dot11 = Vector2.Dot(v1, v1);
        float dot12 = Vector2.Dot(v1, v2);

        float inverDeno = 1 / (dot00 * dot11 - dot01 * dot01) ;

        float u = (dot11 * dot02 - dot01 * dot12) * inverDeno ;
        if (u < 0 || u > 1) // if u out of range, return directly
        {
            return false ;
        }

        float v = (dot00 * dot12 - dot01 * dot02) * inverDeno ;
        if (v < 0 || v > 1) // if v out of range, return directly
        {
            return false ;
        }
        return u + v <= 1 ;
    }

    bool[] WhichTrackOnTap(Vector3 pos)
    {
        bool[] isOnTrack =  new bool[5];
        if (Input.multiTouchEnabled == true)
        {
            //
        }
        Vector2[] screens = new Vector2[4];
        Vector3[] vertexes  = new Vector3[4];

        for (int i = 0; i <= 4; i++){
            vertexes = GetBoxColliderVertexPositions(Tracks_Boxes[i]);
            for (int j = 0; j < 4; j++)
            {
                screens[j] = Camera.main.WorldToScreenPoint(vertexes[j]);
            }
            bool isInRect = false;
            isInRect =  PointinTriangle(screens[0], screens[1], screens[2], pos) || PointinTriangle(screens[1], screens[2], screens[3], pos);
            isOnTrack[i] = isInRect;
        }
        return isOnTrack;
    }

    public void Track_Change_Color_a(int track_id)
    {
        GameObject go = GameObject.Find("Track" + (track_id + 1).ToString());
        Color w = go.GetComponent<MeshRenderer>().material.color;
        w.a = 0.588f;
        go.GetComponent<MeshRenderer>().materials[0].color = w;
    }

    void Track_Reset_Color_a(int track_id)
    {
        GameObject go = GameObject.Find("Track" + (track_id + 1).ToString());
        Color w = go.GetComponent<Renderer>().materials[0].color;
        w.a = 0.196f;
        go.GetComponent<MeshRenderer>().materials[0].color = w;
    }
    public void Target_Change_Color_a(int target_id)
    {
        GameObject go = GameObject.Find("Target" + (target_id + 1).ToString());
        Color w = go.GetComponent<MeshRenderer>().material.color;
        w.a = 0.784f;
        go.GetComponent<MeshRenderer>().materials[0].color = w;
    }

    public void Target_Reset_Color_a(int target_id)
    {
        GameObject go = GameObject.Find("Target" + (target_id + 1).ToString());
        Color w = go.GetComponent<Renderer>().materials[0].color;
        w.a = 0.078f;
        go.GetComponent<MeshRenderer>().materials[0].color = w;
    }
    public void Lane_Change_Color_a()
    {
        GameObject go = GameObject.Find("Target Lane");
        Color w = go.GetComponent<MeshRenderer>().material.color;
        w.a = 0.392f;
        go.GetComponent<MeshRenderer>().materials[0].color = w;
    }
    public void Lane_Reset_Color_a()
    {
        GameObject go = GameObject.Find("Target Lane");
        Color w = go.GetComponent<Renderer>().materials[0].color;
        w.a = 0.117f;
        go.GetComponent<MeshRenderer>().materials[0].color = w;
    }
}
 