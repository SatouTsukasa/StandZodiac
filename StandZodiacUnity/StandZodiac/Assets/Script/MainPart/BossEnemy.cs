using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class BossEnemy : MonoBehaviour
{

    Enemy enemy;

    public float width;

    int Hp;
    GameObject Player;
    
    //ふたご座
    public bool Hutago;
    public GameObject HutagoSister;

    private bool HutagoH;
    private bool mea_flg;

    ///HutagoSister用--------------
    GameObject HSister;
    public bool HutagoS;
    //半径
    public float radius;
    ///----------------------------

    //かに座-----------------------
    public bool Kani;
    public GameObject Bubble;
    private float rate;
    private float rate_span;
    private float intense_rate;
    //-----------------------------

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        HutagoH = true;
        Hp = enemy.hp;
        Player = GameObject.Find("Player");
        intense_rate = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player);
        if (enemy.hp <= Hp / 2)
        {
            if (Hutago == true)
            {
                if (HutagoH == true)
                {
                    HutagoPower();
                    HutagoH = false;
                }
                //transform.position = new Vector3(transform.position.x + (Mathf.Sin(Time.time * enemy.speed) * 2f), transform.position.y, 0);

                //ふたご座（男）の現在地
                Vector2 ufo_pos = this.transform.position;

                if (ufo_pos.x >= 640) mea_flg = true;

                if (ufo_pos.x <= 80) mea_flg = false;

                if(Player != null)
                {
                    if (mea_flg)
                    {
                        this.transform.position = new Vector2(ufo_pos.x - 5, ufo_pos.y);
                    }
                    else
                    {
                        this.transform.position = new Vector2(ufo_pos.x + 5, ufo_pos.y);
                    }
                }
                
            }
            if (enemy.hp <= 0)
            {
                //Destroy(GameObject.Find("EnemyHutagoSister"));
                Destroy(HSister);
            }
        }
        else
        {
            if (Hutago == true)
            {
                //ふたご座（男）の現在地
                Vector2 ufo_pos = this.transform.position;

                if (ufo_pos.x >= 640) mea_flg = true;

                if (ufo_pos.x <= 80) mea_flg = false;

                if (Player != null)
                {
                    if (mea_flg)
                    {
                        this.transform.position = new Vector2(ufo_pos.x - 5, ufo_pos.y);
                    }
                    else
                    {
                        this.transform.position = new Vector2(ufo_pos.x + 5, ufo_pos.y);
                    }
                }
            }
        }

        if (HutagoS == true)
        {

            GameObject HutagoT = GameObject.Find("EnemyHutago");
            if (HutagoT == null)
            {
                Debug.Log("asdfghj");
                Destroy(gameObject);
            }
            float x = HutagoT.transform.position.x + (Mathf.Cos(Time.time * enemy.speed) * radius);
            float y = HutagoT.transform.position.y + (Mathf.Sin(Time.time * enemy.speed) * radius);
            float z = 0f;
            transform.position = new Vector3(x, y, z);
          
        }

        //かに座の処理
        if (Kani == true)
        {
            rate += Time.deltaTime;

            if (rate > intense_rate)
            {
                Vector3 pos = this.transform.position;
                Vector3 kani_pos = new Vector3(pos.x, pos.y - 30, pos.z);
                Quaternion kani_qua = new Quaternion(0,0, 180, 0);
                Instantiate(Bubble, kani_pos, kani_qua);
                rate = 0;
            }
            //かに座の現在地
            Vector2 ufo_pos = this.transform.position;
            if (ufo_pos.x >= 640) mea_flg = true;

            if (ufo_pos.x <= 80) mea_flg = false;

            if (Player != null)
            {
                if (mea_flg)
                    this.transform.position = new Vector2(ufo_pos.x - 5, ufo_pos.y);
                else
                    this.transform.position = new Vector2(ufo_pos.x + 5, ufo_pos.y);
            }
        }

    }

    void HutagoPower()
    {
        
        HSister = (GameObject)Instantiate(HutagoSister, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        //HSister.transform.parent = transform;
        Transform Tf = HSister.GetComponent<Transform>();
        Vector3[] path =
        {
                new Vector3(Tf.localPosition.x,Tf.localPosition.y * 1.1f,0f),
                //new Vector3(0f,150f,0f),
            };
        //DOTweenを使ったアニメ作成
        Tf.DOLocalPath(path, 0.5f, PathType.CatmullRom)
            .SetEase(Ease.OutQuad);
    }

    private void FixedUpdate()
    {
        rate_span += Time.fixedDeltaTime;
        if(rate_span > 1)
            intense_rate = Random.Range(0.5f, 1.0f);

    }
}
