using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hokuto_Zin : MonoBehaviour
{
    float time;
    float plus;
    Vector3 Scale;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        plus = 0.2f;
        //Scale = GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        Debug.Log(time);
        if (time <= 3)
        {
            transform.localScale = new Vector3(transform.localScale.x + plus, transform.localScale.y + plus, 1);
        }
        
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
    }
}
