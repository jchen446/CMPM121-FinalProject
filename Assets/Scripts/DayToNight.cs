using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayToNight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //should change the x axis in rotation every second
        this.transform.Rotate(Vector3.right * (Time.deltaTime * 10));
    }
}
