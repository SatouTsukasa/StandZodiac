using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の移動スピード
    public int speed = 10;

    // ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime = 5;

    public bool Track = false;

    //攻撃力
    public int power = 1;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        // ローカル座標のY軸方向に移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

        // lifeTime秒後に削除
        Destroy(gameObject, lifeTime);
    }


    // Update is called once per frame
    void Update()
    {
        if(Track == true)
        {
            Debug.Log("fff");
            //Vector2 diff = (player.transform.position - transform.position).normalized;
            //transform.rotation = Quaternion.FromToRotation(Vector3.left, diff);
            if(transform.position.y > player.transform.position.y)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, 0.5f);
                transform.position += transform.up * -speed;
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, 0), speed);
            }
            
            else if(transform.position.y < player.transform.position.y)
            {
                Debug.Log("ggg");
                transform.position += transform.up * -speed;
            }
        }

        if (player == null) Destroy(gameObject);
    }
}
