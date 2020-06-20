using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonUp (0)) {
			// Camera.main.ScreenToWorldPoint (Input.mousePosition);
            Debug.Log(Input.mousePosition);
            // Camera.main.WorldToScreenPoint(m_ui.localPosition);
            // Debug.Log(Camera.main.ScreenToWorldPoint (Input.mousePosition));
		} 
        
    }
}
 