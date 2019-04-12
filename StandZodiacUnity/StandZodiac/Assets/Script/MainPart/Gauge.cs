using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Gauge : MonoBehaviour {

    float gauge = 0;
    float gaugeMAX = 1;

    float addGauge = 0.01f;

    GameObject specialGauge;

    // Start is called before the first frame update
    void Start()
    {
        this.specialGauge = GameObject.Find("Gauge");   
    }

    // Update is called once per frame
    void Update()
    {
        //ADDgauge();
    }

    //敵に攻撃したときに呼び出す
    public void ADDgauge()
    {
        if (gauge <= gaugeMAX) {
            gauge = gauge + addGauge;
            this.specialGauge.GetComponent<Image>().fillAmount += addGauge;
        }
    }
    //必殺技の処理
    public void Specialskil()
    {
        if (gauge >= gaugeMAX)
        {
            Debug.Log("発射完了");
        }
    }

}
