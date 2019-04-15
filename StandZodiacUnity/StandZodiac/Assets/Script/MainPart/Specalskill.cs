using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specalskill : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //ボタンを押したときの関数呼び出し
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Gauge = GameObject.Find("Gauge");
            Gauge.GetComponent<Gauge>().Specialskil();
        }
    }

}
