﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Specalskill : MonoBehaviour
{
    /*
    void Start()
    {
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Gauge = GameObject.Find("Gauge");
            Gauge.GetComponent<Gauge>().Specialskil();
        }
    }
    */
    //ボタンを押したときの関数呼び出し
    public void GetBotton()
    {
        GameObject Gauge = GameObject.Find("Gauge");
        Gauge.GetComponent<Gauge>().Specialskil();
    }
}
