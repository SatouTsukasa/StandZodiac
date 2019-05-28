using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float dTime = 10.0f;
    private GameObject player;

    Spaceship spaceship;

    void Start()
    {
        Destroy(gameObject, dTime);

        spaceship = GetComponent<Spaceship>();

        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        if (player != null)
        {
            //位置をプレイヤーに合わせる
            Vector3 p_pos = GameObject.Find("Player").transform.position;
            this.transform.position = new Vector3(p_pos.x, p_pos.y, p_pos.z);
        }
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
