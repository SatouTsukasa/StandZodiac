using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の移動スピード
    public int speed = 10;

    // ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime = 5;

    public bool cluster = false;

    //攻撃力
    public int power = 1;

    public float splitTime;
    float intervalTime;
    public GameObject clusterBullet;

    private Vector2 Position;

    // Spaceshipコンポーネント
    Spaceship spaceship;

    // Start is called before the first frame update
    void Start()
    {

        spaceship = GetComponent<Spaceship>();

        // ローカル座標のY軸方向に移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;


        // lifeTime秒後に削除
        Destroy(gameObject, lifeTime);
        
        if(cluster == true)
        {


        }
        
    }


    // Update is called once per frame
    void Update()
    {
        intervalTime += Time.deltaTime;
        if(cluster == true)
        {
            if(intervalTime >= splitTime)
            {
                Cluster();
                intervalTime = 0;
            }
        }
        
    }

    void Cluster()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == 0) continue;
            Transform shotPosition = transform.GetChild(i);

            // ShotPosition
            //spaceship.Shot(shotPosition);
            GameObject ClusterBrret = Instantiate(clusterBullet, shotPosition.position, shotPosition.rotation);
            //Debug.Log(ClusterBrret);
        }
        Destroy(gameObject);
    }

}
