using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightingControl : MonoBehaviour
{

    private HighlightableObject slider; 

    private void Awake() {
        slider = GetComponent<HighlightableObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //slider.ConstantOn(Color.yellow);
        //slider.ConstantOff();
        slider.FlashingOn(Color.green, Color.yellow, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
