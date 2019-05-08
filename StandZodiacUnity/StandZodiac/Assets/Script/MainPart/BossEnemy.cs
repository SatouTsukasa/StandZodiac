using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class BossEnemy : MonoBehaviour
{

    Enemy enemy;

    public float width;

    //ふたご座
    public bool Hutago;
    public GameObject HutagoSister;

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

        width = 720;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (enemy.hp <= 25)
        {
            if (Hutago == true)
            {
                if(HutagoH == true)
                {
                    HutagoPower();
                    HutagoH = false;
                }
                transform.position = new Vector3(transform.position.x + (Mathf.Sin(Time.time * enemy.speed)), transform.position.y, 0);
            }
        }

        if (HutagoS == true)
        {
            float x = transform.position.x + (Mathf.Cos(Time.time * enemy.speed) * radius);
            float y = transform.position.y + (Mathf.Sin(Time.time * enemy.speed) * radius);
            float z = 0f;
            transform.position = new Vector3(x, y, z);
        }

    }

    void HutagoPower()
    {
        Debug.Log("asdfghj");
        GameObject HSister = (GameObject)Instantiate(HutagoSister, new Vector2(transform.position.x, transform.position.y - 10), Quaternion.identity);
        HSister.transform.parent = transform;
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
