using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    BoxCollider[]  Tracks_Boxes  = new BoxCollider[5];
    void Start()
    {
        for (int track_id = 1; track_id<= 5; track_id++){
            GameObject go = GameObject.Find("Track" + track_id.ToString());
            Tracks_Boxes[track_id-1] = go.GetComponent<BoxCollider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetTouch(0).deltaPosition.sqrMagnitude >= new Vector2(0.01f, 0.01f).sqrMagnitude)
        // {
        	//单指触屏移动
        	// if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        	// {
        	// 	Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        	// 	_map.Translate(touchDeltaPosition.x * 5, -touchDeltaPosition.y * 5, 0);
        	// }
        // }
        if (Input.GetMouseButton(0) == true)
        {
            Vector2 pos = Input.mousePosition;
            for (int track_id = 0; track_id <= 4; track_id++){
                if (WhichTrackOnTap(pos, track_id) >= 0)
                {
                    Debug.Log(track_id);
                    Track_Change_Color_a(track_id);
                }
            }
        }
        else
        {
            for (int i = 0; i <= 4; i++)
                Track_Reset_Color_a(i);
        }
        if (Input.GetMouseButton(1) == true)
        {
            // DeBug Code
            Debug.Log(Input.mousePosition);
        }
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

    int WhichTrackOnTap(Vector3 pos, int track_id)
    {
        if (Input.multiTouchEnabled == true)
        {
            //
        }
        Vector2[] screens = new Vector2[4];
        Vector3[] vertexes  = new Vector3[4];

        vertexes = GetBoxColliderVertexPositions(Tracks_Boxes[track_id]);
        for (int i = 0; i < 4; i++)
        {
            screens[i] = Camera.main.WorldToScreenPoint(vertexes[i]);
        }

        bool isInRect = false;
        isInRect =  PointinTriangle(screens[0], screens[1], screens[2], pos) || PointinTriangle(screens[1], screens[2], screens[3], pos);
        // // debug code
        // if( track_id == 0)
        // {
        //     for(int i =0;i<=3;i++)
        //         Debug.Log("Lane1:" + screens[i].ToString());
        // }
        
        if (isInRect == true)
            return track_id;
        else
            return -1;
    }

    void Track_Change_Color_a(int track_id)
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

}
 