using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Gauge : MonoBehaviour {

    public GameObject barrier;
    

    float gauge = 0;
    float gaugeMAX = 1;

    float addGauge = 0.01f;

    GameObject specialGauge;
    
    void Start()
    {
        // オブジェクトの取得
        this.specialGauge = GameObject.Find("Gauge");
        
    }
    
    void Update()
    {
        ADDgauge();
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
            //バリア生成
            Vector3 tmp = GameObject.Find("Player").transform.position;
            GameObject go = Instantiate(barrier);
            go.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

            //ゲージの初期化
            this.specialGauge.GetComponent<Image>().fillAmount = 0;
            gauge = 0;
        }
    }

}
