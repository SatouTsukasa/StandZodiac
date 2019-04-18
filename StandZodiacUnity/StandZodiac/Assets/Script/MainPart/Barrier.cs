using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float dTime = 10.0f;

    void Start()
    {
        Destroy(gameObject, dTime);
    }
    
    void Update()
    {
        //位置をプレイヤーに合わせる
        Vector3 tmp = GameObject.Find("Player").transform.position;
        this.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == "Bullet(Enemy)")
        {
            // 弾の削除
            Destroy(col.gameObject);
        }
    }
}
