using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PowerUpItem : MonoBehaviour
{

    public bool Power = false;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {

        rect = GetComponent<RectTransform>();

        //アイテムの軌跡設定
        /*Vector3[] path =
        {
            new Vector3(rect.localPosition.x * 1.5f,300f,0f),
            new Vector3(0f,150f,0f),
        };

        //DOTweenを使ったアニメ作成
        rect.DOLocalPath(path, 1.5f, PathType.CatmullRom)
            .SetEase(Ease.OutQuad);*/

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
                c.GetComponent<Spaceship>().shotDelay -= 0.01f;
                Destroy(this.gameObject);
            }
        }
    }
}
