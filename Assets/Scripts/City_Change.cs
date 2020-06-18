using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_Change : MonoBehaviour
{
    public float city_score;
    public static City_Change _instance;
    private void Awake()
    {
        _instance = this;
    }
    public class StoredTransform
    {
        public Vector3      position;
        public Quaternion   rotation;
        public Vector3      localScale;

        public StoredTransform(Transform aTransform, bool world = true)
        {
            position    = world ? aTransform.position : aTransform.localPosition;
            rotation    = world ? aTransform.rotation : aTransform.localRotation;
            localScale  = aTransform.localScale;
        }

        public void Load(Transform aTransform, bool world = true)
        {
            if (world)
            {
                aTransform.position        = position;
                aTransform.rotation        = rotation;
            }
            else
            {
                aTransform.localPosition   = position;
                aTransform.localRotation   = rotation;
            }
            aTransform.localScale      = localScale;
        }
    }
    // GameObject temp = new GameObject();
    GameObject low1, low2;
    GameObject mid1, mid2;
    GameObject high1;
    // Start is called before the first frame update

    void position_switch(string a, string b)
    {

        low1 = GameObject.Find(a);
        high1 = GameObject.Find(b);

        Transform ttr1 = low1.transform; 
        var save1 = new StoredTransform(ttr1);
        save1.Load(ttr1);

        Transform ttr2 = high1.transform; 
        var save2 = new StoredTransform(ttr2);
        save2.Load(ttr2);

        low1.transform.position = save2.position;
        low1.transform.rotation = save2.rotation;

        high1.transform.position = save1.position;
        high1.transform.rotation = save1.rotation;

        // DestroyImmediate(low1); // Instantiate(high1, save.position, save.rotation);
           }
    void Start()
    {
        // position_switch("Low city/House_1", "High city/High_1");
    }

    // Update is called once per frame
    int flag = 0;
    void Update()
    {
        if (city_score < 0.33 && flag != 0) {
            if (flag == 2) {
                position_switch("High city/High_1", "Low city/House_1");
                position_switch("High city/High_2", "Low city/House_2");
                position_switch("High city/High_3", "Low city/House_3");
                position_switch("High city/High_4", "Low city/House_4");
                position_switch("High city/High_5", "Low city/House_5");
                flag = 0;
            }
            else {
                position_switch("Medium city/Shop_1", "Low city/House_1");
                position_switch("Medium city/Shop_2", "Low city/House_2");
                position_switch("Medium city/Shop_3", "Low city/House_3");
                position_switch("Medium city/Shop_4", "Low city/House_4");
                position_switch("Medium city/Shop_5", "Low city/House_5");
                flag = 0;
            }
        }
        else if (0.33 <= city_score && city_score <= 0.66 && flag != 1)
        {
            if (flag == 0){
                position_switch("Low city/House_1","Medium city/Shop_1");
                position_switch("Low city/House_2","Medium city/Shop_2");
                position_switch("Low city/House_3","Medium city/Shop_3");
                position_switch("Low city/House_4","Medium city/Shop_4");
                position_switch("Low city/House_5","Medium city/Shop_5");
                flag = 1;

            }
            else{ // 2
                position_switch("High city/High_1","Medium city/Shop_1");
                position_switch("High city/High_2","Medium city/Shop_2");
                position_switch("High city/High_3","Medium city/Shop_3");
                position_switch("High city/High_4","Medium city/Shop_4");
                position_switch("High city/High_5","Medium city/Shop_5");
                flag = 1;
            }
        }
        else if (city_score > 0.66 && flag != 2){
            if (flag == 1) {
                position_switch("Medium city/Shop_1", "High city/High_1");
                position_switch("Medium city/Shop_2", "High city/High_2");
                position_switch("Medium city/Shop_3", "High city/High_3");
                position_switch("Medium city/Shop_4", "High city/High_4");
                position_switch("Medium city/Shop_5", "High city/High_5");
                flag = 2;
            }
            else { // 0
                position_switch("Low city/House_1", "High city/High_1");
                position_switch("Low city/House_2", "High city/High_2");
                position_switch("Low city/House_3", "High city/High_3");
                position_switch("Low city/House_4", "High city/High_4");
                position_switch("Low city/House_5", "High city/High_5");
                flag = 2;
            }
        }
 
        // }

        // low1 = GameObject.Find("Low city/House_1");
        // high1 = GameObject.Find("High city/High_1");
        // UnityEngine.Object pPrefab = Resources.Load("Assets/Prefab/Items/Key_yellow"); // note: not .prefab!
        // GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, Vector3.zero, Quaternion.identity);
        
    }
}
