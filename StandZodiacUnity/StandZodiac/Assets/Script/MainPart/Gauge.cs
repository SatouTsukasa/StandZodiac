using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Gauge : MonoBehaviour {

    public GameObject barrier;

    bool dec_Flag = false;

    float oneTime;
    float n_gauge = 0;
    float gaugeMAX = 1;

    float addGauge = 0.1f;

    GameObject special_Gauge;
    
    void Start()
    {
        // オブジェクトの取得
        this.special_Gauge = GameObject.Find("Gauge");
    }
    
    void Update()
    {
        //ADDgauge();
        
        if (dec_Flag == true)
        {
            //ゲージの初期化
            n_gauge -= 0.001666667f;
            this.special_Gauge.GetComponent<Image>().fillAmount = n_gauge;
            if (n_gauge == 0)
            {
                dec_Flag = false;
            }
        }
    }

    //敵に攻撃したときに呼び出す
    public void ADDgauge()
    {
        if (n_gauge <= gaugeMAX && dec_Flag == false) {
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

            dec_Flag = true;
        }
    }

}
