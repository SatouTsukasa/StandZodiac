using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の移動スピード
    public int speed = 10;

    //旋回速度
    public int rot;

    // ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime = 5;

    public bool Track = false;

    //攻撃力
    public int power = 1;

    public GameObject player;

    public float rad;

    private Vector2 Position;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        // ローカル座標のY軸方向に移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

        // lifeTime秒後に削除
        Destroy(gameObject, lifeTime);
        
        if(Track == true)
        {
            //ラジアンから度に変換
            rad = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg;
            if (rad < 0) rad += 90;
            //transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, 0.5f);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, 0), speed);
            Debug.Log(rad);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Track == true)
        {
            Position = transform.position;
            Position.x += rot * Mathf.Cos(rad);
            transform.position = Position;
            //rad = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x));
        }
        
    }

}
