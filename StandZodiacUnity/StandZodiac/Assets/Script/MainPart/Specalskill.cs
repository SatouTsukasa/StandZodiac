using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Specalskill : MonoBehaviour
{

    void Start()
    {
    }
    
    void Update()
    {
    }

    //ボタンを押したときの関数呼び出し
    public void GetBotton()
    {
        GameObject ob_Gauge = GameObject.Find("Gauge");
        ob_Gauge.GetComponent<Gauge>().Specialskil();
    }
    
}
