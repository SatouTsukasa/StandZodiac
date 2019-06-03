using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PowerUpItem : MonoBehaviour
{

    Spaceship spaceship;

    public bool Power = false;
    public bool Turret = false;
    public int TurretCount;

    RectTransform rect;
    Transform Tf;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.Find("Player").GetComponent<Spaceship>();

        //TurretCount = 0;

        rect = GetComponent<RectTransform>();

        Tf = GetComponent<Transform>();

        

        //アイテムの軌跡設定
        Vector3[] path =
        {
            new Vector3(Tf.localPosition.x * 1.2f,Tf.localPosition.y * 1.05f,0f),
            //new Vector3(0f,150f,0f),

        };

        //DOTweenを使ったアニメ作成
        GetComponent<Transform>().DOLocalPath(path, 0.5f, PathType.CatmullRom)
            .SetEase(Ease.OutQuad);

        // ローカル座標のY軸方向に移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * -100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if(layerName == "Player")
        {

            if (Power == true)
            {
                Debug.Log("iiiiiiiii");
                c.GetComponent<Spaceship>().shotDelay -= 0.005f;
                if (c.GetComponent<Spaceship>().shotDelay < 0.05)
                {

                    c.GetComponent<Spaceship>().shotDelay = 0.05f;
                }
                Destroy(this.gameObject);
            }
            else if(Turret == true)
            {
                //TurretCount += 1;
                //c.GetComponent<Player>().TurretCount += 1;
                Debug.Log(TurretCount);
                if(c.GetComponent<Player>().PU2 == false)
                {
                    
                    c.GetComponent<Player>().PU2 = true;
                    Destroy(this.gameObject);
                    return;
                }
                if(c.GetComponent<Player>().PU3 == false)
                {
                    
                    c.GetComponent<Player>().PU3 = true;
                    Destroy(this.gameObject);
                    return;
                }
                if(c.GetComponent<Player>().PU4 == false)
                {
                    Debug.Log("nnnnnnnnnnnnnnnnnnnnnnnnnnnn");
                    c.GetComponent<Player>().PU4 = true;
                    Destroy(this.gameObject);
                    return;
                }
                if(c.GetComponent<Player>().PU5 == false)
                {
                    Debug.Log("mmmmmmmmmmmmmmmmmmmmmmmmmmm");
                    c.GetComponent<Player>().PU5 = true;
                    Destroy(this.gameObject);
                    return;
                }
                else
                {
                    Destroy(this.gameObject);
                }

            }
        }
    }
}
