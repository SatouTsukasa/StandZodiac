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

    //ジグザグ移動
    public bool meander;
    bool mea_flg;

    //Playerオブジェクト
    private GameObject pl;

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

        //Bubble関係
        pl = GameObject.FindGameObjectWithTag("Player");
        if (Random.Range(1, 3) == 1)
            mea_flg = true;
        else
            mea_flg = false;
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

        if (meander == true)
            Meandermove();
    }

    void Meandermove()
    {
        if (pl != null)
        {
            //Bulletの現在地
            Vector2 bullet_pos = this.transform.position;

            if (bullet_pos.x >= 720) mea_flg = true;

            if (bullet_pos.x <= 0) mea_flg = false;

            if (mea_flg)
                this.transform.position = new Vector2(bullet_pos.x - 5, bullet_pos.y);
            else
                this.transform.position = new Vector2(bullet_pos.x + 5, bullet_pos.y);
        }
    }

    void Cluster()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == 0) continue;
            Transform shotPosition = transform.GetChild(i);
            Vector3 placePosition = new Vector3(shotPosition.position.x, shotPosition.position.y + 50, shotPosition.position.z);

            // ShotPosition
            //spaceship.Shot(shotPosition);
            GameObject ClusterBrret = Instantiate(clusterBullet, placePosition/*shotPosition.position*/, shotPosition.rotation);
            //Debug.Log(ClusterBrret);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Debug.Log("loiuekfjd");
        Destroy(gameObject);
    }

}
