using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Gauge : MonoBehaviour {

    public GameObject barrier;
    

    float n_gauge = 0;
    float gaugeMAX = 1;

    float addGauge = 0.01f;

    GameObject special_Gauge;
    
    void Start()
    {
        // オブジェクトの取得
        this.special_Gauge = GameObject.Find("Gauge");
    }
    
    void Update()
    {
        ADDgauge();
    }

    //敵に攻撃したときに呼び出す
    public void ADDgauge()
    {
        if (n_gauge <= gaugeMAX) {
            n_gauge = n_gauge + addGauge;
            this.special_Gauge.GetComponent<Image>().fillAmount += addGauge;
        }
    }

    //必殺技の処理
    public void Specialskil()
    {
        if (n_gauge >= gaugeMAX)
        {
            //バリア生成
            Vector3 p_pos = GameObject.Find("Player").transform.position;

            GameObject sc_barrier = Instantiate(barrier);
            sc_barrier.transform.position = new Vector3(p_pos.x, p_pos.y, p_pos.z);

            //ゲージの初期化
            this.special_Gauge.GetComponent<Image>().fillAmount = 0;
            n_gauge = 0;
        }
    }

}
