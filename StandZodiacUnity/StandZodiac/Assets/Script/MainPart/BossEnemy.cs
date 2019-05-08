﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class BossEnemy : MonoBehaviour
{

    Enemy enemy;

    //ふたご座
    public bool Hutago;
    public GameObject HutagoSister;

    //かに座
    public bool Kani;
    public GameObject Bubble;

    private bool HutagoH;

    ///HutagoSister用--------------
    public bool HutagoS;
    //半径
    public float radius;
    ///----------------------------

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        HutagoH = true;

        if(Kani == true)
            GetComponent<Rigidbody2D>().velocity = transform.right;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (enemy.hp <= 25)
        {
            if (Hutago == true && HutagoH == true)
            {
                HutagoPower();
                HutagoH = false;
            }
        }

        if (HutagoS == true)
        {
            float x = transform.position.x + Mathf.Cos(Time.time * enemy.speed * radius);
            float y = transform.position.y + Mathf.Sin(Time.time * enemy.speed * radius);
            float z = 0f;
            transform.position = new Vector3(x, y, z);
        }

        if(Kani == true)
        {
            //現在地
            Vector2 kani_pos = this.transform.position;

            if (kani_pos.x >= 720)
                GetComponent<Rigidbody2D>().velocity = transform.right * -1;

            if (kani_pos.x <= 0)
                GetComponent<Rigidbody2D>().velocity = transform.right;
        }

    }

    void HutagoPower()
    {
        Debug.Log("asdfghj");
        GameObject HSister = (GameObject)Instantiate(HutagoSister, new Vector2(transform.position.x, transform.position.y - 10), Quaternion.identity);
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
}
